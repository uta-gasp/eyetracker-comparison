using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EyeTrackerComparison
{
    public partial class Options : Form
    {
        private List<Views.TrialPanel> iTrialPanels = new List<Views.TrialPanel>();

        public List<Trial> Trials
        {
            get
            {
                List<Trial> result = new List<Trial>();
                foreach (Views.TrialPanel panel in iTrialPanels)
                {
                    result.Add(panel.Trial);
                }
                return result;
            }
            set
            {
                iTrialPanels.Clear();
                tlpTrials.Controls.RemoveByKey("trial");
                tlpTrials.RowCount = 1;

                tlpTrials.SuspendLayout();
                foreach (Trial trial in value)
                {
                    CreateTrialPanel(trial);
                }
                tlpTrials.ResumeLayout();
            }
        }

        public Options()
        {
            InitializeComponent();

            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                cmbFontName.Items.Add(family.Name);
            }
        }

        private void CreateTrialPanel(Trial aTrial)
        {
            Views.TrialPanel panel = new Views.TrialPanel(aTrial);
            panel.DeleteRequest += Panel_DeleteRequest;
            panel.MoveUpRequest += Panel_MoveUpRequest;
            panel.MoveDownRequest += Panel_MoveDownRequest;
            panel.Name = "trial";
            tlpTrials.RowCount++;
            tlpTrials.Controls.Add(panel);
            tlpTrials.SetRow(panel, -1);
            iTrialPanels.Add(panel);
        }

        private void Panel_MoveDownRequest(object aSender, System.EventArgs aArgs)
        {
            for (int i = 0; i < iTrialPanels.Count - 1; i++)
            {
                Views.TrialPanel panel = iTrialPanels[i];
                if (panel == aSender)
                {
                    tlpTrials.Controls.SetChildIndex(panel, tlpTrials.Controls.GetChildIndex(panel) + 1);
                    iTrialPanels[i] = iTrialPanels[i + 1];
                    iTrialPanels[i + 1] = panel;
                    break;
                }
            }
        }

        private void Panel_MoveUpRequest(object aSender, System.EventArgs aArgs)
        {
            for (int i = 1; i < iTrialPanels.Count; i++)
            {
                Views.TrialPanel panel = iTrialPanels[i];
                if (panel == aSender)
                {
                    tlpTrials.Controls.SetChildIndex(panel, tlpTrials.Controls.GetChildIndex(panel) - 1);
                    iTrialPanels[i] = iTrialPanels[i - 1];
                    iTrialPanels[i - 1] = panel;
                    break;
                }
            }
        }

        private void Panel_DeleteRequest(object aSender, System.EventArgs aArgs)
        {
            foreach (Views.TrialPanel panel in iTrialPanels)
            {
                if (panel == aSender)
                {
                    tlpTrials.Controls.Remove(panel);
                    iTrialPanels.Remove(panel);
                    break;
                }
            }
        }

        private void lblTextColor_Click(object sender, System.EventArgs e)
        {
            ColorDialog colors = new ColorDialog();
            colors.Color = lblTextColor.BackColor;
            if (colors.ShowDialog() == DialogResult.OK)
            {
                lblTextColor.BackColor = colors.Color;
            }
        }

        private void btnAddTrial_Click(object sender, System.EventArgs e)
        {
            CreateTrialPanel(new Trial(Size.Empty));
        }
    }
}
