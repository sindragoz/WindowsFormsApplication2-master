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
   public class ChangeStyleBtn:AbstrButton
    {
        

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if(pic==null)
                pic = Resource1.minimize;
            pevent.Graphics.DrawImage(pic, 0, 0, Width, Height);

        }

        public void setStatementIcon(bool minimized)
        {
            pic = minimized ? Resource1.maximize : Resource1.minimize;
            Invalidate();
        }
    }
}
