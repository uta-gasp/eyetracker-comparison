using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace EyeTrackerComparison
{
    public class Target
    {
        #region Constants

        private static readonly Color TEXT_BACKGROUND = Color.Transparent;

        #endregion

        private static List<ResImage> sResImages = null;

        #region Parameters

        public static int MaxImageSize = 48;
        public static Color TextColor = Color.Black;
        public static string FontName = "Arial";
        public static float FontSize = 32.0f;
        public static float LineHeight = 2.0f;

        #endregion

        #region Properties

        public string Data { get; private set; }
        public Image Image { get; private set; }
        public Point Location { get; private set; }
        public List<GazeArea> Areas { get; private set; } = new List<GazeArea>();
        public long ActivationTime { get; set; }

        #endregion

        #region Public methods

        public Target(string aImageName, Point aLocation)
        {
            Data = aImageName;

            Image = images().Find(img => img.Name == aImageName)?.Image;

            if (Image == null)
            {
                throw new ArgumentException("No such image", "aImageName");
            }
            else
            {
                RescaleImage();
                Location = new Point(aLocation.X - Image.Width / 2, aLocation.Y - Image.Height / 2);
                Areas.Add(new GazeArea(Data, new Rectangle(Location, Image.Size)));
            }
        }

        public Target(string[] aText, Point aLocation, Size aLayout)
        {
            Data = "text";

            if (aText.Length == 0)
            {
                throw new ArgumentException("Text cannot be empty", "aText");
            }

            Location = new Point(aLocation.X - aLayout.Width / 2, aLocation.Y - aLayout.Height / 2);

            Image = CreateImageFromText(aText, aLayout);
        }

        public static List<ResImage> images()
        {
            if (sResImages == null)
                CreateImages();

            return sResImages;
        }

        public static string[] imageNames()
        {
            if (sResImages == null)
                CreateImages();

            List<string> result = new List<string>();

            foreach (ResImage image in sResImages)
            {
                result.Add(image.Name);
            }

            return result.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("TARGET").
                AppendFormat("\t{0}", ActivationTime);
            foreach (GazeArea area in Areas)
            {
                sb.AppendFormat("\t{0}", area);
            }
            return sb.ToString();
        }

        #endregion

        #region Internal methods

        private static void CreateImages()
        {
            sResImages = new List<ResImage>();

            TypeInfo t = typeof(Properties.Resources).GetTypeInfo();
            IEnumerable<PropertyInfo> properties = t.DeclaredProperties;
            foreach (PropertyInfo prop in properties)
            {
                object resource = Properties.Resources.ResourceManager.GetObject(prop.Name);
                if (resource is Image)
                {
                    sResImages.Add(new ResImage(prop.Name, resource as Image));
                }
            }
        }

        private void RescaleImage()
        {
            double ratio = (double)Image.Width / Image.Height;
            int width = Image.Width >= Image.Height ? MaxImageSize : (int)(MaxImageSize * ratio);
            int height = Image.Width >= Image.Height ? (int)(MaxImageSize / ratio) : MaxImageSize;
            Bitmap scaledImage = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(scaledImage);
            g.DrawImage(Image, new Rectangle(0, 0, width, height));

            Image = scaledImage;
        }

        private Image CreateImageFromText(string[] aText, Size aLayout)
        {
            string[] text = ParseText(aText);

            Image image = new Bitmap(aLayout.Width, aLayout.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Font font = new Font(FontName, FontSize, GraphicsUnit.Pixel);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;

            RectangleF rect = new RectangleF(0, 0, image.Width, image.Height);

            //SizeF textImageSize = graphics.MeasureString(aString, font);
            //image = new Bitmap((int)Math.Ceiling(textImageSize.Width), (int)Math.Ceiling(textImageSize.Height));
            //graphics = Graphics.FromImage(image);

            graphics.Clear(TEXT_BACKGROUND);

            float topOffset = 0;
            foreach (string line in text)
            {
                graphics.DrawString(line, font, new SolidBrush(TextColor), rect, sf);
                DetectAreas(graphics, font, rect.Size, topOffset, sf, line);
                topOffset += FontSize * LineHeight;
                rect.Y = topOffset;
            }

            return image;
        }

        private string[] ParseText(string[] aText)
        {
            List<string> result = new List<string>();

            string[] images = Target.imageNames();

            Regex regex = new Regex(@"{\$(?<name>\w+)}");
            foreach (string line in aText)
            {
                result.Add(regex.Replace(line, (Match aMatch) =>
                {
                    Group name = aMatch.Groups["name"];
                    if (name != null)
                    {
                        if (name.Value == "image")
                        {
                            return images[new Random().Next(images.Length)];
                        }
                    }
                    return "";
                }));
            }

            return result.ToArray();
        }

        private void DetectAreas(Graphics aGraphics, Font aFont, SizeF aSize, float aTopOffset, StringFormat aFormat, string aString)
        {
            Regex regex = new Regex(@"\b(?<word>\w+)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(aString);

            int lineIndex = -1;
            float top = 0;
            float bottom = 0;
            foreach (Match match in matches)
            {
                Group word = match.Groups["word"];
                if (word != null)
                {
                    SizeF stringLeft = aGraphics.MeasureString(aString.Substring(0, word.Index), aFont, aSize, aFormat);
                    SizeF stringRight = aGraphics.MeasureString(aString.Substring(0, word.Index + word.Length), aFont, aSize, aFormat);
                    if (lineIndex < 0)
                    {
                        lineIndex++;
                        bottom = stringRight.Height;
                    }

                    if (bottom < stringRight.Height)
                    {
                        top = stringRight.Height - bottom;
                        bottom = stringRight.Height;
                        lineIndex++;
                    }

                    Areas.Add(new GazeArea(word.Value, new Rectangle(Location.X + (int)stringLeft.Width, 
                        Location.Y + (int)(aTopOffset + top), (int)(stringRight.Width - stringLeft.Width), (int)(bottom - top))));
                }
            }
        }

        #endregion
    }
}
