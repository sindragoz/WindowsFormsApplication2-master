using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    class CompEditPanel : Panel
    {
        private Color theme = Color.Red;
        public bool playbtn=false;
        Rectangle comp_rect;
        private Color element_color = Color.Transparent;
        private Image element_image=null;
        public Color Theme
        {
            get { return theme; }
            set
            {
                theme = value;
            }
        }

        public Color Element_color { get => element_color; set => element_color = value; }
        public Image Element_image { get => element_image; set => element_image = value; }

        public Rectangle getComp()
        {
            return comp_rect;
        }
        private List<Rectangle> comp_list;
        private Rectangle resize_rect;
        public CompEditPanel()
        {
            comp_rect = new Rectangle(10, 10, 30, 30);
            resize_rect = new Rectangle();
            setResizeRect();
        }
        private void setResizeRect()
        {
            resize_rect.X = comp_rect.X + comp_rect.Width + 1;
            resize_rect.Y = comp_rect.Y + comp_rect.Height + 1;
            resize_rect.Width = 4;
            resize_rect.Height = 4;
            //(comp_rect.X + comp_rect.Width + 1, comp_rect.Y + comp_rect.Height + 1, 4, 4);
        }
        public CompEditPanel(Rectangle rect, List<Rectangle> comps, Color t)
        {
            DoubleBuffered = true;
            comp_rect = rect;
            comp_list = comps;
            resize_rect = new Rectangle(comp_rect.X + comp_rect.Width + 1, comp_rect.Y + comp_rect.Height + 1, 4, 4);
            theme = t;

            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var c in comp_list)
                e.Graphics.DrawRectangle(new Pen(theme), c);
            Font font = new Font("Times New Roman", 8, FontStyle.Regular);
            e.Graphics.DrawRectangle(new Pen(inverseColor(theme)), comp_rect);
            e.Graphics.DrawRectangle(new Pen(inverseColor(theme)), resize_rect);
        }
        private Color inverseColor(Color clr)
        {
            return Color.FromArgb(255 - clr.R, 255 - clr.G, 255 - clr.B);
        }
        bool drag = false;
        bool resize = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            drag = false;
            resize = false;
            base.OnMouseDown(e);
            if ((e as MouseEventArgs).Button == MouseButtons.Left)
            {
                if (e.X >= comp_rect.X && e.X <= comp_rect.X + comp_rect.Width && e.Y >= comp_rect.Y && e.Y <= comp_rect.Y + comp_rect.Height)
                    drag = true;
                if (e.X >= resize_rect.X && e.X <= resize_rect.X + resize_rect.Width && e.Y >= resize_rect.Y && e.Y <= resize_rect.Y + resize_rect.Height)
                    resize = true;
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Right)
            {

            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            drag = false;
            resize = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (drag)
            {
                comp_rect = new Rectangle(e.X, e.Y, comp_rect.Width, comp_rect.Height);
                setResizeRect();
                Invalidate();
            }
            else
            if (resize)
            {
                comp_rect = new Rectangle(comp_rect.X, comp_rect.Y, e.X - comp_rect.X, e.Y - comp_rect.Y);
                setResizeRect();
                Invalidate();
            }


        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ComponentStyleForm f;
            if ((e as MouseEventArgs).Button == MouseButtons.Right)
            {
                f = new ComponentStyleForm();
                f.ShowDialog();
                Element_color = f.color;
                Element_image = f.img;
                
            }
        }

    }
}

