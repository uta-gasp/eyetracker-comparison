using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace EyeTrackerComparison
{
    public class TargetImages : List<TargetImage>
    {
        private static readonly string[] IMAGE_FOLDERS = new string[] { @"img\", @"..\..\Images\stimul-rockets\" };
        private static TargetImages sInstance;

        public static TargetImages Instance
        {
            get { return sInstance ?? (sInstance = new TargetImages()); }
        }

        private TargetImages() :
            base()
        {
            CreateImages();
        }

        private void CreateImages()
        {
            foreach (string folder in IMAGE_FOLDERS)
            {
                DirectoryInfo directory = new DirectoryInfo(folder);
                if (directory.Exists)
                {
                    LoadImages(directory);
                }
            }

            if (this.Count == 0)
            {
                MessageBox.Show("No target images found", "Eye tracker comparison", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
            TypeInfo t = typeof(Properties.Resources).GetTypeInfo();
            IEnumerable<PropertyInfo> properties = t.DeclaredProperties;
            foreach (PropertyInfo prop in properties)
            {
                object resource = Properties.Resources.ResourceManager.GetObject(prop.Name);
                if (resource is Image)
                {
                    sResImages.Add(new ResImage(prop.Name, resource as Image));
                }
            }*/
        }

        private void LoadImages(DirectoryInfo aDirectory)
        {
            foreach (FileInfo file in aDirectory.GetFiles("*.png"))
            {
                try
                {
                    Image image = new Bitmap(file.FullName);
                    this.Add(new TargetImage(file.Name, image));
                }
                catch (Exception ex) { }
            }
        }
    }
}
