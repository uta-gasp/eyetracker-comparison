using System;
using System.Drawing;
using System.Windows.Forms;

namespace EyeTrackerComparison.Views
{
    public partial class TrialPanel : UserControl
    {
        #region Internal members

        private Size iDisplaySize;

        #endregion

        #region Events

        public event EventHandler DeleteRequest = delegate { };
        public event EventHandler MoveUpRequest = delegate { };
        public event EventHandler MoveDownRequest = delegate { };

        #endregion

        #region Public methods

        public Trial Trial
        {
            get
            {
                Trial trial;
                switch (cmbType.SelectedIndex)
                {
                    case 0:
                        trial = new Trial(iDisplaySize, (int)nudColumns.Value, (int)nudRows.Value, 
                            cmbImages.SelectedIndex == 0 ? "" : cmbImages.SelectedItem.ToString());
                        break;
                    case 1:
                        trial = new Trial(iDisplaySize, txbText.Lines);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("TrialPanel.cmbType", cmbType.SelectedIndex, "No target creation implementation for this type");
                }
                return trial;
            }
        }

        public TrialPanel(Trial aTrial)
        {
            InitializeComponent();

            iDisplaySize = Screen.PrimaryScreen.Bounds.Size;

            cmbImages.Items.Add("any");
            cmbImages.Items.AddRange(Target.imageNames());
    
            cmbType.SelectedIndex = (int)aTrial.Type;
            switch (aTrial.Type)
            {
                case Trial.TargetType.Images:
                    nudColumns.Value = aTrial.ColCount;
                    nudRows.Value = aTrial.RowCount;
                    if (aTrial.Data[0].Length > 1)
                        cmbImages.SelectedItem = aTrial.Data;
                    else
                        cmbImages.SelectedIndex = 0;
                    break;

                case Trial.TargetType.Text:
                    txbText.Lines = aTrial.Data;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("TrialPanel()", aTrial.Type, "No target creation implementation for this type");
            }
        }

        #endregion

        #region Event handlers

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudColumns.Visible = cmbType.SelectedIndex == 0;
            nudRows.Visible = cmbType.SelectedIndex == 0;
            lblBy.Visible = cmbType.SelectedIndex == 0;
            lblOf.Visible = cmbType.SelectedIndex == 0;
            cmbImages.Visible = cmbType.SelectedIndex == 0;

            txbText.Visible = cmbType.SelectedIndex == 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteRequest(this, new EventArgs());
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveUpRequest(this, new EventArgs());
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveDownRequest(this, new EventArgs());
        }

        #endregion
    }
}
