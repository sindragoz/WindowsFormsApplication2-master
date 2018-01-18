﻿
using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
namespace SoundTrackBar
{
    public class RoundedTrackBar : BaseElement
    {

        Controller.Controller cont;
        public RoundedTrackBar(Controller.Controller cont)
        {
            this.cont = cont;
            DoubleBuffered = true;
        }
        private float value = 0;
        private int min = 0;
        private int max = 1;
        private float newValue = 360;
        private Color clr2 = Color.White;
        private bool dragNow = false;
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
                    newValue = value;
                    Invalidate();
                }
            }
        }
        int cnt = 0;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawArc(new Pen(Theme, 10), 12, 12, Width - 24, Height - 24, -90, -newValue + 360);
            e.Graphics.DrawImage(Resource1.Rounded_t_bar, 5, 5, Width - 10, Height - 10);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragNow = false;
            setNewValue(new Point(e.X, e.Y));
            ValueChanged(EventArgs.Empty);
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
                newValue = (float)(Math.Atan2(Width / 2 - 5 - point.X, Height / 2 - 5 - point.Y) / Math.PI * 180);
                newValue = (newValue < 0) ? newValue + 360 : newValue;
                float value = ((-newValue + 360) / 360) * (max - min);
                this.value = (int)value;
                Invalidate();
                cont.Scroll(value);
            }

        }
        private EventHandler<ValueEventArgs> onValueChanged;
        public event EventHandler<ValueEventArgs> OnValueChanged
        {
            add { onValueChanged += value; }
            remove { onValueChanged -= value; }
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


