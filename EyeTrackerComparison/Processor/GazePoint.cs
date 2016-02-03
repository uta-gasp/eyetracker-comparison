using System.Drawing;

namespace EyeTrackerComparison
{
    public struct GazePoint
    {
        public long Timestamp;
        public int X;
        public int Y;

        public GazePoint(long aTimestamp, Point aPoint)
        {
            Timestamp = aTimestamp;
            X = aPoint.X;
            Y = aPoint.Y;
        }
    }
}
