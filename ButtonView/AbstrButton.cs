using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonView
{
    public class BaseElement : Control
    {
        Color theme = Color.Red;
        public Color Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            base.OnPaint(e);

        }

    }
}
