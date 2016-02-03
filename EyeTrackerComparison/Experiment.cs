using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace SmoothPursuit
{
    public class Experiment
    {
        #region Declarations

        public class Trial
        {
            private static HiResTimestamp sHRTimestamp = new HiResTimestamp();

            private long iStartTimestamp = 0;
            
            public long  Duration { get; private set; }

            public Trial()
            {
            }

            public void start()
            {
                iStartTimestamp = sHRTimestamp.Milliseconds;
            }

            public void stop()
            {
                Duration = sHRTimestamp.Milliseconds - iStartTimestamp;
            }

            public override string ToString()
            {
                return new StringBuilder("TRIAL").
                    AppendFormat("\t{0}", Duration).
                    ToString();
            }
        }

        #endregion

        #region Internal members

        private int[] iPredefinedTargetValues = new int[20];
        private int iTrialCount;
        private int iTrialIndex;
        private List<Trial> iTrials = new List<Trial>();

        #endregion

        #region Events

        public class NextTrialArgs : EventArgs
        {
            public Color TargetColor { get; private set; }
            public Color StartColor { get; private set; }
            public int TargetValue { get; private set; }
            public int StartValue { get; private set; }

            public NextTrialArgs(Trial aTrial)
            {
                TargetColor = aTrial.Target;
                TargetValue = aTrial.TargetValue;
                
                StartColor = aTrial.Start;
                StartValue = aTrial.StartValue;
            }
        }
        public delegate void NextTrialHandler(object aSender, NextTrialArgs aArgs);
        public event NextTrialHandler OnNextTrial = delegate { };
        public event EventHandler OnFinished = delegate { };

        #endregion

        #region Properties

        public Trial CurrentTrial { get { return iTrialIndex < 0 ? null : iTrials[iTrialIndex]; } }

        #endregion

        #region Public methods

        public Experiment(int aTrialCount)
        {
            iTrialCount = aTrialCount;
            iTrialIndex = -1;

            for (int i = 0; i < 10; i++)
            {
                iPredefinedTargetValues[i] = 28 + i * 8;
            }
            for (int i = 0; i < 10; i++)
            {
                iPredefinedTargetValues[10 + i] = 156 + i * 8;
            }
        }

        public void start()
        {
            CreateTrials();

            iTrialIndex = 0;
            StartNextTrial();
        }

        public void stop()
        {
            iTrialIndex = -1;
        }

        public void next(Color aSelectedColor)
        {
            if (iTrialIndex < 0)
                return;

            iTrials[iTrialIndex].stop(aSelectedColor);
            
            iTrialIndex++;
            if (iTrialIndex == iTrialCount)
            {
                stop();
                OnFinished(this, new EventArgs());
            }
            else
            {
                StartNextTrial();
            }
        }

        public void save(string aFileName, string aHeader)
        {
            using (TextWriter writer = new StreamWriter(aFileName))
            {
                writer.WriteLine(aHeader);
                for (int i = 0; i < iTrials.Count; i++)
                {
                    writer.WriteLine(iTrials[i]);
                    Console.WriteLine(iTrials[i]);
                }
            }
        }

        #endregion

        #region Internal methods

        private void CreateTrials()
        {
            iTrials.Clear();
            for (int i = 0; i < iTrialCount; i++)
            {
                iTrials.Add(new Trial(iPredefinedTargetValues[i % iPredefinedTargetValues.Length]));
            }

            Random rand = new Random();
            for (int i = 0; i < 2 * iTrialCount; i++)
            {
                int idx1 = rand.Next(iTrialCount);
                int idx2 = rand.Next(iTrialCount);
                Trial temp = iTrials[idx1];
                iTrials[idx1] = iTrials[idx2];
                iTrials[idx2] = temp;
            }
        }

        private void StartNextTrial()
        {
            Trial trial = iTrials[iTrialIndex];
            OnNextTrial(this, new NextTrialArgs(trial));
            trial.start();
        }

        #endregion
    }
}
