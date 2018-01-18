using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElementBaseView
{
    public class BaseElement:Control
    {
        Color theme=Color.Green;
        public Color Theme
        {
            get { return theme; }
            set
            { theme = value;
                Invalidate();
            }
        }
        Color elementColor = Color.LimeGreen;
        public Color ElementColor
        {
            get { return elementColor; }
            set
            {
                elementColor = value;
            }
        }
        private bool useTheme = true;
        public bool UseTheme
        {
            get { return useTheme; }
            set { useTheme = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }

    }
}
