﻿namespace WindowsFormsApplication2
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.musicPlayer1 = new MusicPlayer.MusicPlayer();
            this.SuspendLayout();
            // 
            // musicPlayer1
            // 
            this.musicPlayer1.BackColor = System.Drawing.Color.Black;
            this.musicPlayer1.CompList = ((System.Collections.Generic.List<System.Drawing.Rectangle>)(resources.GetObject("musicPlayer1.CompList")));
            this.musicPlayer1.Location = new System.Drawing.Point(37, 12);
            this.musicPlayer1.MaximumSize = new System.Drawing.Size(400, 450);
            this.musicPlayer1.MinimumSize = new System.Drawing.Size(400, 450);
            this.musicPlayer1.Name = "musicPlayer1";
            this.musicPlayer1.Size = new System.Drawing.Size(400, 450);
            this.musicPlayer1.TabIndex = 0;
            this.musicPlayer1.Text = "musicPlayer1";
            this.musicPlayer1.Theme = System.Drawing.Color.Green;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 531);
            this.Controls.Add(this.musicPlayer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private MusicPlayer.MusicPlayer musicPlayer1;
    }
}