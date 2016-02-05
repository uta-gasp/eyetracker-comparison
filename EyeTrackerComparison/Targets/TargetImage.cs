using System.Drawing;

namespace EyeTrackerComparison
{
    public class TargetImage
    {
        public string Name { get; private set; }
        public Image Image { get; private set; }
        public TargetImage(string aName, Image aImage)
        {
            Name = aName;
            Image = aImage;
        }
    }
}
