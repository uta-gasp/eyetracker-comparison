using System.Drawing;
using System.Text;

namespace EyeTrackerComparison
{
    public class GazeArea
    {
        #region Properties

        public string Data { get; private set; }
        public Point Location { get { return Rect.Location; } }
        public Rectangle Rect { get; private set; }
        public FocusOffset GazeOffset { get; private set; } = new FocusOffset();

        #endregion

        #region Public members

        public GazeArea(string aData, Rectangle aRect)
        {
            Data = aData;
            Rect = aRect;
        }

        public override string ToString()
        {
            return new StringBuilder("AREA").
                AppendFormat("\t{0}", Data).
                AppendFormat("\t{0}\t{1}\t{2}\t{3}", Rect.X, Rect.Y, Rect.Width, Rect.Height).
                AppendFormat("\t{0}", GazeOffset).
                ToString();
        }

        #endregion
    }
}
