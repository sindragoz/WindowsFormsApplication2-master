using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElementBaseView
{
    public class AbstrButton:Control
    {

        Color theme=Color.Red;
        protected Image pic;
        public Color Theme
        {
            get { return theme; }
            set
            {
                theme = value;
            }
        }
        public AbstrButton() {
           
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            DoubleBuffered = true;
            base.OnPaint(pevent);
            if (pic!=null)
            pevent.Graphics.DrawImage(pic, 0, 0, Width, Height);
        }
        private int glow=60;
        private Size prev_size;
        private Color prev_clr;

        protected override void OnMouseEnter(EventArgs e)
        {
            prev_size = Size;
            base.OnMouseEnter(e);
            prev_clr = Theme;
            Width += 1;
            Height += 1;

            Theme = (Theme.R == 255 && Theme.G == 255 && Theme.B == 255) ? Color.FromArgb(255 - glow, 255 - glow, 255 - glow) : Color.FromArgb(Theme.R + (Theme.R + glow <= 255 ? glow : 0), Theme.G + (Theme.G + glow <= 255 ? glow : 0), Theme.B + (Theme.B + glow <= 255 ? glow : 0)) ;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Theme = prev_clr;
            Size = prev_size;
            Invalidate();
        }
    }
}
