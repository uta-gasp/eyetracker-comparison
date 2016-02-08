using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETUDriver;
using Utils = GazeInSimSpace.Player;

namespace EyeTrackerComparison
{
    public partial class MainForm : Form
    {
        #region Options

        private int iHomeTargetRadius = 10;

        #endregion

        #region Internal members

        private CoETUDriver iETUDriver;
        private GazeProcessor iParser;
        private Experiment iExperiment;
        private Utils.Player iPlayer;

        private TheCodeKing.ActiveButtons.Controls.IActiveMenu iMenu;
        private TheCodeKing.ActiveButtons.Controls.ActiveButton mbnETUDOptions;
        private TheCodeKing.ActiveButtons.Controls.ActiveButton mbnCalibrate;
        private TheCodeKing.ActiveButtons.Controls.ActiveButton mbnToggleTracking;
        private TheCodeKing.ActiveButtons.Controls.ActiveButton mbnOptions;

        #endregion

        #region Public methods

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            iETUDriver = new CoETUDriver();
            iETUDriver.OptionsFile = Application.StartupPath + "\\etudriver.ini";
            iETUDriver.OnRecordingStart += ETUDriver_OnRecordingStart;
            iETUDriver.OnRecordingStop += ETUDriver_OnRecordingStop;
            iETUDriver.OnCalibrated += ETUDriver_OnCalibrated;
            iETUDriver.OnDataEvent += ETUDriver_OnDataEvent;

            SiETUDFloatPoint offset = new SiETUDFloatPoint();
            offset.X = 0;
            offset.Y = 0;
            iETUDriver.set_Offset(ref offset);

            iExperiment = new Experiment();
            iExperiment.OnTrialFinished += Experiment_OnTrialFinished;
            iExperiment.OnNextTrial += Experiment_OnNextTrial;
            iExperiment.OnNextTarget += Experiment_OnNextTarget;
            iExperiment.OnFinished += Experiment_OnFinished;

            CreateMenu();

            iParser = new GazeProcessor();
            //iParser.PointProcessed += Parser_PointProcessed;

            iPlayer = new Utils.WavPlayer();
            iPlayer.init();

            LoadParameters();

            EnabledMenuButtons();
        }

        #endregion

        #region Internal methods

        private void EnabledMenuButtons()
        {
            mbnETUDOptions.Enabled = iETUDriver.DeviceCount > 0 && iETUDriver.Active == 0;
            mbnCalibrate.Enabled = iETUDriver.Ready != 0 && iETUDriver.Active == 0;
            mbnToggleTracking.Enabled = iETUDriver.Ready != 0 && iETUDriver.Calibrated != 0;
            mbnOptions.Enabled = iETUDriver.Active == 0;
        }

        private void CreateMenu()
        {
            iMenu = TheCodeKing.ActiveButtons.Controls.ActiveMenu.GetInstance(this);
            iMenu.Alighment = HorizontalAlignment.Center;

            mbnETUDOptions = new TheCodeKing.ActiveButtons.Controls.ActiveButton();
            mbnETUDOptions.Text = "ETUDriver";
            mbnETUDOptions.Click += (s, e) =>
            {
                iETUDriver.showRecordingOptions();
                EnabledMenuButtons();
            };

            mbnCalibrate = new TheCodeKing.ActiveButtons.Controls.ActiveButton();
            mbnCalibrate.Text = "Calibrate";
            mbnCalibrate.Click += (s, e) =>
            {
                iETUDriver.calibrate();
            };

            mbnToggleTracking = new TheCodeKing.ActiveButtons.Controls.ActiveButton();
            mbnToggleTracking.Text = "Start";
            mbnToggleTracking.Click += (s, e) =>
            {
                if (iETUDriver.Active == 0)
                {
                    SetDisplayMode(true);
                    if (iExperiment.start())
                    {
                        iETUDriver.startTracking();
                    }
                    else
                    {
                        SetDisplayMode(false);
                    }
                }
                else
                {
                    iETUDriver.stopTracking();
                }
            };

            mbnOptions = new TheCodeKing.ActiveButtons.Controls.ActiveButton();
            mbnOptions.Text = "Options";
            mbnOptions.Click += (s, e) =>
            {
                Options options = new Options();
                SetValuesToOptionsDialog(options);
                if (options.ShowDialog() == DialogResult.OK)
                {
                    GetValuesFromOptionsDialog(options);
                }
            };

            iMenu.Items.Add(mbnOptions);
            iMenu.Items.Add(mbnToggleTracking);
            iMenu.Items.Add(mbnCalibrate);
            iMenu.Items.Add(mbnETUDOptions);
        }

        private void SetValuesToOptionsDialog(Options aDialog)
        {
            aDialog.chkHomeTargetBetweenStimuli.Checked = iExperiment.UseHoming;
            aDialog.nudInterStimuliPause.Value = iExperiment.PauseDuration;
            aDialog.nudTargetActivationDuration.Value = iExperiment.TargetActivationDuration;
            aDialog.cmbTargetActivationType.SelectedIndex = (int)iExperiment.TargetActivation;
            aDialog.chkRandomizeTrials.Checked = iExperiment.Randomize;

            aDialog.nudHomeTargetRadius.Value = iHomeTargetRadius;
            aDialog.nudMaxImageSize.Value = Target.MaxImageSize;
            aDialog.cmbFontName.SelectedItem = Target.FontName;
            aDialog.nudFontSize.Value = (decimal)Target.FontSize;
            aDialog.lblTextColor.BackColor = Target.TextColor;
            aDialog.nudLineHeight.Value = (decimal)Target.LineHeight;

            aDialog.Trials = iExperiment.Trials;

            aDialog.nudObjectMaxExtension.Value = iParser.ObjectMaxExtension;
            aDialog.nudMappingDelay.Value = iParser.MappingDelay;
        }

        private void GetValuesFromOptionsDialog(Options aDialog)
        {
            iExperiment.UseHoming = aDialog.chkHomeTargetBetweenStimuli.Checked;
            iExperiment.PauseDuration = (int)aDialog.nudInterStimuliPause.Value;
            iExperiment.TargetActivationDuration = (int)aDialog.nudTargetActivationDuration.Value;
            iExperiment.TargetActivation = (Experiment.TargetActivationType)aDialog.cmbTargetActivationType.SelectedIndex;
            iExperiment.Randomize = aDialog.chkRandomizeTrials.Checked;

            iHomeTargetRadius = (int)aDialog.nudHomeTargetRadius.Value;
            Target.MaxImageSize = (int)aDialog.nudMaxImageSize.Value;
            Target.FontName = (string)aDialog.cmbFontName.SelectedItem;
            Target.FontSize = (float)aDialog.nudFontSize.Value;
            Target.TextColor = aDialog.lblTextColor.BackColor;
            Target.LineHeight = (float)aDialog.nudLineHeight.Value;

            iExperiment.Trials.Clear();
            foreach (Trial trial in aDialog.Trials)
            {
                iExperiment.Trials.Add(trial);
            }

            iParser.ObjectMaxExtension = (int)aDialog.nudObjectMaxExtension.Value;
            iParser.MappingDelay = (int)aDialog.nudMappingDelay.Value;
        }

        private void SetDisplayMode(bool aActive)
        {
            FormBorderStyle = aActive ? FormBorderStyle.None : FormBorderStyle.Sizable;
            if (aActive)
            {
                SetBounds(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
            else
            {
                SetBounds(100, 100, 400, 500);
            }
            //TopMost = aActive;
            iMenu.Visible = !aActive;
        }

        public void SaveParameters()
        {
            Storage storage = new Storage();
            storage.add("UseHoming", iExperiment.UseHoming);
            storage.add("PauseDuration", iExperiment.PauseDuration);
            storage.add("TargetActivationDuration", iExperiment.TargetActivationDuration);
            storage.add("TargetActivation", (int)iExperiment.TargetActivation);
            storage.add("RandomizeTrials", iExperiment.Randomize);

            storage.add("iHomeTargetRadius", iHomeTargetRadius);
            storage.add("MaxImageSize", Target.MaxImageSize);
            storage.add("FontName", Target.FontName);
            storage.add("FontSize", Target.FontSize);
            storage.add("TextColor", Target.TextColor.ToArgb());
            storage.add("LineHeight", Target.LineHeight);

            int trialIndex = 0;
            foreach (Trial trial in iExperiment.Trials)
            {
                storage.add("trial" + trialIndex, trial.toStorage());
                trialIndex++;
            }

            storage.add("ObjectMaxExtension", iParser.ObjectMaxExtension);
            storage.add("MappingDelay", iParser.MappingDelay);

            storage.save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\eyetrackercomp.txt");
        }

        public void LoadParameters()
        {
            Storage storage = new Storage();
            if (!storage.load(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\eyetrackercomp.txt"))
                return;

            iExperiment.UseHoming = storage.get("UseHoming", iExperiment.UseHoming);
            iExperiment.PauseDuration = storage.get("PauseDuration", iExperiment.PauseDuration);
            iExperiment.TargetActivationDuration = storage.get("TargetActivationDuration", iExperiment.TargetActivationDuration);
            iExperiment.TargetActivation = (Experiment.TargetActivationType)storage.get("TargetActivation", (int)iExperiment.TargetActivation);
            iExperiment.Randomize = storage.get("RandomizeTrials", iExperiment.Randomize);

            iHomeTargetRadius = storage.get("iHomeTargetRadius", iHomeTargetRadius);
            Target.MaxImageSize = storage.get("MaxImageSize", Target.MaxImageSize);
            Target.FontName = storage.get("FontName", Target.FontName);
            Target.FontSize = (float)storage.get("FontSize", Target.FontSize);
            Target.TextColor = Color.FromArgb(storage.get("TextColor", Target.TextColor.ToArgb()));
            Target.LineHeight = (float)storage.get("LineHeight", Target.LineHeight);

            int trialIndex = 0;
            iExperiment.Trials.Clear();
            for (;;)
            {
                string text = storage.get("trial" + trialIndex, "");
                if (text.Length == 0)
                    break;

                iExperiment.Trials.Add(Trial.fromStorage(text));
                trialIndex++;
            }

            iParser.ObjectMaxExtension = storage.get("ObjectMaxExtension", iParser.ObjectMaxExtension);
            iParser.MappingDelay = storage.get("MappingDelay", iParser.MappingDelay);
        }

        #endregion

        #region Event handlers

        private void ETUDriver_OnCalibrated()
        {
            EnabledMenuButtons();
        }

        private void ETUDriver_OnRecordingStart()
        {
            iParser.start();

            SiETUDFloatPoint offset = new SiETUDFloatPoint();
            Rectangle r = this.ClientRectangle;
            r = this.RectangleToScreen(r);
            offset.X = r.Left;
            offset.Y = r.Top;
            iETUDriver.set_Offset(ref offset);

            EnabledMenuButtons();
            mbnToggleTracking.Text = "Stop";

            Refresh();
        }

        private void ETUDriver_OnRecordingStop()
        {
            EnabledMenuButtons();
            mbnToggleTracking.Text = "Start";

            iParser.stop();
            iExperiment.stop();

            SetDisplayMode(false);

            Refresh();
        }

        private void ETUDriver_OnDataEvent(EiETUDGazeEvent aEventID, ref int aData, ref int aResult)
        {
            if (aEventID == EiETUDGazeEvent.geSample)
            {
                SiETUDSample smp = iETUDriver.LastSample;
                Point pt = PointToClient(new Point((int)smp.X[0], (int)smp.Y[0]));
                iParser.feed(iExperiment.TimeElapsed, pt);
            }
        }

        private void Experiment_OnTrialFinished(object aSender, EventArgs aArgs)
        {
            iParser.setTrial(null);

            byte[] eeData = ByteOps.toBytes("trial-finished");
            iETUDriver.addExtraEvent(11, 0, ref eeData[0]);

            Refresh();
        }

        private void Experiment_OnNextTrial(object aSender, Experiment.NextTrialArgs aArgs)
        {
            iParser.setTrial(aArgs.Trial);

            byte[] eeData = ByteOps.toBytes("trial-started");
            iETUDriver.addExtraEvent(10, 0, ref eeData[0]);

            Invalidate();
        }

        private void Experiment_OnNextTarget(object aSender, Experiment.NextTrialArgs aArgs)
        {
            iParser.setTrial(aArgs.Trial);

            byte[] eeData = ByteOps.toBytes("target-started");
            iETUDriver.addExtraEvent(20, 0, ref eeData[0]);

            Invalidate();
        }

        private void Experiment_OnFinished(object sender, EventArgs e)
        {
            byte[] eeData = ByteOps.toBytes("exp-finished");
            iETUDriver.addExtraEvent(5, 0, ref eeData[0]);

            iETUDriver.stopTracking();

        askFileName:
            if (sfdSaveData.ShowDialog() == DialogResult.OK)
            {
                string header = new StringBuilder().
                    Append(iParser).
                    AppendLine().
                    Append(iExperiment).
                    ToString();
                if (!iExperiment.save(sfdSaveData.FileName, header))
                {
                    goto askFileName;
                }
            }
        }

        private void Parser_PointProcessed(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion

        #region GUI event handlers

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (iETUDriver.Active != 0)
            {
                e.Cancel = true;
            }
            else
            {
                SaveParameters();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                iExperiment.next();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (!iExperiment.Active)
            {
                int resultOffsetY = 0;
                Font font = new Font("Arial", 16.0f);
                foreach (Trial trial in iExperiment.Trials)
                {
                    if (trial.Result.Valid)
                    {
                        string result = trial.Result.ToString();
                        e.Graphics.DrawString(result, font, Brushes.Black, 20, 20 + resultOffsetY);
                        resultOffsetY += 28 * result.Split('\n').Length;
                    }
                }
            }

            if (iExperiment.Active && iExperiment.CurrentTrial == null)
            {
                int x = ClientSize.Width / 2;
                int y = ClientSize.Height / 2;
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(x - iHomeTargetRadius, y - iHomeTargetRadius, 2 * iHomeTargetRadius, 2 * iHomeTargetRadius));
            }

            if (iExperiment.Active && iExperiment.CurrentTrial != null)
            {
                foreach (Target target in iExperiment.CurrentTrial.Targets)
                {
                    e.Graphics.DrawImage(target.Image, target.Location);

                    /*foreach (GazeArea area in target.Areas)
                    {
                        e.Graphics.DrawRectangle(Pens.Blue, area.Rect);
                    }*/
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion
    }
}
