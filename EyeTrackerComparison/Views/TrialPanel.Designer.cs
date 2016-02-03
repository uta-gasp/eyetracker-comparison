namespace EyeTrackerComparison.Views
{
    partial class TrialPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrialPanel));
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txbText = new System.Windows.Forms.TextBox();
            this.nudColumns = new System.Windows.Forms.NumericUpDown();
            this.lblBy = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.lblOf = new System.Windows.Forms.Label();
            this.cmbImages = new System.Windows.Forms.ComboBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "images",
            "text"});
            this.cmbType.Location = new System.Drawing.Point(3, 3);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(142, 21);
            this.cmbType.TabIndex = 0;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(262, 1);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txbText
            // 
            this.txbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbText.Location = new System.Drawing.Point(3, 30);
            this.txbText.Multiline = true;
            this.txbText.Name = "txbText";
            this.txbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbText.Size = new System.Drawing.Size(283, 37);
            this.txbText.TabIndex = 2;
            // 
            // nudColumns
            // 
            this.nudColumns.Location = new System.Drawing.Point(3, 31);
            this.nudColumns.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(59, 20);
            this.nudColumns.TabIndex = 3;
            this.nudColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBy
            // 
            this.lblBy.AutoSize = true;
            this.lblBy.Location = new System.Drawing.Point(68, 33);
            this.lblBy.Name = "lblBy";
            this.lblBy.Size = new System.Drawing.Size(12, 13);
            this.lblBy.TabIndex = 4;
            this.lblBy.Text = "x";
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(86, 31);
            this.nudRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(59, 20);
            this.nudRows.TabIndex = 3;
            this.nudRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblOf
            // 
            this.lblOf.AutoSize = true;
            this.lblOf.Location = new System.Drawing.Point(151, 33);
            this.lblOf.Name = "lblOf";
            this.lblOf.Size = new System.Drawing.Size(16, 13);
            this.lblOf.TabIndex = 4;
            this.lblOf.Text = "of";
            // 
            // cmbImages
            // 
            this.cmbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImages.FormattingEnabled = true;
            this.cmbImages.Location = new System.Drawing.Point(173, 30);
            this.cmbImages.Name = "cmbImages";
            this.cmbImages.Size = new System.Drawing.Size(117, 21);
            this.cmbImages.TabIndex = 5;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(232, 1);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 23);
            this.btnDown.TabIndex = 1;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(202, 1);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // TrialPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.cmbImages);
            this.Controls.Add(this.lblOf);
            this.Controls.Add(this.lblBy);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.nudColumns);
            this.Controls.Add(this.txbText);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cmbType);
            this.Name = "TrialPanel";
            this.Size = new System.Drawing.Size(289, 70);
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txbText;
        private System.Windows.Forms.NumericUpDown nudColumns;
        private System.Windows.Forms.Label lblBy;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.Label lblOf;
        private System.Windows.Forms.ComboBox cmbImages;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
    }
}
