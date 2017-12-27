using ButtonView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonPrev
{
    class PrevBtn : Button
    {
        
        public PrevBtn()
        {

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            //pevent.Graphics.DrawImage(play_pic, 0, 0, Width, Height);
        }
    }

}
