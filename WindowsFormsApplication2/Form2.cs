using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        private IWaveIn waveIn;
        private static int fftLength = 8; // NAudio fft wants powers of two!

        // There might be a sample aggregator in NAudio somewhere but I made a variation for my needs
        private SampleAggregator sampleAggregator = new SampleAggregator(fftLength);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            prbr = new List<ProgressBar>();
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
            sampleAggregator.PerformFFT = true;

            // Here you decide what you want to use as the waveIn.
            // There are many options in NAudio and you can use other streams/files.
            // Note that the code varies for each different source.
        }
        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                byte[] buffer = e.Buffer;
                int bytesRecorded = e.BytesRecorded;
                int bufferIncrement = waveIn.WaveFormat.BlockAlign;

                for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                {
                    float sample32 = BitConverter.ToSingle(buffer, index);
                    sampleAggregator.Add(sample32);
                }
            }
        }
        Complex[] c;
        void FftCalculated(object sender, FftEventArgs e)
        {
            c = e.Result;
            //e.Result;
            // Do something with e.result!
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fillprbr();

        }
        List<ProgressBar> prbr;
        void fillprbr()
        {

            
            
            // foreach (var a in this.Controls)
            //    if (a is ProgressBar)
            //       prbr.Add(a as ProgressBar);
            // prbr.AddRange(this.Controls.OfType<ProgressBar>());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            for (int i = 0; i < 8; i++)
               prbr[i].Value=(int)(Math.Sqrt(c[i].X * c[i].X + c[i].Y * c[i].Y)*1000)<prbr[i].Maximum? (int)(Math.Sqrt(c[i].X * c[i].X + c[i].Y * c[i].Y) * 1000): prbr[i].Maximum-1;
        }

        private void button2_Click(object sender, EventArgs e)
        { 
         //   for (int i = 0; i < soundSpectrum1.Y.Length; i++)
          //      richTextBox1.Text += "sp[" +i+"]="+ soundSpectrum1.Y[i] + "\r\n";
        }

        private void playBtn1_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void musicPlayer1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void musicPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}
