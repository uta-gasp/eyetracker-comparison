using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using Extensions;

namespace EyeTrackerComparison
{
    public class Result
    {
        #region Properties

        public bool Valid { get; private set; }
        public string Title { get; private set; }
        public PointF AreaOffset { get; private set; }
        public PointF FixOffset { get; private set; }

        #endregion

        #region Public methods

        public Result()
        {
            Valid = false;
        }

        public void calc(Trial aTrial)
        {
            Valid = true;

            Title = aTrial.Type.ToString();

            double dx = 0;
            double dy = 0;
            int count = 0;
            List<Target> targets = aTrial.Targets;
            foreach (Target target in targets)
            {
                foreach (GazeArea area in target.Areas)
                {
                    dx += area.GazeOffset.X;
                    dy += area.GazeOffset.Y;
                    count++;
                }
            }

            AreaOffset = count > 0 ? new PointF((float)dx / count, (float)dy / count) : new PointF(0, 0);

            dx = 0;
            dy = 0;
            count = 0;
            foreach (Fixation fix in aTrial.Fixations)
            {
                if (fix.Target != null)
                {
                    Point center = fix.Target.Areas[0].Rect.Center();
                    dx += Math.Abs(fix.X - center.X);
                    dy += Math.Abs(fix.Y - center.Y);
                    count++;
                }
            }

            FixOffset = count > 0 ? new PointF((float)dx / count, (float)dy / count) : new PointF(0, 0);
        }

        public override string ToString()
        {
            return new StringBuilder(Title).
                AppendLine().
                AppendFormat("Area Offset: X={0:N1}, Y={1:N1}", AreaOffset.X, AreaOffset.Y).
                AppendLine().
                AppendFormat("Fix Offset: X={0:N1}, Y={1:N1}", FixOffset.X, FixOffset.Y).
                ToString();
        }

        #endregion
    }
}
