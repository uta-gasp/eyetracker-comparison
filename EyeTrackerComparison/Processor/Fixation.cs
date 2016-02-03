using System.Text;

namespace EyeTrackerComparison
{
    public class Fixation
    {
        public long Timestamp { get; private set; }
        public long Duration { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Target Target { get; set; } = null;

        public Fixation(long aTimstamp, long aDuration, int aX, int aY)
        {
            Timestamp = aTimstamp;
            Duration = aDuration;
            X = aX;
            Y = aY;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("FIX").
                AppendFormat("\t{0}", Timestamp).
                AppendFormat("\t{0}", Duration).
                AppendFormat("\t{0}", X).
                AppendFormat("\t{0}", Y);
            if (Target != null)
            {
                sb.AppendFormat("\t{0}", Target);
            }
            return sb.ToString();
        }
    }
}
