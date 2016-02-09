using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace EyeTrackerComparison
{
    public class Experiment
    {
        public enum TargetActivationType
        {
            AllAtOnce,
            OneByOne
        }

        private static HiResTimestamp sHRTimestamp = new HiResTimestamp();
        
        #region Internal members

        private int iTrialIndex;
        private long iStartTimestamp = 0;
        private System.Windows.Forms.Timer iPauseTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer iTargetActivationTimer = new System.Windows.Forms.Timer();

        #endregion

        #region Events

        public class NextTrialArgs : EventArgs
        {
            public Trial Trial { get; private set; }
            public NextTrialArgs(Trial aTrial)
            {
                Trial = aTrial;
            }
        }
        public delegate void NextTrialHandler(object aSender, NextTrialArgs aArgs);
        public event NextTrialHandler OnNextTrial = delegate { };
        public event NextTrialHandler OnNextTarget = delegate { };
        public event EventHandler OnTrialFinished = delegate { };
        public event EventHandler OnFinished = delegate { };

        #endregion

        #region Parameters

        public bool UseHoming { get; set; } = true;
        public int PauseDuration
        {
            get { return iPauseTimer.Interval; }
            set { iPauseTimer.Interval = value; }
        }
        public int TargetActivationDuration
        {
            get { return iTargetActivationTimer.Interval; }
            set { iTargetActivationTimer.Interval = value; }
        }
        public TargetActivationType TargetActivation { get; set; } = TargetActivationType.AllAtOnce;
        public bool Randomize { get; set; } = true;

        #endregion

        #region Properties

        public Trial CurrentTrial { get { return iTrialIndex < 0 || iPauseTimer.Enabled ? null : Trials[iTrialIndex]; } }
        public List<Trial> Trials { get; private set; } = new List<Trial>();
        public long TimeElapsed
        {
            get
            {
                return iStartTimestamp == 0 ? 0 : sHRTimestamp.Milliseconds - iStartTimestamp;
            }
        }
        public bool Active { get; private set; } = false;

        #endregion

        #region Public methods

        public Experiment()
        {
            iTrialIndex = -1;

            iPauseTimer.Tick += PauseTimer_Tick;
            iTargetActivationTimer.Tick += TargetActivationTimer_Tick;

            // default trial
            Trials.Add(new Trial(Size.Empty));
        }

        public bool start()
        {
            bool result = false;

            if (Trials.Count > 0)
            {
                result = true;

                foreach (Trial trial in Trials)
                {
                    trial.recreateTargets();
                }

                iTrialIndex = 0;
                RandomizeTrialsOrder();

                iStartTimestamp = sHRTimestamp.Milliseconds;
                Active = true;

                if (UseHoming)
                {
                    iPauseTimer.Start();
                    OnTrialFinished(this, new EventArgs());
                }
                else
                {
                    StartNextTrial();
                }
            }

            return result;
        }

        public void stop()
        {
            iPauseTimer.Stop();
            iTargetActivationTimer.Stop();
            iTrialIndex = -1;
            Active = false;
        }

        public void next()
        {
            if (CurrentTrial == null)
                return;

            if (iTargetActivationTimer.Enabled || iPauseTimer.Enabled)
                return;

            Trial trial = Trials[iTrialIndex];
            trial.stop(sHRTimestamp.Milliseconds - iStartTimestamp);
            
            iTrialIndex++;
            if (iTrialIndex == Trials.Count)
            {
                stop();
                OnFinished(this, new EventArgs());
            }
            else if (UseHoming)
            {
                iPauseTimer.Start();
                OnTrialFinished(this, new EventArgs());
            }
            else
            {
                StartNextTrial();
            }
        }

        public bool save(string aFileName, string aHeader)
        {
            bool result = false;

            try
            {
                using (TextWriter writer = new StreamWriter(aFileName))
                {
                    writer.WriteLine(aHeader);
                    for (int i = 0; i < Trials.Count; i++)
                    {
                        writer.WriteLine(Trials[i]);
                        Trials[i].write(writer);
                    }
                    result = true;
                }
            }
            catch (IOException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, 
                    "Saving results...", 
                    System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
            }

            return result;
        }

        public override string ToString()
        {
            return new StringBuilder("EXPERIMENT").
                AppendFormat("\t{0}", PauseDuration).
                AppendFormat("\t{0}", UseHoming).
                AppendFormat("\t{0}", TargetActivationDuration).
                AppendFormat("\t{0}", TargetActivation).
                ToString();
        }

        #endregion

        #region Event handlers

        private void PauseTimer_Tick(object aSender, EventArgs aArgs)
        {
            iPauseTimer.Stop();
            StartNextTrial();
        }

        private void TargetActivationTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentTrial.activateNext(sHRTimestamp.Milliseconds - iStartTimestamp))
            {
                OnNextTarget(this, new NextTrialArgs(CurrentTrial));
            }
            else
            {
                iTargetActivationTimer.Stop();
                next();
            }
        }

        #endregion

        #region Internal methods

        public void RandomizeTrialsOrder()
        {
            if (Trials.Count > 1 && Randomize)
            {
                Random rand = new Random();
                for (int i = 0; i < 2 * Trials.Count; i++)
                {
                    int idx1 = rand.Next(Trials.Count);
                    int idx2 = rand.Next(Trials.Count);
                    Trial temp = Trials[idx1];
                    Trials[idx1] = Trials[idx2];
                    Trials[idx2] = temp;
                }
            }
        }

        private void StartNextTrial()
        {
            Trial trial = Trials[iTrialIndex];

            OnNextTrial(this, new NextTrialArgs(trial));

            trial.start(TargetActivation == TargetActivationType.AllAtOnce || trial.Type == Trial.TargetType.Text,
                sHRTimestamp.Milliseconds - iStartTimestamp);

            if (TargetActivation == TargetActivationType.OneByOne && trial.Type != Trial.TargetType.Text)
            {
                OnNextTarget(this, new NextTrialArgs(CurrentTrial));
                iTargetActivationTimer.Start();
            }
        }

        #endregion
    }
}
