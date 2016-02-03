using System.Drawing;

namespace EyeTrackerComparison
{
    public class ResImage
    {
        public string Name { get; private set; }
        public Image Image { get; private set; }
        public ResImage(string aName, Image aImage)
        {
            Name = aName;
            Image = aImage;
        }
    }
}
