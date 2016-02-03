namespace EyeTrackerComparison
{
    partial class Options
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbcOptions = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.nudTargetActivationDuration = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTargetActivationType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudInterStimuliPause = new System.Windows.Forms.NumericUpDown();
            this.chkHomeTargetBetweenStimuli = new System.Windows.Forms.CheckBox();
            this.chkRandomizeTrials = new System.Windows.Forms.CheckBox();
            this.tbpTrials = new System.Windows.Forms.TabPage();
            this.btnAddTrial = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHomeTargetRadius = new System.Windows.Forms.NumericUpDown();
            this.nudMaxImageSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFontName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudLineHeight = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudObjectMaxExtension = new System.Windows.Forms.NumericUpDown();
            this.nudMappingDelay = new System.Windows.Forms.NumericUpDown();
            this.tlpTrials = new System.Windows.Forms.TableLayoutPanel();
            this.tbcOptions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetActivationDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterStimuliPause)).BeginInit();
            this.tbpTrials.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeTargetRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxImageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineHeight)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudObjectMaxExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMappingDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(104, 362);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(185, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbcOptions
            // 
            this.tbcOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcOptions.Controls.Add(this.tabPage1);
            this.tbcOptions.Controls.Add(this.tbpTrials);
            this.tbcOptions.Controls.Add(this.tabPage2);
            this.tbcOptions.Controls.Add(this.tabPage3);
            this.tbcOptions.Location = new System.Drawing.Point(12, 12);
            this.tbcOptions.Name = "tbcOptions";
            this.tbcOptions.SelectedIndex = 0;
            this.tbcOptions.Size = new System.Drawing.Size(327, 344);
            this.tbcOptions.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(306, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Experiment";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudTargetActivationDuration, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbTargetActivationType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudInterStimuliPause, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkHomeTargetBetweenStimuli, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkRandomizeTrials, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Target activation duration, ms";
            // 
            // nudTargetActivationDuration
            // 
            this.nudTargetActivationDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTargetActivationDuration.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTargetActivationDuration.Location = new System.Drawing.Point(179, 57);
            this.nudTargetActivationDuration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTargetActivationDuration.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudTargetActivationDuration.Name = "nudTargetActivationDuration";
            this.nudTargetActivationDuration.Size = new System.Drawing.Size(112, 20);
            this.nudTargetActivationDuration.TabIndex = 1;
            this.nudTargetActivationDuration.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Target activation type";
            // 
            // cmbTargetActivationType
            // 
            this.cmbTargetActivationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTargetActivationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetActivationType.FormattingEnabled = true;
            this.cmbTargetActivationType.Items.AddRange(new object[] {
            "all at once",
            "one by one"});
            this.cmbTargetActivationType.Location = new System.Drawing.Point(179, 84);
            this.cmbTargetActivationType.Name = "cmbTargetActivationType";
            this.cmbTargetActivationType.Size = new System.Drawing.Size(112, 21);
            this.cmbTargetActivationType.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Inter-stimuli pause, ms";
            // 
            // nudInterStimuliPause
            // 
            this.nudInterStimuliPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudInterStimuliPause.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudInterStimuliPause.Location = new System.Drawing.Point(179, 30);
            this.nudInterStimuliPause.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudInterStimuliPause.Name = "nudInterStimuliPause";
            this.nudInterStimuliPause.Size = new System.Drawing.Size(112, 20);
            this.nudInterStimuliPause.TabIndex = 1;
            this.nudInterStimuliPause.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkHomeTargetBetweenStimuli
            // 
            this.chkHomeTargetBetweenStimuli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHomeTargetBetweenStimuli.AutoSize = true;
            this.chkHomeTargetBetweenStimuli.Location = new System.Drawing.Point(3, 5);
            this.chkHomeTargetBetweenStimuli.Name = "chkHomeTargetBetweenStimuli";
            this.chkHomeTargetBetweenStimuli.Size = new System.Drawing.Size(170, 17);
            this.chkHomeTargetBetweenStimuli.TabIndex = 2;
            this.chkHomeTargetBetweenStimuli.Text = "Home target";
            this.chkHomeTargetBetweenStimuli.UseVisualStyleBackColor = true;
            // 
            // chkRandomizeTrials
            // 
            this.chkRandomizeTrials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRandomizeTrials.AutoSize = true;
            this.chkRandomizeTrials.Location = new System.Drawing.Point(3, 113);
            this.chkRandomizeTrials.Name = "chkRandomizeTrials";
            this.chkRandomizeTrials.Size = new System.Drawing.Size(170, 17);
            this.chkRandomizeTrials.TabIndex = 2;
            this.chkRandomizeTrials.Text = "Randomize trials";
            this.chkRandomizeTrials.UseVisualStyleBackColor = true;
            // 
            // tbpTrials
            // 
            this.tbpTrials.Controls.Add(this.tlpTrials);
            this.tbpTrials.Controls.Add(this.btnAddTrial);
            this.tbpTrials.Location = new System.Drawing.Point(4, 22);
            this.tbpTrials.Name = "tbpTrials";
            this.tbpTrials.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTrials.Size = new System.Drawing.Size(319, 318);
            this.tbpTrials.TabIndex = 2;
            this.tbpTrials.Text = "Trials";
            this.tbpTrials.UseVisualStyleBackColor = true;
            // 
            // btnAddTrial
            // 
            this.btnAddTrial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddTrial.Location = new System.Drawing.Point(3, 292);
            this.btnAddTrial.Name = "btnAddTrial";
            this.btnAddTrial.Size = new System.Drawing.Size(313, 23);
            this.btnAddTrial.TabIndex = 0;
            this.btnAddTrial.Text = "Add";
            this.btnAddTrial.UseVisualStyleBackColor = true;
            this.btnAddTrial.Click += new System.EventHandler(this.btnAddTrial_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(306, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appearance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudHomeTargetRadius, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudMaxImageSize, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbFontName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.nudFontSize, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblTextColor, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.nudLineHeight, 1, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 306);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Max image size, px";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Home target radius, px";
            // 
            // nudHomeTargetRadius
            // 
            this.nudHomeTargetRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudHomeTargetRadius.Location = new System.Drawing.Point(150, 3);
            this.nudHomeTargetRadius.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudHomeTargetRadius.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHomeTargetRadius.Name = "nudHomeTargetRadius";
            this.nudHomeTargetRadius.Size = new System.Drawing.Size(141, 20);
            this.nudHomeTargetRadius.TabIndex = 1;
            this.nudHomeTargetRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudMaxImageSize
            // 
            this.nudMaxImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxImageSize.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMaxImageSize.Location = new System.Drawing.Point(150, 30);
            this.nudMaxImageSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudMaxImageSize.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudMaxImageSize.Name = "nudMaxImageSize";
            this.nudMaxImageSize.Size = new System.Drawing.Size(141, 20);
            this.nudMaxImageSize.TabIndex = 3;
            this.nudMaxImageSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Font family";
            // 
            // cmbFontName
            // 
            this.cmbFontName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontName.FormattingEnabled = true;
            this.cmbFontName.Location = new System.Drawing.Point(150, 57);
            this.cmbFontName.Name = "cmbFontName";
            this.cmbFontName.Size = new System.Drawing.Size(141, 21);
            this.cmbFontName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Font size";
            // 
            // nudFontSize
            // 
            this.nudFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFontSize.Location = new System.Drawing.Point(150, 84);
            this.nudFontSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(141, 20);
            this.nudFontSize.TabIndex = 3;
            this.nudFontSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Text color";
            // 
            // lblTextColor
            // 
            this.lblTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Location = new System.Drawing.Point(150, 115);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(141, 13);
            this.lblTextColor.TabIndex = 2;
            this.lblTextColor.Click += new System.EventHandler(this.lblTextColor_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Line height";
            // 
            // nudLineHeight
            // 
            this.nudLineHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudLineHeight.DecimalPlaces = 1;
            this.nudLineHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudLineHeight.Location = new System.Drawing.Point(150, 138);
            this.nudLineHeight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLineHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineHeight.Name = "nudLineHeight";
            this.nudLineHeight.Size = new System.Drawing.Size(141, 20);
            this.nudLineHeight.TabIndex = 3;
            this.nudLineHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(306, 318);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Processing";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.nudObjectMaxExtension, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.nudMappingDelay, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(294, 306);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mapping delay., ms";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Object max extension, px";
            // 
            // nudObjectMaxExtension
            // 
            this.nudObjectMaxExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudObjectMaxExtension.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudObjectMaxExtension.Location = new System.Drawing.Point(150, 3);
            this.nudObjectMaxExtension.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudObjectMaxExtension.Name = "nudObjectMaxExtension";
            this.nudObjectMaxExtension.Size = new System.Drawing.Size(141, 20);
            this.nudObjectMaxExtension.TabIndex = 1;
            this.nudObjectMaxExtension.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudMappingDelay
            // 
            this.nudMappingDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMappingDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMappingDelay.Location = new System.Drawing.Point(150, 30);
            this.nudMappingDelay.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudMappingDelay.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudMappingDelay.Name = "nudMappingDelay";
            this.nudMappingDelay.Size = new System.Drawing.Size(141, 20);
            this.nudMappingDelay.TabIndex = 3;
            this.nudMappingDelay.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // tlpTrials
            // 
            this.tlpTrials.AutoScroll = true;
            this.tlpTrials.ColumnCount = 1;
            this.tlpTrials.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrials.Location = new System.Drawing.Point(3, 3);
            this.tlpTrials.Name = "tlpTrials";
            this.tlpTrials.RowCount = 1;
            this.tlpTrials.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTrials.Size = new System.Drawing.Size(313, 289);
            this.tlpTrials.TabIndex = 3;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(351, 397);
            this.Controls.Add(this.tbcOptions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.tbcOptions.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetActivationDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterStimuliPause)).EndInit();
            this.tbpTrials.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeTargetRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxImageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineHeight)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudObjectMaxExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMappingDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tbcOptions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nudHomeTargetRadius;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown nudMaxImageSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown nudLineHeight;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown nudInterStimuliPause;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.NumericUpDown nudTargetActivationDuration;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cmbFontName;
        public System.Windows.Forms.Label lblTextColor;
        public System.Windows.Forms.CheckBox chkHomeTargetBetweenStimuli;
        public System.Windows.Forms.ComboBox cmbTargetActivationType;
        private System.Windows.Forms.TabPage tbpTrials;
        private System.Windows.Forms.Button btnAddTrial;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.NumericUpDown nudObjectMaxExtension;
        public System.Windows.Forms.NumericUpDown nudMappingDelay;
        public System.Windows.Forms.CheckBox chkRandomizeTrials;
        private System.Windows.Forms.TableLayoutPanel tlpTrials;
    }
}