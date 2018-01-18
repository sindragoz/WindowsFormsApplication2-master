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
            //Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox2.Text)
            //try
            //{
            //    e.Graphics.DrawLine(new Pen(Color.Gray,5), Convert.ToInt32(textBox1.Text), 0, Convert.ToInt32(textBox1.Text), 30);
            //}
            //catch { }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 256; i++)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, i, 0)), i, 0, 1, 30);
            //try
            //{
            //    e.Graphics.DrawLine(new Pen(Color.Gray), Convert.ToInt32(textBox3.Text), 0, Convert.ToInt32(textBox3.Text), 30);
            //}
            //catch { }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 256; i++)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, i)), i, 0, 1, 30);
            //try
            //{
            //    e.Graphics.DrawLine(new Pen(Color.Gray), Convert.ToInt32(textBox2.Text), 0, Convert.ToInt32(textBox2.Text), 30);
            //}
            //catch { }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = (e as MouseEventArgs).X+"";
           // pictureBox2.Invalidate();
            setUsedColor();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = (e as MouseEventArgs).X + "";
          //  pictureBox3.Invalidate();
            setUsedColor();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (e as MouseEventArgs).X + "";
         //   pictureBox1.Invalidate();
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
            //openFileDialog1.ShowDialog();
            //if (openFileDialog1.FileName != null && openFileDialog1.FileName != "") {
            //    try
            //    {
            //        img = Image.FromFile(openFileDialog1.FileName);
            //        pictureBox5.BackgroundImage = img;
            //        textBox4.Text = openFileDialog1.FileName;
            //    }
            //    catch { MessageBox.Show("Wrong file format!"); }
            //        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
