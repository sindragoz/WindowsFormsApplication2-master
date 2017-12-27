namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.musicTrackBar1 = new SoundTrackBar.MusicTrackBar();
            this.soundSpectrum1 = new SoundSpectrumVisualisation.SoundSpectrum();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar5 = new System.Windows.Forms.ProgressBar();
            this.progressBar6 = new System.Windows.Forms.ProgressBar();
            this.progressBar7 = new System.Windows.Forms.ProgressBar();
            this.progressBar8 = new System.Windows.Forms.ProgressBar();
            this.progressBar9 = new System.Windows.Forms.ProgressBar();
            this.progressBar10 = new System.Windows.Forms.ProgressBar();
            this.progressBar11 = new System.Windows.Forms.ProgressBar();
            this.progressBar12 = new System.Windows.Forms.ProgressBar();
            this.progressBar13 = new System.Windows.Forms.ProgressBar();
            this.progressBar14 = new System.Windows.Forms.ProgressBar();
            this.progressBar15 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(959, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // musicTrackBar1
            // 
            this.musicTrackBar1.Location = new System.Drawing.Point(121, 444);
            this.musicTrackBar1.MaximumValue = 100;
            this.musicTrackBar1.MinimumValue = 0;
            this.musicTrackBar1.Name = "musicTrackBar1";
            this.musicTrackBar1.Size = new System.Drawing.Size(445, 20);
            this.musicTrackBar1.TabIndex = 5;
            this.musicTrackBar1.Text = "musicTrackBar1";
            this.musicTrackBar1.Theme = System.Drawing.Color.Empty;
            this.musicTrackBar1.Value = 100;
            // 
            // soundSpectrum1
            // 
            this.soundSpectrum1.H_S_Size = 13.4375F;
            this.soundSpectrum1.Location = new System.Drawing.Point(136, 58);
            this.soundSpectrum1.Name = "soundSpectrum1";
            this.soundSpectrum1.Size = new System.Drawing.Size(430, 189);
            this.soundSpectrum1.TabIndex = 6;
            this.soundSpectrum1.Text = "soundSpectrum1";
            this.soundSpectrum1.Theme = System.Drawing.Color.Empty;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(151, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(722, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 8;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(151, 41);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(722, 23);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 9;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(151, 70);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(722, 23);
            this.progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar3.TabIndex = 10;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(151, 99);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(722, 23);
            this.progressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar4.TabIndex = 11;
            // 
            // progressBar5
            // 
            this.progressBar5.Location = new System.Drawing.Point(151, 128);
            this.progressBar5.Name = "progressBar5";
            this.progressBar5.Size = new System.Drawing.Size(722, 23);
            this.progressBar5.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar5.TabIndex = 12;
            // 
            // progressBar6
            // 
            this.progressBar6.Location = new System.Drawing.Point(151, 157);
            this.progressBar6.Name = "progressBar6";
            this.progressBar6.Size = new System.Drawing.Size(722, 23);
            this.progressBar6.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar6.TabIndex = 13;
            // 
            // progressBar7
            // 
            this.progressBar7.Location = new System.Drawing.Point(151, 186);
            this.progressBar7.Name = "progressBar7";
            this.progressBar7.Size = new System.Drawing.Size(722, 23);
            this.progressBar7.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar7.TabIndex = 14;
            // 
            // progressBar8
            // 
            this.progressBar8.Location = new System.Drawing.Point(151, 215);
            this.progressBar8.Name = "progressBar8";
            this.progressBar8.Size = new System.Drawing.Size(722, 23);
            this.progressBar8.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar8.TabIndex = 15;
            // 
            // progressBar9
            // 
            this.progressBar9.Location = new System.Drawing.Point(151, 244);
            this.progressBar9.Name = "progressBar9";
            this.progressBar9.Size = new System.Drawing.Size(722, 23);
            this.progressBar9.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar9.TabIndex = 16;
            // 
            // progressBar10
            // 
            this.progressBar10.Location = new System.Drawing.Point(151, 273);
            this.progressBar10.Name = "progressBar10";
            this.progressBar10.Size = new System.Drawing.Size(722, 23);
            this.progressBar10.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar10.TabIndex = 17;
            // 
            // progressBar11
            // 
            this.progressBar11.Location = new System.Drawing.Point(151, 302);
            this.progressBar11.Name = "progressBar11";
            this.progressBar11.Size = new System.Drawing.Size(722, 23);
            this.progressBar11.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar11.TabIndex = 18;
            // 
            // progressBar12
            // 
            this.progressBar12.Location = new System.Drawing.Point(151, 331);
            this.progressBar12.Name = "progressBar12";
            this.progressBar12.Size = new System.Drawing.Size(722, 23);
            this.progressBar12.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar12.TabIndex = 19;
            // 
            // progressBar13
            // 
            this.progressBar13.Location = new System.Drawing.Point(151, 360);
            this.progressBar13.Name = "progressBar13";
            this.progressBar13.Size = new System.Drawing.Size(722, 23);
            this.progressBar13.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar13.TabIndex = 20;
            // 
            // progressBar14
            // 
            this.progressBar14.Location = new System.Drawing.Point(151, 389);
            this.progressBar14.Name = "progressBar14";
            this.progressBar14.Size = new System.Drawing.Size(722, 23);
            this.progressBar14.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar14.TabIndex = 21;
            // 
            // progressBar15
            // 
            this.progressBar15.Location = new System.Drawing.Point(151, 418);
            this.progressBar15.Name = "progressBar15";
            this.progressBar15.Size = new System.Drawing.Size(722, 23);
            this.progressBar15.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar15.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 587);
            this.Controls.Add(this.progressBar15);
            this.Controls.Add(this.progressBar14);
            this.Controls.Add(this.progressBar13);
            this.Controls.Add(this.progressBar12);
            this.Controls.Add(this.progressBar11);
            this.Controls.Add(this.progressBar10);
            this.Controls.Add(this.progressBar9);
            this.Controls.Add(this.progressBar8);
            this.Controls.Add(this.progressBar7);
            this.Controls.Add(this.progressBar6);
            this.Controls.Add(this.progressBar5);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.musicTrackBar1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private SoundTrackBar.MusicTrackBar musicTrackBar1;
        private SoundSpectrumVisualisation.SoundSpectrum soundSpectrum1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar5;
        private System.Windows.Forms.ProgressBar progressBar6;
        private System.Windows.Forms.ProgressBar progressBar7;
        private System.Windows.Forms.ProgressBar progressBar8;
        private System.Windows.Forms.ProgressBar progressBar9;
        private System.Windows.Forms.ProgressBar progressBar10;
        private System.Windows.Forms.ProgressBar progressBar11;
        private System.Windows.Forms.ProgressBar progressBar12;
        private System.Windows.Forms.ProgressBar progressBar13;
        private System.Windows.Forms.ProgressBar progressBar14;
        private System.Windows.Forms.ProgressBar progressBar15;
        //private SoundTrackBar.MusicTrackBar musicTrackBar1;
    }
}

