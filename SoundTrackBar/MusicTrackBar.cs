
using ElementBaseView;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Controller;

namespace SoundTrackBar
{
    public class MusicTrackBar : BaseElement
    {
        Controller.Controller cont;
        public MusicTrackBar(Controller.Controller cont)
        {
            this.cont = cont;

            DoubleBuffered = true;
        }
        private float value = 0;
        private int min = 0;
        private int max = 1;
        private float newValue = 0;
        private float newValue1 = 0;
        private Color clr1;
        private Color clr2 = Color.White;
        private bool dragNow = false;
        private Timer glow_timer = null;
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
        private EventHandler<ValueEventArgs> onValueChanged;
        public event EventHandler<ValueEventArgs> OnValueChanged
        {
            add { onValueChanged += value; }
            remove { onValueChanged -= value; }
        }
        public float Value
        {
            get { return value; }
            set
            {
                if (value != this.value && value >= min && value <= max)
                {
                    this.value = value;
                    newValue = (value * (float)ClientRectangle.Width) / (max - min);
                    Invalidate();
                }
            }
        }
        public MusicTrackBar()
        {


        }
        int cnt = 0;

        public void Glow_timer_Tick(object sender, EventArgs e)
        {
            if ((glow_pos_x >= NewValue - NewValue / 30 - 1))
            {
                glow_pos_x = 0;
                cnt++;

            }
            else
            {
                if (cnt != 0)
                {
                    cnt++;
                    if (cnt == 120)
                        cnt = 0;
                }
                else
                    glow_pos_x += NewValue / 30;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            clr1 = Theme;
            this.DoubleBuffered = true;
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0, ClientRectangle.Height / 3, ClientRectangle.Width, ClientRectangle.Height / 3);
            e.Graphics.FillRectangle(new SolidBrush(clr1), 0, ClientRectangle.Height / 3, newValue, ClientRectangle.Height / 3);
            e.Graphics.FillRectangle(new LinearGradientBrush(new PointF(newValue - 100, ClientRectangle.Height / 3), new PointF(NewValue, ClientRectangle.Height / 3), Color.Transparent, clr2), NewValue - 99, ClientRectangle.Height / 3, 100, ClientRectangle.Height / 3);

            e.Graphics.FillRectangle(new LinearGradientBrush(new PointF(glow_pos_x - 80, ClientRectangle.Height / 3), new PointF(glow_pos_x, ClientRectangle.Height / 3), Color.Transparent, Color.White), glow_pos_x - 79, ClientRectangle.Height / 3, 80, ClientRectangle.Height / 3);
            e.Graphics.FillRectangle(new SolidBrush(clr1), NewValue - 1, Height / 6, 5, 4 * Height / 6);
        }

        private void Glow_interval_Tick(object sender, EventArgs e)
        {


        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ValueChanged(EventArgs.Empty);

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
                newValue = point.X;
                float value = ((float)newValue / (float)ClientRectangle.Width) * (max - min);
                this.value = value;
                cont.Scroll(value);
                Invalidate();
            }
        }
        protected virtual void ValueChanged(EventArgs e)
        {
            if (onValueChanged != null)
            {
                ValueEventArgs ve = new ValueEventArgs((int)value);
                onValueChanged.Invoke(this, ve);
            }
        }

    }
}

