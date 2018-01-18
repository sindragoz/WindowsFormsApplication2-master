using ElementBaseView;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundSpectrumVisualisation
{

    public class SoundSpectrum : BaseElement
    {
        private IWaveIn waveIn;
        private static int fftLength = 4096;
        float[] spectre_peaks;

        public enum SpectrumForm { Rect, Round };
        private SpectrumForm spectrumF;
        public SpectrumForm Form_of_Spectrum
        {
            get { return spectrumF; }
            set { spectrumF = value; }
        }
        private bool high_detalization = true;
        public bool High_spectre_detalization
        {
            get { return high_detalization; }
            set { high_detalization = value; }
        }
        private int glow_intencity = 150;
        public int Glow_intencity
        {
            get { return glow_intencity; }
            set
            {
                if (value >= 50 && value <= 150)
                    glow_intencity = value;
            }
        }
        public int FFTlength
        {
            get { return fftLength; }
            set
            {
                if (IsPowerOfTwo(value))
                {

                    fftLength = value;
                }

            }
        }
        public int MaxBricks
        {
            get { return maxbricks; }
            set { if (value >= 20 && value <= 60) maxbricks = value; }
        }
        float[] h_sectors;
        float h_s_size;
        Timer catch_harmonics;
        Timer slowly_change;
        public float[] last_y;
        int maxbricks = 40;
        public float bricks_h = 15;
        private int freq_shift = 64;
        private float[] freq_range;
        private SampleAggregator sampleAggregator;
        public SoundSpectrum()
        {
            this.DoubleBuffered = true;

            MMDeviceEnumerator me = new MMDeviceEnumerator();
            catch_harmonics = new Timer() { Interval = 50 };
            catch_harmonics.Tick += timer1_Tick;
            waveIn = new WasapiLoopbackCapture();
            waveIn.DataAvailable += OnDataAvailable;



            this.DoubleBuffered = true;

        }
        private int freq_sort = 5;
        private void set_freq_range()
        {
            //   fr += "||" + freq_shift / freq_sort + "||";
            for (int i = 0; i < freq_sort; i++)
            {
                for (int k = i * freq_shift / freq_sort, d = 0; k < 1 + i * freq_shift / freq_sort + freq_shift / freq_sort; k++, d++)
                {
                    if (freq_range[k] == 0)
                    {
                        if (i == 0)
                            freq_range[k] = 20 + d * 140 / (freq_shift / freq_sort);
                        if (i == 1)
                            freq_range[k] = 140 + d * 400 / (freq_shift / freq_sort);
                        if (i == 2)
                            freq_range[k] = 400 + d * 2600 / (freq_shift / freq_sort);
                        if (i == 3)
                            freq_range[k] = 2600 + d * 5200 / (freq_shift / freq_sort);
                        if (i >= 4)
                            freq_range[k] = 5200 + d * 22050 / (freq_shift / freq_sort);

                        fr += "[" + k + "]" + freq_range[k] + "\n";
                    }
                }

            }
            gnomeSort(freq_range);
        }
        void gnomeSort(float[] a)
        {
            int i = 1;
            while (i < a.Length)
            {
                if (i == 0 || a[i - 1] <= a[i])
                    i++;
                else
                {
                    float temp = a[i];
                    a[i] = a[i - 1];
                    a[i - 1] = temp;
                    i--;
                }
            }
        }
        public void StartVisualization()
        {

            fftLength = high_detalization ? 4096 : 2048;
            freq_shift = high_detalization ? 64 : 32;
            setdelta = new bool[fftLength];
            freq_range = new float[freq_shift];
            y = new float[fftLength];
            last_y = new float[fftLength];
            delta = new float[freq_shift];
            spectre_peaks = new float[freq_shift];
            sampleAggregator = new SampleAggregator(fftLength);
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);
            sampleAggregator.PerformFFT = true;
            last_peaks = new float[freq_shift];
            set_freq_range();
            waveIn.StartRecording();
            slowly_change = new Timer() { Interval = 2 };
            slowly_change.Tick += Slowly_change_Tick;
            slowly_change.Start();
        }
        public void StopVisualization()
        {
            waveIn.StopRecording();
        }

        private void nullifyDelta()
        {
            for (int i = 0; i < fftLength; i++)
            {
                setdelta[i] = false;
            }
        }
        bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }
        float[] delta;
        bool[] setdelta;
        int change_steps = 0;
        float bricks = 0;
        private void Slowly_change_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < freq_shift; i++)
            {
                delta[i] = (spectre_peaks[i] - last_peaks[i]) / 3;
                last_peaks[i] += delta[i];
                Invalidate();
            }
        }


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
        float freq;
        public string freq_str = "";
        bool need_invalidate = false;
        void FftCalculated(object sender, FftEventArgs e)
        {
            c = e.Result;

            freq_str = "";
            if (c != null)
            {
                for (int i = 0; i < spectre_peaks.Length; i++)
                    last_peaks[i] = spectre_peaks[i];
                nullify_spectre_peaks();
                for (int j = 0; j < fftLength / 2; j++)
                {
                    y[j] = (float)((Math.Sqrt(c[j].X * c[j].X + c[j].Y * c[j].Y)));
                    freq = j * 44100f / fftLength;
                    freq_str += freq + "\n";
                    set_spectre_peak(freq, y[j]);

                    Invalidate();
                }
                Invalidate();


            }



        }
        float[] y;
        float[] last_peaks;
        public string fr = "";
        private void nullify_spectre_peaks()
        {
            for (int i = 0; i < freq_shift / 2; i++)
                spectre_peaks[i] = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void set_spectre_peak(float freq, float mag)
        {
            for (int i = 1; i < freq_shift; i++)
            {

                if (freq >= freq_range[i - 1] && freq <= freq_range[i])
                {
                    if (spectre_peaks[i] <= (mag))
                    {

                        spectre_peaks[i] += (mag);


                        return;
                    }
                }

            }
        }
        private float maxY(float[] y)
        {
            float max = y[0];
            for (int i = 0; i < y.Length; i++)
                if (y[i] > max)
                    y[i] = max;
            return max;

        }
        public float H_S_Size
        {
            get
            {
                return h_s_size;
            }
            set
            {
                h_s_size = value;
            }
        }


        bool addbrick = false;
        int delta_color = 20;
        byte pref_R;
        byte pref_G;
        byte pref_B;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (last_y != null)
                if (last_y.Length != 0)
                    e = spectrumF == SpectrumForm.Round ? roundSpectrum(e) : rectSpectrum(e);
        }


        private PaintEventArgs roundSpectrum(PaintEventArgs e)
        {

            Pen p = new Pen(Theme, 3);
            Color glow;
            Color theme_grad = Color.Transparent;
            int R = Theme.R;
            int G = Theme.G;
            int B = Theme.B;
            float low_freq = 0;
            int grad_shift = (int)(delta_color * 4);
            for (int i = 0; i < freq_shift / 5; i++)
            {
                low_freq += last_peaks[i] * 7000;
            }
            if (R - glow_intencity >= 0)
                R -= glow_intencity;
            else R = 0;
            if (G - glow_intencity >= 0)
                G -= glow_intencity;
            else G = 0;
            if (B - glow_intencity >= 0)
                B -= glow_intencity;
            else B = 0;
            float glow_amplitude = 0;
            if (low_freq != 0 && low_freq >= 255)
                glow_amplitude = 255.0f / (low_freq);

            glow = Color.FromArgb((int)(R + glow_amplitude * glow_intencity), (int)(G + glow_amplitude * glow_intencity), (int)(B + glow_amplitude * glow_intencity));

            if (Theme.R >= Theme.G && Theme.R >= Theme.B)
            {
                theme_grad = Color.FromArgb(Theme.R, Theme.G + grad_shift <= 255 ? Theme.G + grad_shift : Theme.G - grad_shift, Theme.B);
            }
            if (Theme.G >= Theme.R && Theme.G >= Theme.B)
            {
                theme_grad = Color.FromArgb(Theme.R, Theme.G, Theme.B + grad_shift <= 255 ? Theme.B + grad_shift : Theme.B - grad_shift);
            }
            if (Theme.B >= Theme.R && Theme.B >= Theme.G)
            {
                theme_grad = Color.FromArgb(Theme.R, Theme.G + grad_shift <= 255 ? Theme.G + grad_shift : Theme.G - grad_shift, Theme.B);
            }

            LinearGradientBrush lgb = new LinearGradientBrush(new PointF(0, 0), new PointF(Width / 8, 0), glow, Color.Transparent);
            LinearGradientBrush lgb_r = new LinearGradientBrush(new PointF(0, 0), new PointF(Width / 8, 0), Color.Transparent, glow);
            float r = Height / 6 + low_freq / (1.25f * freq_shift / 2);
            float rr;
            PointF[] gpoints = new PointF[freq_shift - 4];

            float x_centre;
            float y_centre;
            float x, y, x_rev, y_rev;
            float angle = 0;
            int j = 0;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 2; i < freq_shift - 2; i++, angle += 360.0f / ((float)freq_shift - 4))
            {
                if (i <= freq_shift / 2 - 1)
                    j = i;
                else
                    j = freq_shift - 2 - i;
                x_centre = Width / 2 + r * Convert.ToSingle(Math.Cos(2 * Math.PI * (angle - 85) / 360));
                y_centre = Height / 2 + r * Convert.ToSingle(Math.Sin(2 * Math.PI * (angle - 85) / 360));

                x = x_centre + (last_peaks[j] * 7000 / (3f)) * Convert.ToSingle(Math.Cos(2 * Math.PI * (angle - 86) / 360)) + 1;
                y = y_centre + (last_peaks[j] * 7000 / 3f) * Convert.ToSingle(Math.Sin(2 * Math.PI * (angle - 86) / 360)) + 1;

                try
                {
                    e.Graphics.DrawLine(new Pen(new LinearGradientBrush(new PointF(x_centre, y_centre), new PointF(x, y), Theme, theme_grad), 3), x_centre, y_centre, x, y);
                }
                catch { }
                rr = r - 2 * (last_peaks[j] / (10f)) - Height / 12;
                x_centre = Width / 2 + rr * Convert.ToSingle(Math.Cos(2 * Math.PI * (angle - 85) / 360));
                y_centre = Height / 2 + rr * Convert.ToSingle(Math.Sin(2 * Math.PI * (angle - 85) / 360));

                x = x_centre + (last_peaks[j] * 4000 / (10f)) * Convert.ToSingle(Math.Cos(2 * Math.PI * (angle - 85) / 360));
                y = y_centre + (last_peaks[j] * 4000 / (10f)) * Convert.ToSingle(Math.Sin(2 * Math.PI * (angle - 85) / 360));
                gpoints[i - 2] = new PointF(x, y);

            }
            e.Graphics.DrawPolygon(new Pen(glow, 2), gpoints);

            e.Graphics.FillRectangle(lgb, 0, 0, Width / 8 - 1, Height);
            e.Graphics.FillRectangle(lgb_r, 7 * Width / 8, 0, Width / 8 - 1, Height);
            return e;
        }

        private int det = 64;
        private float sum = 0;
        private PaintEventArgs rectSpectrum(PaintEventArgs e)
        {

            bricks_h = Height / maxbricks;
            bricks_h = bricks_h > 1 ? bricks_h : 1;
            h_sectors = new float[freq_shift / 2];
            h_s_size = Width / (float)(freq_shift / 2);

            SolidBrush br = new SolidBrush(Theme);
            SolidBrush bgbr = new SolidBrush(BackColor);
            pref_R = br.Color.R;
            pref_G = br.Color.G;
            pref_B = br.Color.B;
            for (int i = 0; i < freq_shift / 2; i++)
            {
                h_sectors[i] = (float)i * h_s_size;
                e.Graphics.FillRectangle(br, h_sectors[i], Height - bricks_h, h_s_size, bricks_h);

            }


            for (int i = 2; i < freq_shift / 2; i++)
            {
                addbrick = false;
                bricks = last_peaks[i] * 3200.0f / bricks_h;
                br.Color = Color.FromArgb(pref_R, pref_G, pref_B);
                for (int k = 1; k <= bricks; k++)
                {
                    addbrick = true;
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
                    e.Graphics.FillRectangle(br, h_sectors[i], Height - k * bricks_h, h_s_size, bricks_h);
                }

                if (bricks_h > 1)
                    for (int k = 0; k < maxbricks; k++)
                        e.Graphics.FillRectangle(bgbr, 0, Height - bricks_h * k - 1, Width, 1);
                e.Graphics.FillRectangle(bgbr, h_sectors[i], 0, 1, Height);


            }
            return e;

        }

    }
}

