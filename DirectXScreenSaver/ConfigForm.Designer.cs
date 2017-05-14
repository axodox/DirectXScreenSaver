namespace DirectXScreenSaver
{
    partial class ConfigForm
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
            System.Windows.Forms.Label LFPS;
            System.Windows.Forms.Label LParticleCount;
            System.Windows.Forms.Label LStartVelocity;
            System.Windows.Forms.Label LParticleSize;
            System.Windows.Forms.Label LParticleMaxAcc;
            System.Windows.Forms.Label LParticleGravity;
            System.Windows.Forms.Label LParticleClipSize;
            System.Windows.Forms.Label LParticleColors;
            System.Windows.Forms.Label LParticleControlCount;
            System.Windows.Forms.Label LParticleControlMoveInterval;
            System.Windows.Forms.Label LParticleControlMoveMaxStep;
            System.Windows.Forms.Label LFadeInterval;
            System.Windows.Forms.Label LFadeSpeed;
            System.Windows.Forms.NumericUpDown NUDFadeSpeed;
            System.Windows.Forms.NumericUpDown NUDFadeInterval;
            System.Windows.Forms.NumericUpDown NUDFPS;
            System.Windows.Forms.NumericUpDown NUDParticleControlMoveMaxStep;
            System.Windows.Forms.NumericUpDown NUDParticleControlMoveInterval;
            System.Windows.Forms.NumericUpDown NUDParticleControlCount;
            System.Windows.Forms.NumericUpDown NUDParticleColors;
            System.Windows.Forms.NumericUpDown NUDParticleClipSize;
            System.Windows.Forms.NumericUpDown NUDParticleGravity;
            System.Windows.Forms.NumericUpDown NUDParticleMaxAcc;
            System.Windows.Forms.NumericUpDown NUDParticleSize;
            System.Windows.Forms.NumericUpDown NUDStartVelocity;
            System.Windows.Forms.NumericUpDown NUDParticleCount;
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TPMain = new System.Windows.Forms.TabPage();
            this.TPParticles = new System.Windows.Forms.TabPage();
            this.BDefault = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.BOk = new System.Windows.Forms.Button();
            this.TPInfoHUD = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.BInfoHUDOptions = new System.Windows.Forms.Button();
            LFPS = new System.Windows.Forms.Label();
            LParticleCount = new System.Windows.Forms.Label();
            LStartVelocity = new System.Windows.Forms.Label();
            LParticleSize = new System.Windows.Forms.Label();
            LParticleMaxAcc = new System.Windows.Forms.Label();
            LParticleGravity = new System.Windows.Forms.Label();
            LParticleClipSize = new System.Windows.Forms.Label();
            LParticleColors = new System.Windows.Forms.Label();
            LParticleControlCount = new System.Windows.Forms.Label();
            LParticleControlMoveInterval = new System.Windows.Forms.Label();
            LParticleControlMoveMaxStep = new System.Windows.Forms.Label();
            LFadeInterval = new System.Windows.Forms.Label();
            LFadeSpeed = new System.Windows.Forms.Label();
            NUDFadeSpeed = new System.Windows.Forms.NumericUpDown();
            NUDFadeInterval = new System.Windows.Forms.NumericUpDown();
            NUDFPS = new System.Windows.Forms.NumericUpDown();
            NUDParticleControlMoveMaxStep = new System.Windows.Forms.NumericUpDown();
            NUDParticleControlMoveInterval = new System.Windows.Forms.NumericUpDown();
            NUDParticleControlCount = new System.Windows.Forms.NumericUpDown();
            NUDParticleColors = new System.Windows.Forms.NumericUpDown();
            NUDParticleClipSize = new System.Windows.Forms.NumericUpDown();
            NUDParticleGravity = new System.Windows.Forms.NumericUpDown();
            NUDParticleMaxAcc = new System.Windows.Forms.NumericUpDown();
            NUDParticleSize = new System.Windows.Forms.NumericUpDown();
            NUDStartVelocity = new System.Windows.Forms.NumericUpDown();
            NUDParticleCount = new System.Windows.Forms.NumericUpDown();
            this.TCMain.SuspendLayout();
            this.TPMain.SuspendLayout();
            this.TPParticles.SuspendLayout();
            this.TPInfoHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(NUDFadeSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDFadeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleControlMoveMaxStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleControlMoveInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleControlCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleClipSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleGravity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleMaxAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDStartVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleCount)).BeginInit();
            this.SuspendLayout();
            // 
            // LFPS
            // 
            LFPS.AutoSize = true;
            LFPS.Location = new System.Drawing.Point(4, 8);
            LFPS.Name = "LFPS";
            LFPS.Size = new System.Drawing.Size(61, 13);
            LFPS.TabIndex = 1;
            LFPS.Text = "Target FPS";
            // 
            // LParticleCount
            // 
            LParticleCount.AutoSize = true;
            LParticleCount.Location = new System.Drawing.Point(4, 8);
            LParticleCount.Name = "LParticleCount";
            LParticleCount.Size = new System.Drawing.Size(72, 13);
            LParticleCount.TabIndex = 3;
            LParticleCount.Text = "Particle count";
            // 
            // LStartVelocity
            // 
            LStartVelocity.AutoSize = true;
            LStartVelocity.Location = new System.Drawing.Point(4, 86);
            LStartVelocity.Name = "LStartVelocity";
            LStartVelocity.Size = new System.Drawing.Size(68, 13);
            LStartVelocity.TabIndex = 5;
            LStartVelocity.Text = "Start velocity";
            // 
            // LParticleSize
            // 
            LParticleSize.AutoSize = true;
            LParticleSize.Location = new System.Drawing.Point(4, 60);
            LParticleSize.Name = "LParticleSize";
            LParticleSize.Size = new System.Drawing.Size(47, 13);
            LParticleSize.TabIndex = 7;
            LParticleSize.Text = "Size (px)";
            // 
            // LParticleMaxAcc
            // 
            LParticleMaxAcc.AutoSize = true;
            LParticleMaxAcc.Location = new System.Drawing.Point(4, 112);
            LParticleMaxAcc.Name = "LParticleMaxAcc";
            LParticleMaxAcc.Size = new System.Drawing.Size(82, 13);
            LParticleMaxAcc.TabIndex = 9;
            LParticleMaxAcc.Text = "Max accelration";
            // 
            // LParticleGravity
            // 
            LParticleGravity.AutoSize = true;
            LParticleGravity.Location = new System.Drawing.Point(158, 34);
            LParticleGravity.Name = "LParticleGravity";
            LParticleGravity.Size = new System.Drawing.Size(40, 13);
            LParticleGravity.TabIndex = 11;
            LParticleGravity.Text = "Gravity";
            // 
            // LParticleClipSize
            // 
            LParticleClipSize.AutoSize = true;
            LParticleClipSize.Location = new System.Drawing.Point(4, 138);
            LParticleClipSize.Name = "LParticleClipSize";
            LParticleClipSize.Size = new System.Drawing.Size(65, 13);
            LParticleClipSize.TabIndex = 13;
            LParticleClipSize.Text = "Clip size (px)";
            // 
            // LParticleColors
            // 
            LParticleColors.AutoSize = true;
            LParticleColors.Location = new System.Drawing.Point(4, 34);
            LParticleColors.Name = "LParticleColors";
            LParticleColors.Size = new System.Drawing.Size(36, 13);
            LParticleColors.TabIndex = 15;
            LParticleColors.Text = "Colors";
            // 
            // LParticleControlCount
            // 
            LParticleControlCount.AutoSize = true;
            LParticleControlCount.Location = new System.Drawing.Point(158, 8);
            LParticleControlCount.Name = "LParticleControlCount";
            LParticleControlCount.Size = new System.Drawing.Size(71, 13);
            LParticleControlCount.TabIndex = 17;
            LParticleControlCount.Text = "Control points";
            // 
            // LParticleControlMoveInterval
            // 
            LParticleControlMoveInterval.AutoSize = true;
            LParticleControlMoveInterval.Location = new System.Drawing.Point(158, 60);
            LParticleControlMoveInterval.Name = "LParticleControlMoveInterval";
            LParticleControlMoveInterval.Size = new System.Drawing.Size(165, 13);
            LParticleControlMoveInterval.TabIndex = 19;
            LParticleControlMoveInterval.Text = "Particle control move interval (ms)";
            // 
            // LParticleControlMoveMaxStep
            // 
            LParticleControlMoveMaxStep.AutoSize = true;
            LParticleControlMoveMaxStep.Location = new System.Drawing.Point(158, 86);
            LParticleControlMoveMaxStep.Name = "LParticleControlMoveMaxStep";
            LParticleControlMoveMaxStep.Size = new System.Drawing.Size(134, 13);
            LParticleControlMoveMaxStep.TabIndex = 21;
            LParticleControlMoveMaxStep.Text = "Control move max step (px)";
            // 
            // LFadeInterval
            // 
            LFadeInterval.AutoSize = true;
            LFadeInterval.Location = new System.Drawing.Point(4, 34);
            LFadeInterval.Name = "LFadeInterval";
            LFadeInterval.Size = new System.Drawing.Size(82, 13);
            LFadeInterval.TabIndex = 3;
            LFadeInterval.Text = "Fade interval (s)";
            // 
            // LFadeSpeed
            // 
            LFadeSpeed.AutoSize = true;
            LFadeSpeed.Location = new System.Drawing.Point(4, 60);
            LFadeSpeed.Name = "LFadeSpeed";
            LFadeSpeed.Size = new System.Drawing.Size(63, 13);
            LFadeSpeed.TabIndex = 5;
            LFadeSpeed.Text = "Fade speed";
            // 
            // TCMain
            // 
            this.TCMain.Controls.Add(this.TPMain);
            this.TCMain.Controls.Add(this.TPParticles);
            this.TCMain.Controls.Add(this.TPInfoHUD);
            this.TCMain.Location = new System.Drawing.Point(2, 2);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(395, 189);
            this.TCMain.TabIndex = 0;
            // 
            // TPMain
            // 
            this.TPMain.Controls.Add(LFadeSpeed);
            this.TPMain.Controls.Add(NUDFadeSpeed);
            this.TPMain.Controls.Add(LFadeInterval);
            this.TPMain.Controls.Add(NUDFadeInterval);
            this.TPMain.Controls.Add(LFPS);
            this.TPMain.Controls.Add(NUDFPS);
            this.TPMain.Location = new System.Drawing.Point(4, 22);
            this.TPMain.Name = "TPMain";
            this.TPMain.Padding = new System.Windows.Forms.Padding(3);
            this.TPMain.Size = new System.Drawing.Size(387, 163);
            this.TPMain.TabIndex = 1;
            this.TPMain.Text = "Main";
            this.TPMain.UseVisualStyleBackColor = true;
            // 
            // TPParticles
            // 
            this.TPParticles.Controls.Add(LParticleControlMoveMaxStep);
            this.TPParticles.Controls.Add(LParticleControlMoveInterval);
            this.TPParticles.Controls.Add(LParticleControlCount);
            this.TPParticles.Controls.Add(LParticleColors);
            this.TPParticles.Controls.Add(LParticleClipSize);
            this.TPParticles.Controls.Add(LParticleGravity);
            this.TPParticles.Controls.Add(LParticleMaxAcc);
            this.TPParticles.Controls.Add(LParticleSize);
            this.TPParticles.Controls.Add(LStartVelocity);
            this.TPParticles.Controls.Add(LParticleCount);
            this.TPParticles.Controls.Add(NUDParticleControlMoveMaxStep);
            this.TPParticles.Controls.Add(NUDParticleControlMoveInterval);
            this.TPParticles.Controls.Add(NUDParticleControlCount);
            this.TPParticles.Controls.Add(NUDParticleColors);
            this.TPParticles.Controls.Add(NUDParticleClipSize);
            this.TPParticles.Controls.Add(NUDParticleGravity);
            this.TPParticles.Controls.Add(NUDParticleMaxAcc);
            this.TPParticles.Controls.Add(NUDParticleSize);
            this.TPParticles.Controls.Add(NUDStartVelocity);
            this.TPParticles.Controls.Add(NUDParticleCount);
            this.TPParticles.Location = new System.Drawing.Point(4, 22);
            this.TPParticles.Name = "TPParticles";
            this.TPParticles.Padding = new System.Windows.Forms.Padding(3);
            this.TPParticles.Size = new System.Drawing.Size(387, 163);
            this.TPParticles.TabIndex = 0;
            this.TPParticles.Text = "Particles";
            this.TPParticles.UseVisualStyleBackColor = true;
            // 
            // BDefault
            // 
            this.BDefault.Location = new System.Drawing.Point(6, 193);
            this.BDefault.Name = "BDefault";
            this.BDefault.Size = new System.Drawing.Size(75, 23);
            this.BDefault.TabIndex = 1;
            this.BDefault.Text = "Default";
            this.BDefault.UseVisualStyleBackColor = true;
            this.BDefault.Click += new System.EventHandler(this.BDefault_Click);
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(237, 193);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(75, 23);
            this.BCancel.TabIndex = 2;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // BOk
            // 
            this.BOk.Location = new System.Drawing.Point(318, 193);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(75, 23);
            this.BOk.TabIndex = 3;
            this.BOk.Text = "Ok";
            this.BOk.UseVisualStyleBackColor = true;
            this.BOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // TPInfoHUD
            // 
            this.TPInfoHUD.Controls.Add(this.BInfoHUDOptions);
            this.TPInfoHUD.Controls.Add(this.label1);
            this.TPInfoHUD.Location = new System.Drawing.Point(4, 22);
            this.TPInfoHUD.Name = "TPInfoHUD";
            this.TPInfoHUD.Padding = new System.Windows.Forms.Padding(3);
            this.TPInfoHUD.Size = new System.Drawing.Size(387, 163);
            this.TPInfoHUD.TabIndex = 2;
            this.TPInfoHUD.Text = "InfoHUD";
            this.TPInfoHUD.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "InfoHUD is a tool which can display various informations about the computer to ma" +
                "ke the screensaver useful not just beautiful.";
            // 
            // BInfoHUDOptions
            // 
            this.BInfoHUDOptions.Location = new System.Drawing.Point(9, 45);
            this.BInfoHUDOptions.Name = "BInfoHUDOptions";
            this.BInfoHUDOptions.Size = new System.Drawing.Size(98, 23);
            this.BInfoHUDOptions.TabIndex = 1;
            this.BInfoHUDOptions.Text = "InfoHUD options";
            this.BInfoHUDOptions.UseVisualStyleBackColor = true;
            this.BInfoHUDOptions.Click += new System.EventHandler(this.BInfoHUDOptions_Click);
            // 
            // NUDFadeSpeed
            // 
            NUDFadeSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "FadeSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDFadeSpeed.Location = new System.Drawing.Point(92, 58);
            NUDFadeSpeed.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            NUDFadeSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDFadeSpeed.Name = "NUDFadeSpeed";
            NUDFadeSpeed.Size = new System.Drawing.Size(51, 20);
            NUDFadeSpeed.TabIndex = 4;
            NUDFadeSpeed.Value = global::DirectXScreenSaver.Properties.Settings.Default.FadeSpeed;
            // 
            // NUDFadeInterval
            // 
            NUDFadeInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "FadeOutInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDFadeInterval.Location = new System.Drawing.Point(92, 32);
            NUDFadeInterval.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            NUDFadeInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            NUDFadeInterval.Name = "NUDFadeInterval";
            NUDFadeInterval.Size = new System.Drawing.Size(51, 20);
            NUDFadeInterval.TabIndex = 2;
            NUDFadeInterval.Value = global::DirectXScreenSaver.Properties.Settings.Default.FadeOutInterval;
            // 
            // NUDFPS
            // 
            NUDFPS.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "FPS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDFPS.Location = new System.Drawing.Point(92, 6);
            NUDFPS.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            NUDFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDFPS.Name = "NUDFPS";
            NUDFPS.Size = new System.Drawing.Size(51, 20);
            NUDFPS.TabIndex = 0;
            NUDFPS.Value = global::DirectXScreenSaver.Properties.Settings.Default.FPS;
            // 
            // NUDParticleControlMoveMaxStep
            // 
            NUDParticleControlMoveMaxStep.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleControlMoveMaxStep", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleControlMoveMaxStep.Location = new System.Drawing.Point(329, 84);
            NUDParticleControlMoveMaxStep.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            NUDParticleControlMoveMaxStep.Name = "NUDParticleControlMoveMaxStep";
            NUDParticleControlMoveMaxStep.Size = new System.Drawing.Size(51, 20);
            NUDParticleControlMoveMaxStep.TabIndex = 20;
            NUDParticleControlMoveMaxStep.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleControlMoveMaxStep;
            // 
            // NUDParticleControlMoveInterval
            // 
            NUDParticleControlMoveInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleControlMoveInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleControlMoveInterval.Location = new System.Drawing.Point(329, 58);
            NUDParticleControlMoveInterval.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            NUDParticleControlMoveInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            NUDParticleControlMoveInterval.Name = "NUDParticleControlMoveInterval";
            NUDParticleControlMoveInterval.Size = new System.Drawing.Size(51, 20);
            NUDParticleControlMoveInterval.TabIndex = 18;
            NUDParticleControlMoveInterval.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleControlMoveInterval;
            // 
            // NUDParticleControlCount
            // 
            NUDParticleControlCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleControlCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleControlCount.Location = new System.Drawing.Point(329, 6);
            NUDParticleControlCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            NUDParticleControlCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDParticleControlCount.Name = "NUDParticleControlCount";
            NUDParticleControlCount.Size = new System.Drawing.Size(51, 20);
            NUDParticleControlCount.TabIndex = 16;
            NUDParticleControlCount.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleControlCount;
            // 
            // NUDParticleColors
            // 
            NUDParticleColors.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleColors", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleColors.Location = new System.Drawing.Point(92, 32);
            NUDParticleColors.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            NUDParticleColors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDParticleColors.Name = "NUDParticleColors";
            NUDParticleColors.Size = new System.Drawing.Size(51, 20);
            NUDParticleColors.TabIndex = 14;
            NUDParticleColors.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleColors;
            // 
            // NUDParticleClipSize
            // 
            NUDParticleClipSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleClipSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleClipSize.Location = new System.Drawing.Point(92, 136);
            NUDParticleClipSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            NUDParticleClipSize.Name = "NUDParticleClipSize";
            NUDParticleClipSize.Size = new System.Drawing.Size(51, 20);
            NUDParticleClipSize.TabIndex = 12;
            NUDParticleClipSize.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleClipSize;
            // 
            // NUDParticleGravity
            // 
            NUDParticleGravity.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleGravity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleGravity.Location = new System.Drawing.Point(329, 32);
            NUDParticleGravity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            NUDParticleGravity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDParticleGravity.Name = "NUDParticleGravity";
            NUDParticleGravity.Size = new System.Drawing.Size(51, 20);
            NUDParticleGravity.TabIndex = 10;
            NUDParticleGravity.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleGravity;
            // 
            // NUDParticleMaxAcc
            // 
            NUDParticleMaxAcc.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleMaxAccelration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleMaxAcc.Location = new System.Drawing.Point(92, 110);
            NUDParticleMaxAcc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDParticleMaxAcc.Name = "NUDParticleMaxAcc";
            NUDParticleMaxAcc.Size = new System.Drawing.Size(51, 20);
            NUDParticleMaxAcc.TabIndex = 8;
            NUDParticleMaxAcc.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleMaxAccelration;
            // 
            // NUDParticleSize
            // 
            NUDParticleSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleSize.Location = new System.Drawing.Point(92, 58);
            NUDParticleSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            NUDParticleSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            NUDParticleSize.Name = "NUDParticleSize";
            NUDParticleSize.Size = new System.Drawing.Size(51, 20);
            NUDParticleSize.TabIndex = 6;
            NUDParticleSize.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleSize;
            // 
            // NUDStartVelocity
            // 
            NUDStartVelocity.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleStartVelocity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDStartVelocity.Location = new System.Drawing.Point(92, 84);
            NUDStartVelocity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            NUDStartVelocity.Name = "NUDStartVelocity";
            NUDStartVelocity.Size = new System.Drawing.Size(51, 20);
            NUDStartVelocity.TabIndex = 4;
            NUDStartVelocity.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleStartVelocity;
            // 
            // NUDParticleCount
            // 
            NUDParticleCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DirectXScreenSaver.Properties.Settings.Default, "ParticleCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NUDParticleCount.Location = new System.Drawing.Point(92, 6);
            NUDParticleCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            NUDParticleCount.Name = "NUDParticleCount";
            NUDParticleCount.Size = new System.Drawing.Size(51, 20);
            NUDParticleCount.TabIndex = 2;
            NUDParticleCount.Value = global::DirectXScreenSaver.Properties.Settings.Default.ParticleCount;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 221);
            this.Controls.Add(this.TCMain);
            this.Controls.Add(this.BOk);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Configure screensaver";
            this.TCMain.ResumeLayout(false);
            this.TPMain.ResumeLayout(false);
            this.TPMain.PerformLayout();
            this.TPParticles.ResumeLayout(false);
            this.TPParticles.PerformLayout();
            this.TPInfoHUD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(NUDFadeSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDFadeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleControlMoveMaxStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleControlMoveInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleControlCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleClipSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleGravity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleMaxAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDStartVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NUDParticleCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.TabPage TPParticles;
        private System.Windows.Forms.Button BDefault;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.TabPage TPMain;
        private System.Windows.Forms.TabPage TPInfoHUD;
        private System.Windows.Forms.Button BInfoHUDOptions;
        private System.Windows.Forms.Label label1;
    }
}