using ButtonView;
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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            BackColor = Color.Transparent;
            Invalidate();
            Parent = null;

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(ClientRectangle);
            Region r = new Region(gp);
            Region = r;
            base.OnPaint(pevent);
            pevent.Graphics.FillEllipse(new SolidBrush(Theme),Width/6,Height/6,2*Width/3,3*Height/4);
            if (pic == null)
                pic = Resource1.Play_btn;
            pevent.Graphics.DrawImage(pic, 0, 0, Width, Height);
        }

        public void setStatementIcon(bool play)
        {
            pic = play?Resource1.Play_btn:Resource1.pause_btn;
            Invalidate();
        }
    }
}
