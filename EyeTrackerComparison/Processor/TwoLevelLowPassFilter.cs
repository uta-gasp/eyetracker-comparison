using System;
using System.Collections.Generic;
using System.Drawing;

namespace EyeTrackerComparison
{
    public class TwoLevelLowPassFilter
    {
        /* Algorithm
        //----------------------------------------------------------------------------
        // _    SUM(X[i]), if TimeWindow <= (Time[i] - Time[n]) < 2*TimeWindow
        // Xb = --------------------------------------------------------------
        //        SUM(1), if TimeWindow <= (Time[i] - Time[n]) < 2*TimeWindow
        //
        // _    SUM(X[i]), if 0 <= (Time[i]- Time[n]) < TimeWindow
        // Xa = --------------------------------------------------
        //       SUM(1), if 0 <= (Time[i] - Time[n]) < TimeWindow
        //
        //    where X[i] - X of a sample from the buffer
        //    where Time[i] - time of a sample from the buffer
        //    where Time[n] - time of the last sample
        //                 __________________________
        // Dist(Pb, Pa) = V(Xb - Xa)^2 + (Yb - Ya)^2
        //
        //     | T_FIX, if Dist(Pb, Pa) < Threshold
        // T = |
        //     | T_SACC, otherwise
        //
        // Alpha = T / SampleInterval
        //
        //      X[n] + Alpha * XMprev
        // XM = ---------------------
        //            1 + Alpha
        //
         * */

        #region Constants

        private const int DEFAULT_T_FIX = 300;
        private const int DEFAULT_T_SACC = 10;
        private const int DEFAULT_WINDOW_SIZE = 150;
        private const int DEFAULT_FIXATION_THRESHOLD = 50;

        #endregion

        #region Internal members

        private double iX = Double.NaN;
        private double iY = Double.NaN;
        private double iA = 0.0;

        private Queue<GazePoint> iBuffer = new Queue<GazePoint>();
        private bool iEnoughPoints = false;
        private long iFixationStart = 0;
        private long iLastTimestamp = 0;

        #endregion

        #region Events

        public class FixationEventArgs : EventArgs
        {
            public Fixation Fixation { get; private set; }
            public FixationEventArgs(Fixation aFixation)
            {
                Fixation = aFixation;
            }
        }
        public delegate void FixationEventhandler(object aSender, FixationEventArgs aArgs);
        public event EventHandler FixationStarted = delegate { };
        public event FixationEventhandler FixationEnded = delegate { };

        #endregion

        #region Properties

        public double AFix { get; set; }
        public double ASacc { get; set; }
        public int WindowSize { get; set; } = DEFAULT_WINDOW_SIZE;
        public int FixationThreshold { get; set; } = DEFAULT_FIXATION_THRESHOLD;

        public Fixation CurrentFixation
        {
            get
            {
                return new Fixation(iFixationStart, iLastTimestamp - iFixationStart, (int)iX, (int)iY);
            }
        }

        #endregion

        #region Public methods

        public TwoLevelLowPassFilter(int aInterval)
        {
            AFix = 300.0 / aInterval;
            ASacc = 10.0 / aInterval;
        }

        public GazePoint feed(GazePoint aGazePoint)
        {
            if (Double.IsNaN(iX) || Double.IsNaN(iY) || iA == 0)
            {
                iX = aGazePoint.X;
                iY = aGazePoint.Y;
                iA = AFix;
                iFixationStart = aGazePoint.Timestamp;
            }

            bool enoughPoints = UpdateBuffer(aGazePoint);
            double newA = EstimateCurrentA(aGazePoint);

            if (newA == ASacc && iA == AFix)
            {
                Fixation fix = new Fixation(iFixationStart, aGazePoint.Timestamp - iFixationStart, (int)iX, (int)iY);
                FixationEnded(this, new FixationEventArgs(fix));
            }
            else if (newA == AFix && iA == ASacc)
            {
                iFixationStart = aGazePoint.Timestamp;
                FixationStarted(this, new EventArgs());
            }

            iA = newA;

            if (!iEnoughPoints)
            {
                iX = aGazePoint.X;
                iY = aGazePoint.Y;
            }

            if (!iEnoughPoints && enoughPoints)
            {
                iEnoughPoints = true;
            }

            if (iEnoughPoints)
            {
                iX = (aGazePoint.X + iA * iX) / (1.0 + iA);
                iY = (aGazePoint.Y + iA * iY) / (1.0 + iA);
            }

            iLastTimestamp = aGazePoint.Timestamp;
            GazePoint result = new GazePoint(aGazePoint.Timestamp, new Point((int)iX, (int)iY));
            return result;
        }

        public void reset()
        {
            iBuffer.Clear();
            iX = Double.NaN;
            iY = Double.NaN;
            iA = ASacc;
            iEnoughPoints = false;
            iFixationStart = 0;
            iLastTimestamp = 0;
        }

        #endregion

        #region Internal methods

        private bool UpdateBuffer(GazePoint aGazePoint)
        {
            bool isFilterValid = false;
            iBuffer.Enqueue(aGazePoint);
            
            while (aGazePoint.Timestamp - iBuffer.Peek().Timestamp > (2 * WindowSize))
            {
                iBuffer.Dequeue();
                isFilterValid = true;
            }
            
            if (iBuffer.Count == 1)
            {
                iEnoughPoints = false;
            }

            return isFilterValid && iBuffer.Count > 1;
        }

        private double EstimateCurrentA(GazePoint aGazePoint)
        {
            double result = iA;

            double avgXB = 0;
            double avgYB = 0;
            double avgXA = 0;
            double avgYA = 0;
            int ptsBeforeCount = 0;
            int ptsAfterCount = 0;

            foreach (GazePoint gp in iBuffer)
            {
                long dt = aGazePoint.Timestamp - gp.Timestamp;
                if (dt > WindowSize)
                {
                    avgXB += gp.X;
                    avgYB += gp.Y;
                    ptsBeforeCount++;
                }
                else
                {
                    avgXA += gp.X;
                    avgYA += gp.Y;
                    ptsAfterCount++;
                }
            }

            if (ptsBeforeCount > 0 && ptsAfterCount > 0)
            {
                avgXB = avgXB / ptsBeforeCount;
                avgYB = avgYB / ptsBeforeCount;
                avgXA = avgXA / ptsAfterCount;
                avgYA = avgYA / ptsAfterCount;

                double dx = avgXB - avgXA;
                double dy = avgYB - avgYA;
                double dist = Math.Sqrt(dx * dx + dy * dy);

                result = dist > FixationThreshold ? ASacc : AFix;
            }

            return result;
        }

        #endregion
    }
}
