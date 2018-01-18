using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;


namespace SoundTrackBar
{
    public class VolumeTrackBar : BaseElement
    {
        private float value = 0;
        private int min = 0;
        private int max = 1;
        private float newValue = 0;
        private EventHandler<ValueEventArgs> onValueChanged;
        public event EventHandler<ValueEventArgs> OnValueChanged
        {
            add { onValueChanged += value; }
            remove { onValueChanged -= value; }
        }
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
        public float Value
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
        Controller.Controller cont;
        public VolumeTrackBar(Controller.Controller cont)
        {
            this.cont = cont;
            DoubleBuffered = true;
        }
        int cnt = 0;


        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            float brick_h = (Height) / sections;

            int interval = 5;
            for (int i = 0; i < sections; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0, Height - i * brick_h - interval, Width, brick_h - interval);
            }
            for (int i = 0; i < (Height - NewValue) / brick_h && i < sections; i++)
            {
                if ((Height - NewValue) / brick_h < 0.25)
                    break;
                e.Graphics.FillRectangle(new SolidBrush(Theme), 0, Height - i * brick_h - interval + 1, Width, brick_h - interval);
            }

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
                newValue = point.Y;
                float value = ((float)newValue / (float)ClientRectangle.Height);
                this.value = value;
                Invalidate();
                cont.volume(value);
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


