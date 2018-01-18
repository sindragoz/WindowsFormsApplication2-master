namespace WindowsFormsApplication1
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
            this.musicPlayer1 = new MusicPlayer.MusicPlayer();
            this.SuspendLayout();
            // 
            // musicPlayer1
            // 
            this.musicPlayer1.BackColor = System.Drawing.Color.Black;
            this.musicPlayer1.Count_time_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.ElementColor = System.Drawing.Color.LimeGreen;
            this.musicPlayer1.File_img = null;
            this.musicPlayer1.FileBtnLocation = new System.Drawing.Rectangle(36, 184, 36, 39);
            this.musicPlayer1.Form_Of_Sectre = SoundSpectrumVisualisation.SoundSpectrum.SpectrumForm.Rect;
            this.musicPlayer1.High_spectre_detalization = true;
            this.musicPlayer1.Location = new System.Drawing.Point(21, 12);
            this.musicPlayer1.MinimumSize = new System.Drawing.Size(400, 450);
            this.musicPlayer1.Mus_bar_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.Mus_list_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.MusicListBtnLocation = new System.Drawing.Rectangle(1, 240, 20, 20);
            this.musicPlayer1.MusicListLocation = new System.Drawing.Rectangle(2, 300, 398, 147);
            this.musicPlayer1.Muslist_img = null;
            this.musicPlayer1.Name = "musicPlayer1";
            this.musicPlayer1.Next_clr = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(0)))), ((int)(((byte)(230)))));
            this.musicPlayer1.Next_img = null;
            this.musicPlayer1.NextBtnLocation = new System.Drawing.Rectangle(311, 172, 60, 50);
            this.musicPlayer1.Play_clr = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(242)))));
            this.musicPlayer1.Play_img = null;
            this.musicPlayer1.PlayBtnLocation = new System.Drawing.Rectangle(160, 174, 133, 131);
            this.musicPlayer1.Prev_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.Prev_img = null;
            this.musicPlayer1.PrevBtnLocation = new System.Drawing.Rectangle(85, 192, 60, 50);
            this.musicPlayer1.Rounded_bar_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.rTrackBarBtnLocation = new System.Drawing.Rectangle(1, 265, 20, 20);
            this.musicPlayer1.rTrackBarLocation = new System.Drawing.Rectangle(145, 165, 110, 110);
            this.musicPlayer1.Size = new System.Drawing.Size(443, 470);
            this.musicPlayer1.Spectrum_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.Spectrum_img = null;
            this.musicPlayer1.SpectrumBtnLocation = new System.Drawing.Rectangle(1, 190, 20, 20);
            this.musicPlayer1.SpectrumLocation = new System.Drawing.Rectangle(25, 10, 350, 150);
            this.musicPlayer1.Sytle_img = null;
            this.musicPlayer1.TabIndex = 0;
            this.musicPlayer1.Text = "musicPlayer1";
            this.musicPlayer1.Theme = System.Drawing.Color.GreenYellow;
            this.musicPlayer1.TimerLocation = new System.Drawing.Rectangle(275, 255, 100, 23);
            this.musicPlayer1.TrackBarLocation = new System.Drawing.Rectangle(25, 270, 310, 20);
            this.musicPlayer1.UseTheme = false;
            this.musicPlayer1.Volume_clr = System.Drawing.Color.Lime;
            this.musicPlayer1.VolumeBarBtnLocation = new System.Drawing.Rectangle(355, 225, 20, 60);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 539);
            this.Controls.Add(this.musicPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MusicPlayer.MusicPlayer musicPlayer1;
    }
}

