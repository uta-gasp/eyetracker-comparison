using System.Text;

namespace EyeTrackerComparison
{
    public class FocusOffset
    {
        #region Internal members

        private double iX;
        private double iY;

        #endregion

        #region Public members

        public int Count { get; private set; }
        public double X
        {
            get
            {
                return Count == 0 ? 0.0 : iX / Count;
            }
        }
        public double Y
        {
            get
            {
                return Count == 0 ? 0.0 : iY / Count;
            }
        }

        #endregion

        #region Public methods

        public FocusOffset()
        {
            reset();
        }

        public void reset()
        {
            iX = 0;
            iY = 0;
            Count = 0;
        }

        public void add(double aOffsetX, double aOffsetY)
        {
            iX += aOffsetX;
            iY += aOffsetY;
            Count++;
        }

        public override string ToString()
        {
            return new StringBuilder("OFFSET").
                AppendFormat("\t{0}", Count).
                AppendFormat("\t{0:N1}\t{1:N1}", X, Y).
                ToString();
        }

        #endregion
    }
}
