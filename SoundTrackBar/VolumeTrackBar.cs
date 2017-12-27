using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundTrackBar
{
   public class VolumeTrackBar:BaseElement
    {
        private int value = 0;
        private int min = 0;
        private int max = 100;
        private float newValue = 0;

        private bool dragNow = false;
        int sections = 8;
        //private Image img = Image.FromFile("C:\\Users\\User\\Downloads\\color-ring.png");
        private float glow_pos_x = 0;
        public float NewValue
        {
            get { return newValue; }
        }
       

        public int MinimumValue
        {
            get { return min; }
            set { min = value; }
        }
        public int MaximumValue
        {
            get { return max; }
            set
            {
                max = value;
            }
        }
        public int Value
        {
            get { return value; }
            set
            {
                if (value != this.value && value >= min && value <= max)
                {
                    this.value = value;
                }
            }
        }
        public VolumeTrackBar()
        {

            DoubleBuffered = true;
        }
        int cnt = 0;


        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
            float brick_h = (Height) / sections;
            
            int interval = 5;
            for (int i = 0; i < sections; i++) {
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray),0,Height-i*brick_h-interval,Width,brick_h-interval);
            }
            for (int i = 0; i <(Height - NewValue)/brick_h&&i<sections ; i++)
            {if ((Height - NewValue) / brick_h < 0.25)
                    break;
                e.Graphics.FillRectangle(new SolidBrush(Theme), 0,Height- i * brick_h - interval+1, Width, brick_h - interval);
            }
            //e.Graphics.FillRectangle(new LinearGradientBrush(new PointF(newValue - 100, ClientRectangle.Height / 3), new PointF(NewValue, ClientRectangle.Height / 3), Color.Transparent, clr2), NewValue - 99, ClientRectangle.Height / 3, 100, ClientRectangle.Height / 3);
            ////  e.Graphics.FillRectangle(new LinearGradientBrush(new PointF(glow_pos_x,0), new PointF(newValue, ClientRectangle.Height), Color.White, Color.Transparent), glow_pos_x, 0, newValue-glow_pos_x, ClientRectangle.Height);

            //e.Graphics.FillRectangle(new LinearGradientBrush(new PointF(glow_pos_x - 80, ClientRectangle.Height / 3), new PointF(glow_pos_x, ClientRectangle.Height / 3), Color.Transparent, Color.White), glow_pos_x - 79, ClientRectangle.Height / 3, 80, ClientRectangle.Height / 3);
            //e.Graphics.FillRectangle(new SolidBrush(clr1), NewValue - 1, Height / 6, 5, 4 * Height / 6);
            //
            // e.Graphics.FillRectangle(new LinearGradientBrush(new PointF(glow_pos_x, 0), new PointF(NewValue, ClientRectangle.Height), Color.White, Color.Transparent), glow_pos_x,0,ClientRectangle.Width, ClientRectangle.Height);
            // e.Graphics.DrawImage(img, newValue-ClientRectangle.Height/2, 0, ClientRectangle.Height, ClientRectangle.Height);
            // e.Graphics.Flush();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);


            dragNow = false;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            dragNow = true;
            base.OnMouseDown(e);
            setNewValue(new Point(e.X, e.Y));

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragNow)
            {
                setNewValue(new Point(e.X, e.Y));
            }
        }
        private void setNewValue(Point point)
        {
            Rectangle client = ClientRectangle;

            if (ClientRectangle.Contains(point))
            {
                // this.Width += 20;
                //    this.Width += point.X;
                newValue = point.Y;
                float value = ((float)newValue / (float)ClientRectangle.Height) * (max - min);
                this.value = (int)value;
                //  clr = Color.Blue;
                Invalidate();
                //     OptimizedInvalidate((int)value,(int)newValue);


            }
        }

    }
}

