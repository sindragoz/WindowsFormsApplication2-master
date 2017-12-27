using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System;

namespace FormatButton
{
    [DefaultEvent("Click")]
    public partial class ButtonEx : Control
    {
        #region ~ Объявление переменных ~
        enum ButtonState : byte
        {
            Normal,
            Hover,
            Pushed,
            Disabled
        }

        ButtonState state = ButtonState.Normal;
        bool focused = false;
        string text = null;
        Bitmap img = null;
        readonly Size imgEtalon = new Size(16, 16);
        #endregion

        public ButtonEx()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor |
                ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.BackColor = Color.Transparent;
        }

        #region ~ Переопределённые события ~
        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.Enabled)
                state = ButtonState.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Enabled)
                state = ButtonState.Normal;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                if (this.Enabled)
                {
                    if (this.RectangleToScreen(this.ClientRectangle).Contains(Cursor.Position))
                        state = ButtonState.Hover;
                    else
                        state = ButtonState.Normal;
                }
                this.Invalidate();
            }
            catch { }
            base.OnMouseUp(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            focused = true;
            this.Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            focused = false;
            this.Invalidate();
            base.OnLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
                state = ButtonState.Normal;
            else
                state = ButtonState.Disabled;

            this.Invalidate();
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Enabled && e.Button == MouseButtons.Left)
            {
                state = ButtonState.Pushed;
                this.Focus();
                focused = true;
            }
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            DrawBorder(e.Graphics);

            switch (state)
            {
                case ButtonState.Normal:
                    if (focused)
                        DrawHoverState(e.Graphics);
                    else
                        DrawNormalState(e.Graphics);
                    break;
                case ButtonState.Hover:
                    DrawHoverState(e.Graphics);
                    break;
                case ButtonState.Pushed:
                    DrawPushedState(e.Graphics);
                    break;
                case ButtonState.Disabled:
                    DrawNormalState(e.Graphics); //DrawForeground takes care of drawing the disabled state
                    break;
                default:
                    break;
            }

            DrawText(e.Graphics);
            if (img != null) DrawImage(e.Graphics);
        }

        protected override void OnClick(EventArgs e)
        {
            if (state == ButtonState.Pushed)
                base.OnClick(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.PerformClick();
            base.OnPreviewKeyDown(e);
        }
        #endregion

        #region  ~ Отрисовка ~
        void DrawBorder(Graphics g)
        {
            if (state == ButtonState.Pushed)
            {
                g.DrawPath(new Pen(Color.FromArgb(59, 59, 59)),
                                    RoundedRect(0, 0, this.Width - 1, this.Height - 1, 2));
                g.DrawPath(new Pen(Color.FromArgb(109, 109, 109)), RoundedRect(1, 1, this.Width - 3, this.Height - 3, 1));
            }
            else
            {
                g.DrawPath(new Pen(Color.FromArgb(137, 137, 137)),
                    RoundedRect(0, 0, this.Width - 1, this.Height - 1, 2));
                g.DrawPath(new Pen(Color.White), RoundedRect(1, 1, this.Width - 3, this.Height - 3, 1));
            }
        }

        void DrawNormalState(Graphics g)
        {
            float width = (float)(this.Width - 1);
            float height = (float)(this.Height - 1);

            RectangleF topRect = new RectangleF(1.5F, 1.5F, width - 3F, (height - 3F) / 2F);
            LinearGradientBrush lgbTop = new LinearGradientBrush(topRect,
                Color.WhiteSmoke, Color.FromArgb(223, 223, 223), LinearGradientMode.Vertical);

            RectangleF botRect = new RectangleF(1.5F, (height - 1F) / 2F, width - 3F, (height - 1F) / 2F);
            LinearGradientBrush lgbBottom = new LinearGradientBrush(botRect,
                            Color.FromArgb(206, 206, 206), Color.FromArgb(230, 230, 230), LinearGradientMode.Vertical);

            g.FillRectangle(lgbTop, topRect);
            g.FillRectangle(lgbBottom, botRect);

            lgbTop.Dispose();
            lgbBottom.Dispose();
        }

        void DrawHoverState(Graphics g)
        {
            float width = (float)(this.Width - 1);
            float height = (float)(this.Height - 1);

            RectangleF topRect = new RectangleF(1.5F, 1.5F, width - 3F, (height - 3F) / 2F);
            LinearGradientBrush lgbTop = new LinearGradientBrush(topRect,
                Color.FromArgb(248, 248, 248), Color.FromArgb(240, 240, 240),
                LinearGradientMode.Vertical);

            RectangleF botRect = new RectangleF(1.5F, (height - 1.5F) / 2F, width - 3F, (height - 1F) / 2F);
            LinearGradientBrush lgbBottom = new LinearGradientBrush(botRect,
                            Color.FromArgb(235, 235, 235), Color.FromArgb(245, 245, 245),
                            LinearGradientMode.Vertical);

            g.FillRectangle(lgbTop, topRect);
            g.FillRectangle(lgbBottom, botRect);

            lgbTop.Dispose();
            lgbBottom.Dispose();
        }

        void DrawPushedState(Graphics g)
        {
            float width = (float)(this.Width - 1);
            float height = (float)(this.Height - 1);

            g.FillRectangle(new SolidBrush(Color.FromArgb(109, 109, 109)),
                1.5F, 1.5F, width - 3F, height - 3F);
        }

        void DrawText(Graphics g)
        {
            if (text == null) return;

            int x = img == null ? 0 : 16;

            TextRenderer.DrawText(g, text, this.Font,
                new Rectangle(x + 2, 0, this.Width - x, this.Height - 1),
                Color.WhiteSmoke,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                (WordEllipsis ? TextFormatFlags.WordEllipsis : TextFormatFlags.WordBreak));
            TextRenderer.DrawText(g, text, this.Font,
                new Rectangle(x + 1, 0, this.Width - x, this.Height - 2),
                this.Enabled ? Color.Black : SystemColors.GrayText,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                (WordEllipsis ? TextFormatFlags.WordEllipsis : TextFormatFlags.WordBreak));
        }

        void DrawImage(Graphics g)
        {
            if (this.Enabled)
                g.DrawImage(Image, 4, (this.Height - 16) / 2);
            else
                g.DrawImage(GetGrayscaleImage(Image), 4, (this.Height - 16) / 2);
        }
        #endregion

        #region ~ Свойства ~
        [Browsable(true)]
        public string ButtonText
        {
            get { return text; }
            set
            {
                text = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        public bool WordEllipsis
        { get; set; }

        [Browsable(true)]
        public Bitmap Image
        {
            get { return img; }
            set
            {
                if (value != null && value.Size == imgEtalon)
                {
                    img = value;
                }
                else
                    img = null;
                this.Invalidate();
            }
        }
        #endregion

        #region ~ События ~
        public void PerformClick()
        {
            base.OnClick(EventArgs.Empty);
        }
        #endregion

        #region ~ Help функции ~
        private GraphicsPath RoundedRect(int x, int y, int width, int height, int radius)
        {
            Rectangle baseRect = new Rectangle(x, y, width, height);
            int diameter = radius * 2;
            Size sizeF = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Изображение когда enabled = false
        Bitmap GetGrayscaleImage(Bitmap original)
        {
            //Set up the drawing surface
            Bitmap grayscale = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(grayscale);

            //Grayscale Color Matrix
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                                                      {
                                                         new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                                                         new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                                                         new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                                                         new float[] {0, 0, 0, 1, 0},
                                                         new float[] {0, 0, 0, 0, 1}
                                                      });

            //Create attributes
            ImageAttributes att = new ImageAttributes();
            att.SetColorMatrix(colorMatrix);

            //Draw the image with the new attributes
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, att);

            //Clean up
            g.Dispose();
            att.Dispose();

            return grayscale;
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
            base.Dispose(disposing);
        }
    }
}