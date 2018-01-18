using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void musicPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void musicPlayer1_OnPaused(object sender, EventArgs e)
        {
            MessageBox.Show("Pause");
        }

        private void musicPlayer1_OnPlaying(object sender, EventArgs e)
        {
            MessageBox.Show("Play");
        }

        private void musicPlayer1_OnSwitchingTrackForward(object sender, EventArgs e)
        {
            MessageBox.Show("Forward");
        }

        private void musicPlayer1_OnVolumeValueChanged(object sender, SoundTrackBar.ValueEventArgs e)
        {
            MessageBox.Show(""+e.Value);
        }

        private void musicPlayer1_OnrTrackBarValueChanged(object sender, SoundTrackBar.ValueEventArgs e)
        {
            MessageBox.Show("" + e.Value);
        }

        private void musicPlayer1_OnTrackBarValueChanged(object sender, SoundTrackBar.ValueEventArgs e)
        {
        }

        private void musicPlayer1_Click_1(object sender, EventArgs e)
        {

        }

        private void musicPlayer1_Click_2(object sender, EventArgs e)
        {

        }

        private void soundSpectrum1_Click(object sender, EventArgs e)
        {

        }
    }
}
