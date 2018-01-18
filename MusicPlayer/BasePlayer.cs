//using ElementBaseView;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Drawing.Design;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static SoundSpectrumVisualisation.SoundSpectrum;

//namespace MusicPlayer
//{
//    public class BasePlayer : BaseElement
//    {
//        List<Rectangle> cl = new List<Rectangle>();
//        private Point prev_loc = new Point(85, 192);
//        private Point next_loc = new Point(10,20);
//        private buttonPlay.PrevBtn prevBtn1=new buttonPlay.PrevBtn();
//        private buttonPlay.NextBtn nextBtn1=new buttonPlay.NextBtn();
//        private void Setloc() {
//            prevBtn1.Location = locatio[0].Location;
//            nextBtn1.Location = locatio[1].Location;
//            Refresh();
//            prevBtn1.Invalidate();
//            prevBtn1.Update();
//            prevBtn1.Refresh();
//            nextBtn1.Refresh();
//            this.Controls.Remove(prevBtn1);
//            Invalidate();
//        }
//        private void init()
//        {
//            cl.Add(new Rectangle(prev_loc.X,prev_loc.Y,30,30));
//            cl.Add(new Rectangle(next_loc.X, next_loc.Y, 30, 30));
//            prevBtn1.MaximumSize = new Size(30, 30);
//            prevBtn1.Size = new Size(30, 30);
//            nextBtn1.MaximumSize = new Size(30, 30);
//            nextBtn1.Size = new Size(30, 30);
//            Setloc();
//            this.Controls.Add(prevBtn1);
//            this.Controls.Add(nextBtn1);
            
//        }
//        //private int comp = 0;
//        //public int Comp {
//        //    get { return comp; }
//        //    set { comp = value; }
//        //} 
//        private List<string> comp_name_list;
       
//        public List<string> CompNameList
//        {
//            get { return comp_name_list; }
//        }
//        [
//            Category("Flash"),
//            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
//        ]
//        public List <Rectangle> locatio {
//        get { return cl; }
//            set { //if(comp==1)
//                cl = value;
//                Setloc();
//                MessageBox.Show("CHPOK!");
//            }
//        }
//        public BasePlayer() {
//            init();
            
//        }

//    }
//}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SoundSpectrumVisualisation.SoundSpectrum;

namespace MusicPlayer
{
    public class BasePlayer : ElementBaseView.BaseElement
    {
        private Point prev_loc = new Point(85, 192);
        private Point next_loc =new Point(20,20);
        private buttonPlay.PrevBtn prevBtn1=new buttonPlay.PrevBtn();
        private buttonPlay.NextBtn nextBtn1 = new buttonPlay.NextBtn();
        private void init()
        {
            prevBtn1.Location = prev_loc;
            prevBtn1.MaximumSize = new Size(20, 20);
            prevBtn1.Size = new Size(20, 20);
            nextBtn1.Location = next_loc;
            nextBtn1.MaximumSize = new Size(20, 20);
            nextBtn1.Size = new Size(20, 20);
            this.Controls.Add(prevBtn1);
            this.Controls.Add(nextBtn1);
        }
        private int comp = 0;
        public int Comp {
            get { return comp; }
            set { comp = value; }
        }
        [
            Category("Flash"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle loc {
        get { return new Rectangle(prevBtn1.Location,prevBtn1.Size); }
            set {prevBtn1.Location = value.Location; }
        }
        [
            Category("Flash"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle loc1
        {
            get { return new Rectangle(nextBtn1.Location, nextBtn1.Size); }
            set { nextBtn1.Location = value.Location; }
        }
        public BasePlayer() {
            init();
            MessageBox.Show("CHPOK!");
        }
    }
}

