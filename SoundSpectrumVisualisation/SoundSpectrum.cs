using ElementBaseView;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundSpectrumVisualisation
{

    public class SoundSpectrum : BaseElement
    {
        private IWaveIn waveIn;
        private static int fftLength = 64;
        float[] h_sectors;
        float h_s_size;
        Timer catch_harmonics;
        Timer slowly_change;  
      //  int zero_sectors = fftLength;
        public float[] Y {
        get { return y; } }
        public float []last_y;
        int maxbricks;
        public float bricks_h=15;
        private SampleAggregator sampleAggregator = new SampleAggregator(fftLength);
        public SoundSpectrum()
        {
            this.DoubleBuffered = true;
            maxbricks =40;
           // delta = new float[zero_sectors];   
            y = new float[fftLength];
            last_y = new float[fftLength ];
            catch_harmonics = new Timer() { Interval = 50 };
            slowly_change = new Timer() { Interval = 5 };
            slowly_change.Tick += Slowly_change_Tick;
            catch_harmonics.Tick += timer1_Tick;          
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
            sampleAggregator.PerformFFT = true;
            waveIn = new WasapiLoopbackCapture();
            waveIn.DataAvailable += OnDataAvailable;
            setdelta = new bool[fftLength];
            
            
            this.DoubleBuffered = true;

        }
        public void StartVisualization() {
            waveIn.StartRecording();
            catch_harmonics.Start();
            slowly_change.Start();
        }
        public void StopVisualization() {
            waveIn.StopRecording();
        }
       
        private void nullifyDelta(){
            for (int i = 0; i < fftLength ; i++) {
                setdelta[i] = false;
            }
        }
        float delta;
        float mindelta = 5;
        bool[] setdelta;
        int change_steps = 0;
        float bricks = 0;
        private void Slowly_change_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < fftLength; i++)
            {
                 // if (!setdelta[i])
                   //{
                delta = (y[i] - last_y[i])/ 10;
               
               // if (Math.Abs(y[i] - last_y[i]) <0.05)
               // {
               //        delta += (delta / Math.Abs(delta))*mindelta;
              // }
               //        setdelta[i] = true;

                  //  }
                last_y[i] += delta;
                Invalidate();
            }
            change_steps++;
            if (change_steps == 9)
            {
                slowly_ch_started = false;
           //     nullifyDelta();
                change_steps = 0;
               // slowly_change.Stop();

            }
        }
        //RectangleF []bricks_rects;

        float min = 2;
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
        float[] y;
        bool slowly_ch_started=false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            for (int i = 0, j = 0; i < fftLength; i++, j++)
            {
                
                if (i == fftLength )
                    i += fftLength ;
               
                if (c != null)
                {


                      if (!slowly_ch_started)
                    
                          {
                        last_y[j] = y[j];
                      //  slowly_change.Start();
                        slowly_ch_started = true;
                           }
                    y[j] = ((Math.Abs(c[i].X) * Height/0.1 < Height)? (float)(Math.Abs(c[i].X) * Height / 0.1) : Height - 1);
                    if (y[j] < 4)
                        y[j] *=10;
                    if (y[j] < 1)
                        y[j] *= 100;

                    //     Invalidate();
                }
            }
        }
            
            
            
        
        //private float findmaxHarmonic() {
        //    float max = 0;
        //    for (int i = 0; i < fftLength / 2; i++)
        //    {
        //    }
        //}
        public float H_S_Size {
        get { return h_s_size;
            }
            set
            {
                h_s_size = value;
            }
        }


        bool addbrick = false;
        int delta_color =20;
        byte pref_R;
        byte pref_G;
        byte pref_B;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            bricks_h = Height / maxbricks;
            bricks_h = bricks_h > 1 ? bricks_h : 1;
            h_sectors = new float[fftLength];
            h_s_size = Width/(float)(fftLength);
            SolidBrush br = new SolidBrush(Theme);
            
            SolidBrush bgbr = new SolidBrush(BackColor);
            pref_R = br.Color.R;
            pref_G = br.Color.G;
            pref_B = br.Color.B;
            for (int i = 0; i < fftLength; i++)
            {
                h_sectors[i] = (float)i * h_s_size;
                e.Graphics.FillRectangle(br, h_sectors[i],Height-bricks_h, h_s_size, bricks_h);

            }
            //   h_s_rects = new RectangleF[fftLength];
            
            
            for (int i =0; i <fftLength ; i++)
            {
                addbrick=false;
                bricks = last_y[i] / bricks_h;
                br.Color = Color.FromArgb(pref_R,pref_G,pref_B);
                for (int k = 1; k <= bricks;k++) {
                    if (y[i] - last_y[i] > 0.05 && y[i] - last_y[i] < 0.25&&!addbrick)
                    {
                        bricks++;
                        addbrick = true;
                    }
                    if (br.Color.R >= br.Color.G && br.Color.R >= br.Color.B)
                    {
                        br.Color = Color.FromArgb(br.Color.R, br.Color.G + delta_color <= 255 ? br.Color.G + delta_color : br.Color.G - delta_color, br.Color.B);
                    }
                    if (br.Color.G >= br.Color.R && br.Color.G >= br.Color.B)
                    {
                        br.Color = Color.FromArgb(br.Color.R, br.Color.G, br.Color.B + delta_color <= 255 ? br.Color.B + delta_color : br.Color.B - delta_color);
                    }
                    if (br.Color.B >= br.Color.R && br.Color.B >= br.Color.G)
                    {
                        br.Color = Color.FromArgb(br.Color.R, br.Color.G + delta_color <= 255 ? br.Color.G + delta_color : br.Color.G - delta_color, br.Color.B);
                    }
                    // br.Color = Color.FromArgb(br.Color.R - delta_color > 0 ? br.Color.R - delta_color : br.Color.R+ delta_color, br.Color.G - delta_color > 0 ? br.Color.G - delta_color : br.Color.G+ delta_color, br.Color.B - delta_color > 0 ? br.Color.B - delta_color : br.Color.B+ delta_color);
                    e.Graphics.FillRectangle(br, h_sectors[i],Height- k * bricks_h, h_s_size, bricks_h);             
                }

                //h_s_rects[i] = new RectangleF(h_sectors[i],0,h_s_size-1,Height);
                //   e.Graphics.FillRectangle(br, h_sectors[i], 0, h_s_size, last_y[i]);
                if(bricks_h>1)
                for (int k=0;k<maxbricks;k++)
                e.Graphics.FillRectangle(bgbr, 0, Height - bricks_h * k - 1, Width, 1);
                e.Graphics.FillRectangle(bgbr, h_sectors[i],0,1,Height);
                
                // e.Graphics.DrawLine(p, 0, 0, Width, (float)(Height * Math.Sin(i * 360.0 / fftLength)));

            }
            
            
            
        }
    }
}

