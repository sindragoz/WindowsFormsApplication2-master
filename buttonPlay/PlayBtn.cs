using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonPlay
{
    public class PlayBtn:AbstrButton
    {
        private EventHandler onPause;
        private EventHandler onPlay;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            BackColor = Color.Transparent;
            Invalidate();
            Parent = null;

        }
        private bool play = true;

        public event EventHandler OnPause { add { onPause += value; } remove { onPause -= value; } }
        public event EventHandler OnPlay { add { onPlay += value; } remove { onPlay -= value; } }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath gp = new GraphicsPath();
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            gp.AddEllipse(ClientRectangle);
            Region r = new Region(gp);
            Region = r;
            base.OnPaint(pevent);
            pevent.Graphics.FillEllipse(new SolidBrush(Theme),Width/8,Height/6,4*Width/5,3*Height/4);
            if (pic == null)
                pic = Resource1.Play_btn;
            pevent.Graphics.DrawImage(pic, 1, 1, Width - 2, Height - 2);
        }
        protected virtual void OnPaused(EventArgs e)
        {
            if (onPause != null)
            {
                onPause.Invoke(this, e);
            }
        }
        protected virtual void OnPlaying(EventArgs e)
        {
            if (onPlay != null)
            {
                onPlay.Invoke(this, e);
            }
        }
        public void setStatementIcon(bool play)
        {
            if (play)
            {
                pic = Resource1.Play_btn;
                OnPlaying(EventArgs.Empty);
            }
            else
            {
             pic= Resource1.pause_btn;
                OnPaused(EventArgs.Empty);
            }
            Invalidate();
        }
    }
}
