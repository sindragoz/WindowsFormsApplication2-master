using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary2
{
    [DefaultEvent("ValueChanged")]
    class SoundTrackBar1 : TrackBar
    {
        private Button button1;

        protected override void OnPaint(PaintEventArgs e)
            {
                // base.OnPaint(e);
                // e.Graphics.DrawLine(new Pen(Color.Red), e.ClipRectangle.X,e.ClipRectangle.Y,e.ClipRectangle.X+ e.ClipRectangle.Width, e.ClipRectangle.Y);
            }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
    
}
