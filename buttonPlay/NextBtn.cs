using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonPlay
{
   public class NextBtn: AbstrButton
    {
        
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            SolidBrush br = new SolidBrush(Theme);
            pevent.Graphics.FillEllipse(new SolidBrush(Theme), Width / 4, Height / 5, 2*Width / 3-2, Height / 2);
            if (pic == null)
                pic = Resource1.Next_btn;
            pevent.Graphics.DrawImage(pic, 0, 0, Width, Height);

        }
    }
}
