using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EyeTrackerComparison
{
    public class Trial
    {
        public enum TargetType
        {
            Images,
            Text
        }

        #region Constants

        private const int DEFAULT_ROW_COUNT = 3;
        private const int DEFAULT_COL_COUNT = 4;
        private const double DEFAULT_CELL_MARGIN = 0.15;

        #endregion

        #region Internal members

        private static bool Centered = true;

        private readonly Size iDisplaySize;
        private int iRowCount;
        private int iColCount;
        private double iCellMargin = DEFAULT_CELL_MARGIN;
        private List<Target> iTargets = new List<Target>();

        #endregion

        #region Parameters

        public TargetType Type { get; private set; }
        public string[] Data { get; private set; }
        public int RowCount { get { return iRowCount; } set { iRowCount = value; CreateTargets(); } }
        public int ColCount { get { return iColCount; } set { iColCount = value; CreateTargets(); } }

        #endregion

        #region Properties

        public long Duration { get; private set; }
        public double CellMargin { get { return iCellMargin; } set { iCellMargin = value; CreateTargets(); } }
        public int ActiveTargetIndex { get; private set; } = -1;
        public List<Target> Targets
        {
            get
            {
                if (ActiveTargetIndex >= 0)
                {
                    List<Target> result = new List<Target>();
                    result.Add(iTargets[ActiveTargetIndex]);
                    return result;
                }
                else
                {
                    return iTargets;
                }
            }
        }
        public List<Fixation> Fixations { get; private set; } = new List<Fixation>();
        public long ActivationTime { get; set; }
        public Result Result { get; private set; } = new Result();

        #endregion

        #region Public methods

        public Trial(Size aDisplaySize, int aColCount = DEFAULT_COL_COUNT, int aRowCount = DEFAULT_ROW_COUNT, string aImageName = "")
        {
            iDisplaySize = aDisplaySize;
            if (iDisplaySize.Width == 0 || iDisplaySize.Height == 0)
            {
                iDisplaySize = Screen.PrimaryScreen.Bounds.Size;
            }

            iColCount = aColCount;
            iRowCount = aRowCount;

            Data = aImageName.Split('\n');
            Type = TargetType.Images;

            CreateTargets();
        }

        public Trial(Size aDisplaySize, string[] aText)
        {
            iDisplaySize = aDisplaySize;
            if (iDisplaySize.Width == 0 || iDisplaySize.Height == 0)
            {
                iDisplaySize = Screen.PrimaryScreen.Bounds.Size;
            }

            Data = aText;
            Type = TargetType.Text;

            CreateTargets();
        }

        public void start(bool aActivateAll, long aActivationTime)
        {
            ActivationTime = aActivationTime;

            Fixations.Clear();
            foreach (Target target in iTargets)
            {
                foreach (GazeArea area in target.Areas)
                {
                    area.GazeOffset.reset();
                }
            }

            if (!aActivateAll)
            {
                ActiveTargetIndex = 0;

                Target target = iTargets[ActiveTargetIndex];
                target.ActivationTime = aActivationTime;
                //Events.Add(target.ToString());
            }
            else
            {
                foreach (Target target in iTargets)
                {
                    target.ActivationTime = aActivationTime;
                }
            }
        }

        public bool activateNext(long aActivationTime)
        {
            if (ActiveTargetIndex < 0)
                return false;

            ActiveTargetIndex++;
            if (ActiveTargetIndex == iTargets.Count)
            {
                ActiveTargetIndex = -1;
                return false;
            }
            else
            {
                Target target = iTargets[ActiveTargetIndex];
                target.ActivationTime = aActivationTime;
                //Events.Add(target.ToString());
            }
            return true;
        }

        public void stop(long aTimeStamp)
        {
            Duration = aTimeStamp - ActivationTime;
            ActiveTargetIndex = -1;

            Result.calc(this);
        }

        public void write(TextWriter aWriter)
        {
            foreach (Target target in iTargets)
            {
                if (target.Areas.Count == 1)
                {
                    aWriter.WriteLine(target);
                }
                else
                {
                    aWriter.WriteLine("TARGET");
                    foreach (GazeArea area in target.Areas)
                    {
                        aWriter.WriteLine(area);
                    }
                }
            }
            aWriter.WriteLine("EVENTS");
            foreach (Fixation fix in Fixations)
            {
                aWriter.WriteLine(fix);
            }
        }

        public override string ToString()
        {
            return new StringBuilder("TRIAL").
                AppendFormat("\t{0}", ActivationTime).
                AppendFormat("\t{0}", Duration).
                AppendFormat("\t{0}", iTargets.Count).
                AppendFormat("\t{0}", Type).
                ToString();
        }

        public string toStorage()
        {
            List<string> fields = new List<string>();
            fields.Add(Convert.ToString((int)Type));
            fields.Add(Convert.ToString(ColCount));
            fields.Add(Convert.ToString(RowCount));
            foreach (string line in Data)
            {
                fields.Add(line);
            }
            return String.Join("|", fields);
        }

        public static Trial fromStorage(string aText)
        {
            string[] fields = aText.Split('|');
            if (fields.Length < 4)
                throw new Exception("Cannot load Trial from storage");

            TargetType type = (TargetType)Int32.Parse(fields[0]);
            int cols = Int32.Parse(fields[1]);
            int rows = Int32.Parse(fields[2]);

            List<string> lines = new List<string>();
            for (int i = 3; i < fields.Length; i++)
            {
                lines.Add(fields[i]);
            }

            Trial result;
            switch (type)
            {
                case TargetType.Images:
                    result = new Trial(Size.Empty, cols, rows, fields[3]);
                    break;
                case TargetType.Text:
                    result = new Trial(Size.Empty, lines.ToArray());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Trial.fromStorage", type, "No target creation implementation for this type");
            }

            return result;
        }

        #endregion

        #region Internal methods

        private void CreateTargets()
        {
            iTargets.Clear();
            switch (Type)
            {
                case TargetType.Images:
                    CreateMatrixOfImages();
                    RandomizeTargetOrder();
                    break;
                case TargetType.Text:
                    CreateText();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Trial.iType", Type, "No target creation implementation for this type");
            }
        }

        private void CreateMatrixOfImages()
        {
            Random r = new Random();
            string[] imageNames = Target.imageNames();

            double cellWidth = (double)iDisplaySize.Width / ColCount;
            double cellHeight = (double)iDisplaySize.Height / RowCount;
            for (int i = 0; i < ColCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    Rectangle rect = new Rectangle((int)(i * cellWidth), (int)(j * cellHeight), (int)cellWidth, (int)cellHeight);
                    rect.Inflate((int)(-cellWidth * CellMargin / 2.0), (int)(-cellHeight * CellMargin / 2.0));
                    int offsetX = Centered ? rect.Width / 2 : r.Next(rect.Width);
                    int offsetY = Centered ? rect.Height / 2 : r.Next(rect.Height);

                    string imageName = Data[0];
                    if (imageName.Length == 0)
                    {
                        imageName = imageNames[r.Next(imageNames.Length)];
                    }

                    try
                    {
                        Target target = new Target(imageName, new Point(rect.Left + offsetX, rect.Top + offsetY));

                        iTargets.Add(target);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void CreateText()
        {
            try
            {
                Size layout = new Size((int)(iDisplaySize.Width * 0.9), (int)(iDisplaySize.Height * 0.9));
                Point location = new Point(iDisplaySize.Width / 2, iDisplaySize.Height / 2);
                Target target = new Target(Data, location, layout);

                iTargets.Add(target);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RandomizeTargetOrder()
        {
            if (iTargets.Count > 1)
            {
                Random rand = new Random();
                for (int i = 0; i < 2 * iTargets.Count; i++)
                {
                    int idx1 = rand.Next(iTargets.Count);
                    int idx2 = rand.Next(iTargets.Count);
                    Target temp = iTargets[idx1];
                    iTargets[idx1] = iTargets[idx2];
                    iTargets[idx2] = temp;
                }
            }
        }

        #endregion
    }
}
