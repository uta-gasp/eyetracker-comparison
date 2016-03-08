using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Extensions;

namespace EyeTrackerComparison
{
    public class GazeProcessor
    {
        #region Consts

        public static readonly int SAMPLE_INTERVAL = 30;    // ms

        private const int DEFAULT_MAX_DIST = 70;            // pixels
        private const int DEFAULT_MAPPING_DELAY = 1000;     // ms

        #endregion

        #region Internal members

        private TwoLevelLowPassFilter iFilter = new TwoLevelLowPassFilter(SAMPLE_INTERVAL);

        private Queue<GazePoint> iPointBuffer = new Queue<GazePoint>();
        private System.Windows.Forms.Timer iPointsTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer iDelayTimer = new System.Windows.Forms.Timer();

        private Trial iTrial;
        private Target iCurrentTarget = null;
        private Target iFixTarget = null;
        private List<GazeArea> iAreas = new List<GazeArea>();

        #endregion

        #region Events

        public event EventHandler PointProcessed = delegate { };

        #endregion

        #region Parameters

        public int ObjectMaxExtension { get; set; } = DEFAULT_MAX_DIST;
        public int MappingDelay
        {
            get { return iDelayTimer.Interval; }
            set { iDelayTimer.Interval = value; }
        }

        #endregion

        #region Properties

        public bool Active { get; private set; } = false;
        public Point LastPoint { get; private set; } = Point.Empty;
        
        #endregion

        #region Public methods

        public GazeProcessor()
        {
            iPointsTimer.Interval = SAMPLE_INTERVAL;
            iPointsTimer.Tick += PointsTimer_Tick;

            iDelayTimer.Interval = DEFAULT_MAPPING_DELAY;
            iDelayTimer.Tick += DelayTimer_Tick;

            iFilter.FixationStarted += Filter_FixationStarted;
            iFilter.FixationEnded += Filter_FixationEnded;
        }

        public void start()
        {
            LastPoint = Point.Empty;

            iFilter.reset();
            iPointBuffer.Clear();
            iPointsTimer.Start();

            Active = true;
        }

        public void stop()
        {
            Active = false;

            iAreas.Clear();
            iPointsTimer.Stop();
            iDelayTimer.Stop();

            Fixation fix = iFilter.CurrentFixation;
            if (fix.Duration > 0 && iTrial != null)
            {
                fix.Target = iFixTarget;
                iTrial.Fixations.Add(fix);
            }

            iCurrentTarget = null;
            iFixTarget = null;
        }

        public void feed(long aTimestamp, Point aPoint)
        {
            if (aPoint.X < -1000 && aPoint.Y < -1000)
                return;

            lock (iPointBuffer)
            {
                iPointBuffer.Enqueue(new GazePoint(aTimestamp, aPoint));
            }
        }

        public void setTrial(Trial aTrial)
        {
            iAreas.Clear();

            if (iTrial != null)
            {
                Fixation fix = iFilter.CurrentFixation;
                if (fix.Duration > 0)
                {
                    fix.Target = iFixTarget;
                    iTrial.Fixations.Add(fix);
                }
            }

            iFixTarget = null;
            iFilter.reset();

            iTrial = aTrial;
            if (iTrial == null)
                return;

            iDelayTimer.Start();

            List<Target> targets = aTrial.Targets;
            foreach (Target target in targets)
            {
                iAreas.AddRange(target.Areas);
            }

            iCurrentTarget = targets.Count == 1 ? targets[0] : null;
        }

        public override string ToString()
        {
            return new StringBuilder("PARSER").
                AppendFormat("\t{0}", SAMPLE_INTERVAL).
                AppendFormat("\t{0}", ObjectMaxExtension).
                AppendFormat("\t{0}", MappingDelay).
                ToString();
        }

        #endregion

        #region Internal methods

        private void Filter_FixationStarted(object sender, EventArgs e)
        {
            iFixTarget = iCurrentTarget;
        }

        private void Filter_FixationEnded(object sender, TwoLevelLowPassFilter.FixationEventArgs e)
        {
            if (iTrial != null)
            {
                Fixation fix = e.Fixation;
                fix.Target = iFixTarget;
                iTrial.Fixations.Add(fix);
            }
        }

        private void ProcessNewPoint(long aTimestamp, Point aPoint)
        {
            GazePoint gp = iFilter.feed(new GazePoint(aTimestamp, aPoint));

            LastPoint = new Point(gp.X, gp.Y);
            PointProcessed(this, new EventArgs());

            if (iAreas.Count == 0)
                return;

            if (iDelayTimer.Enabled)
                return;

            foreach (GazeArea area in iAreas)
            {
                Point areaCenter = area.Rect.Center();
                double dx = gp.X - areaCenter.X;
                double dy = gp.Y - areaCenter.Y;
                double dist = Math.Sqrt(dx * dx + dy * dy);
                if (dist < ObjectMaxExtension || iAreas.Count == 1)
                {
                    area.GazeOffset.add(Math.Abs(dx), Math.Abs(dy));
                }
            }
        }

        private void PointsTimer_Tick(object sender, EventArgs e)
        {
            long timestamp = 0;
            Point point = new Point(0, 0);
            int bufferSize = 0;

            lock (iPointBuffer)
            {
                while (iPointBuffer.Count > 0)
                {
                    GazePoint gp = iPointBuffer.Dequeue();
                    timestamp = gp.Timestamp;
                    point.X += gp.X;
                    point.Y += gp.Y;
                    bufferSize++;
                }
            }

            if (bufferSize > 0)
            {
                point.X /= bufferSize;
                point.Y /= bufferSize;

                ProcessNewPoint(timestamp, point);
            }
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            iDelayTimer.Stop();
        }

        #endregion
    }
}
