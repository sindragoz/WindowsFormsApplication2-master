using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class ComponentStyleForm : Form
    {
       public Color color;
       public Image img;
        public ComponentStyleForm()
        {
            InitializeComponent();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for(int i=0;i<256;i++)
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(i,0,0)),i,0,1,30);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 256; i++)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, i, 0)), i, 0, 1, 30);
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 256; i++)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, i)), i, 0, 1, 30);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = (e as MouseEventArgs).X+"";
            setUsedColor();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = (e as MouseEventArgs).X + "";
            setUsedColor();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (e as MouseEventArgs).X + "";
            setUsedColor();
        }
        private void setUsedColor() {

            try
            {
                pictureBox4.BackColor = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox2.Text));
                color = pictureBox4.BackColor;
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
