using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;
using SoundSpectrumVisualisation;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        MMDevice device;     
        public Form1()
        {
            MMDeviceEnumerator me = new MMDeviceEnumerator();
            device = me.EnumerateAudioEndPoints(DataFlow.All,DeviceState.Active)[0];
            InitializeComponent();
          //  bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }
        List<int> pancnt;
        private void Form1_Load(object sender, EventArgs e)
        {
            pancnt = new List<int>();
            timer1.Start();
            timer2.Start();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void musicTrackBar1_Click(object sender, EventArgs e)
        {
           
        }
        double lastpeak = 0;
        bool pancake = false;
        private double minAmplitude = 0.045;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lastpeak = peak;
            
            //if (Math.Abs(lastpeak - peak) > 0.2 && !pancake)
            //{
            //    pancake = true;
            //    panpos = (int)peak;
            //}
            //else if (panpos >= 3*pictureBox1.Width/4)
            //{
            //    pancake = false;
            //    panpos = 0;
            //}
            if (lastpeak > device.AudioMeterInformation.MasterPeakValue)
            {
                if (lastpeak - device.AudioMeterInformation.MasterPeakValue < minAmplitude)
                    peak = device.AudioMeterInformation.MasterPeakValue-minAmplitude;//*(lastpeak - device.AudioMeterInformation.MasterPeakValue);
                else peak = device.AudioMeterInformation.MasterPeakValue;
            }
            else if (lastpeak < device.AudioMeterInformation.MasterPeakValue) {
                if (-lastpeak + device.AudioMeterInformation.MasterPeakValue < minAmplitude)
                    peak = device.AudioMeterInformation.MasterPeakValue + minAmplitude; //*(-lastpeak + device.AudioMeterInformation.MasterPeakValue);
                else peak = device.AudioMeterInformation.MasterPeakValue;
            } 
              //  peak = device.AudioMeterInformation.MasterPeakValue+(lastpeak<peak?(Math.Abs(lastpeak-peak)<0.25?(lastpeak/2+0.25):lastpeak/4): (Math.Abs(lastpeak-peak)<0.25 ? (lastpeak / 2 -0.25) : lastpeak / 4));
            //pictureBox1.Invalidate();
            if (Math.Abs(lastpeak - peak) > 0.055)
                pancnt.Add(0);
            label1.Text = "" + device.AudioMeterInformation.PeakValues[0]+" "+device.AudioMeterInformation.PeakValues[1]+" "+ device.AudioMeterInformation.MasterPeakValue;
        }

        private void musicTrackBar1_Click_1(object sender, EventArgs e)
        {
           // timer1.Stop();
            
        }
        double peak=0;
        Bitmap bmp;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < pancnt.Count; i++)
            {
              //  e.Graphics.DrawEllipse(new Pen(Color.Green), /pictureBox1.Width / 2 - pancnt[i] / 2, pictureBox1.Height / 2 - pancnt[i] / 2, pancnt[i], pancnt[i]);
            }
            
          //  e.Graphics.FillEllipse(new SolidBrush(Color.Red), pictureBox1.Width / 2 - (float)(150 * peak)/2, pictureBox1.Height / 2 - (float)(150 * peak)/2, (float)(150 * peak), (float)(150 * peak));
        }
        int panpos = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < pancnt.Count; i++)
            {
                pancnt[i] += 10;
             //   if (pancnt[i] >= 3 * pictureBox1.Height / 3)
              //      pancnt.Remove(pancnt[i]);
            }
            Invalidate();
        //    musicTrackBar1.Value += 1;
        //    label1.Text =""+ musicTrackBar1.Value;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //soundSpectrum2.StartVisualization();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        //    soundSpectrum2.StopVisualization();
            Application.Exit();
        }

        private void soundSpectrum2_Click(object sender, EventArgs e)
        {
          //  button1.Text = "" + soundSpectrum2.bricks_h;
          //  for (int i = 0; i < soundSpectrum2.Y.Length; i++)
         //       richTextBox1.Text += "" + soundSpectrum2.Y[i] + "\r\n";
        }
    }
}
