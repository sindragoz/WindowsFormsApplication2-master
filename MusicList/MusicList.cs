using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicList
{
    public class MusicList:ListBox
    {

        public MusicList() {
            
            BackColor = Color.Black;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
        public void addItem(object item) {
            Items.Add(Items.Count+1+". "+item.ToString());
        }

    }
}
