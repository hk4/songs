namespace DrumTune
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.trackBarPitch = new System.Windows.Forms.TrackBar();
            this.trackBarAttack = new System.Windows.Forms.TrackBar();
            this.trackBarPeak = new System.Windows.Forms.TrackBar();
            this.trackBarDecay = new System.Windows.Forms.TrackBar();
            this.trackBarSustainVolume = new System.Windows.Forms.TrackBar();
            this.trackBarSustainTime = new System.Windows.Forms.TrackBar();
            this.labelFreqHz = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelAttack = new System.Windows.Forms.Label();
            this.labelPeak = new System.Windows.Forms.Label();
            this.labelDecay = new System.Windows.Forms.Label();
            this.trackBarReleaseTime = new System.Windows.Forms.TrackBar();
            this.labelSusVol = new System.Windows.Forms.Label();
            this.labelSusTime = new System.Windows.Forms.Label();
            this.labelReleaseTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPeak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDecay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSustainVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSustainTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReleaseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 530);
            this.button1.TabIndex = 0;
            this.button1.Text = "play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(28, 26);
            this.trackBarVolume.Maximum = 1000;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(45, 530);
            this.trackBarVolume.TabIndex = 1;
            this.trackBarVolume.TickFrequency = 0;
            this.trackBarVolume.Value = 360;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.Location = new System.Drawing.Point(95, 26);
            this.trackBarPitch.Maximum = 22050;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarPitch.Size = new System.Drawing.Size(45, 530);
            this.trackBarPitch.TabIndex = 2;
            this.trackBarPitch.TickFrequency = 0;
            this.trackBarPitch.Value = 11025;
            this.trackBarPitch.Scroll += new System.EventHandler(this.trackBarPitch_Scroll);
            // 
            // trackBarAttack
            // 
            this.trackBarAttack.Location = new System.Drawing.Point(159, 26);
            this.trackBarAttack.Maximum = 1000;
            this.trackBarAttack.Name = "trackBarAttack";
            this.trackBarAttack.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAttack.Size = new System.Drawing.Size(45, 530);
            this.trackBarAttack.TabIndex = 3;
            this.trackBarAttack.TickFrequency = 0;
            this.trackBarAttack.Scroll += new System.EventHandler(this.trackBarAttack_Scroll);
            // 
            // trackBarPeak
            // 
            this.trackBarPeak.Location = new System.Drawing.Point(224, 26);
            this.trackBarPeak.Maximum = 1000;
            this.trackBarPeak.Name = "trackBarPeak";
            this.trackBarPeak.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarPeak.Size = new System.Drawing.Size(45, 530);
            this.trackBarPeak.TabIndex = 4;
            this.trackBarPeak.TickFrequency = 0;
            this.trackBarPeak.Value = 1000;
            this.trackBarPeak.Scroll += new System.EventHandler(this.trackBarPeak_Scroll);
            // 
            // trackBarDecay
            // 
            this.trackBarDecay.Location = new System.Drawing.Point(285, 26);
            this.trackBarDecay.Maximum = 1000;
            this.trackBarDecay.Name = "trackBarDecay";
            this.trackBarDecay.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarDecay.Size = new System.Drawing.Size(45, 530);
            this.trackBarDecay.TabIndex = 5;
            this.trackBarDecay.TickFrequency = 0;
            this.trackBarDecay.Scroll += new System.EventHandler(this.trackBarRelease_Scroll);
            // 
            // trackBarSustainVolume
            // 
            this.trackBarSustainVolume.Location = new System.Drawing.Point(362, 26);
            this.trackBarSustainVolume.Maximum = 1000;
            this.trackBarSustainVolume.Name = "trackBarSustainVolume";
            this.trackBarSustainVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSustainVolume.Size = new System.Drawing.Size(45, 530);
            this.trackBarSustainVolume.TabIndex = 6;
            this.trackBarSustainVolume.TickFrequency = 0;
            this.trackBarSustainVolume.Value = 30;
            this.trackBarSustainVolume.Scroll += new System.EventHandler(this.trackBarSustainVolume_Scroll);
            // 
            // trackBarSustainTime
            // 
            this.trackBarSustainTime.Location = new System.Drawing.Point(431, 26);
            this.trackBarSustainTime.Maximum = 1000;
            this.trackBarSustainTime.Name = "trackBarSustainTime";
            this.trackBarSustainTime.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSustainTime.Size = new System.Drawing.Size(45, 530);
            this.trackBarSustainTime.TabIndex = 7;
            this.trackBarSustainTime.TickFrequency = 0;
            this.trackBarSustainTime.Value = 100;
            this.trackBarSustainTime.Scroll += new System.EventHandler(this.trackBarSustainTime_Scroll);
            // 
            // labelFreqHz
            // 
            this.labelFreqHz.AutoSize = true;
            this.labelFreqHz.Location = new System.Drawing.Point(92, 563);
            this.labelFreqHz.Name = "labelFreqHz";
            this.labelFreqHz.Size = new System.Drawing.Size(55, 13);
            this.labelFreqHz.TabIndex = 8;
            this.labelFreqHz.Text = "11025 HZ";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(25, 563);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(45, 13);
            this.labelVolume.TabIndex = 9;
            this.labelVolume.Text = "36% Vol";
            // 
            // labelAttack
            // 
            this.labelAttack.AutoSize = true;
            this.labelAttack.Location = new System.Drawing.Point(156, 563);
            this.labelAttack.Name = "labelAttack";
            this.labelAttack.Size = new System.Drawing.Size(29, 13);
            this.labelAttack.TabIndex = 10;
            this.labelAttack.Text = "0 ms";
            // 
            // labelPeak
            // 
            this.labelPeak.Location = new System.Drawing.Point(212, 563);
            this.labelPeak.Name = "labelPeak";
            this.labelPeak.Size = new System.Drawing.Size(64, 60);
            this.labelPeak.TabIndex = 11;
            this.labelPeak.Text = "100% Peak";
            // 
            // labelDecay
            // 
            this.labelDecay.AutoSize = true;
            this.labelDecay.Location = new System.Drawing.Point(282, 563);
            this.labelDecay.Name = "labelDecay";
            this.labelDecay.Size = new System.Drawing.Size(35, 13);
            this.labelDecay.TabIndex = 12;
            this.labelDecay.Text = "10 ms";
            this.labelDecay.Click += new System.EventHandler(this.labelDecay_Click);
            // 
            // trackBarReleaseTime
            // 
            this.trackBarReleaseTime.Location = new System.Drawing.Point(498, 26);
            this.trackBarReleaseTime.Maximum = 2000;
            this.trackBarReleaseTime.Name = "trackBarReleaseTime";
            this.trackBarReleaseTime.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarReleaseTime.Size = new System.Drawing.Size(45, 530);
            this.trackBarReleaseTime.TabIndex = 13;
            this.trackBarReleaseTime.TickFrequency = 0;
            this.trackBarReleaseTime.Value = 1000;
            this.trackBarReleaseTime.Scroll += new System.EventHandler(this.trackBarReleaseTime_Scroll);
            // 
            // labelSusVol
            // 
            this.labelSusVol.Location = new System.Drawing.Point(341, 563);
            this.labelSusVol.Name = "labelSusVol";
            this.labelSusVol.Size = new System.Drawing.Size(81, 67);
            this.labelSusVol.TabIndex = 14;
            this.labelSusVol.Text = "3% Sus";
            // 
            // labelSusTime
            // 
            this.labelSusTime.AutoSize = true;
            this.labelSusTime.Location = new System.Drawing.Point(428, 563);
            this.labelSusTime.Name = "labelSusTime";
            this.labelSusTime.Size = new System.Drawing.Size(62, 13);
            this.labelSusTime.TabIndex = 15;
            this.labelSusTime.Text = "100 ms Sus";
            // 
            // labelReleaseTime
            // 
            this.labelReleaseTime.AutoSize = true;
            this.labelReleaseTime.Location = new System.Drawing.Point(495, 563);
            this.labelReleaseTime.Name = "labelReleaseTime";
            this.labelReleaseTime.Size = new System.Drawing.Size(89, 13);
            this.labelReleaseTime.TabIndex = 16;
            this.labelReleaseTime.Text = "1000 ms Release";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 632);
            this.Controls.Add(this.labelReleaseTime);
            this.Controls.Add(this.labelSusTime);
            this.Controls.Add(this.labelSusVol);
            this.Controls.Add(this.trackBarReleaseTime);
            this.Controls.Add(this.labelDecay);
            this.Controls.Add(this.labelPeak);
            this.Controls.Add(this.labelAttack);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelFreqHz);
            this.Controls.Add(this.trackBarSustainTime);
            this.Controls.Add(this.trackBarSustainVolume);
            this.Controls.Add(this.trackBarDecay);
            this.Controls.Add(this.trackBarPeak);
            this.Controls.Add(this.trackBarAttack);
            this.Controls.Add(this.trackBarPitch);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Drum Tune";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPeak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDecay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSustainVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSustainTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReleaseTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.TrackBar trackBarPitch;
        private System.Windows.Forms.TrackBar trackBarAttack;
        private System.Windows.Forms.TrackBar trackBarPeak;
        private System.Windows.Forms.TrackBar trackBarDecay;
        private System.Windows.Forms.TrackBar trackBarSustainVolume;
        private System.Windows.Forms.TrackBar trackBarSustainTime;
        private System.Windows.Forms.Label labelFreqHz;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelAttack;
        private System.Windows.Forms.Label labelPeak;
        private System.Windows.Forms.Label labelDecay;
        private System.Windows.Forms.TrackBar trackBarReleaseTime;
        private System.Windows.Forms.Label labelSusVol;
        private System.Windows.Forms.Label labelSusTime;
        private System.Windows.Forms.Label labelReleaseTime;
    }
}

