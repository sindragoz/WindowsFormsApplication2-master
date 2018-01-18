using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Controller
{
    public class Controller
    {
        public WaveOut waveOut;
        Mp3FileReader reader;
        WaveFileReader waveReader;

        public Controller()
        {
            waveOut = new WaveOut();
            waveOut.Volume = (float)1;
        }

        public string TotalTime()
        {
            if (reader != null)
            {
                return String.Format("{0:00}:{1:00}", (int)reader.CurrentTime.TotalMinutes, reader.CurrentTime.Seconds);
            }
            if (waveReader != null)
            {
                return String.Format("{0:00}:{1:00}", (int)waveReader.CurrentTime.TotalMinutes, waveReader.CurrentTime.Seconds);
            }
            return "";
        }

        public string Play()
        {

            if (reader != null)
            {
                waveOut.Play();
                return String.Format("{0:00}:{1:00}", (int)reader.TotalTime.TotalMinutes, reader.TotalTime.Seconds);
            }
            if (waveReader != null)
            {
                waveOut.Play();
                return String.Format("{0:00}:{1:00}", (int)waveReader.TotalTime.TotalMinutes, waveReader.TotalTime.Seconds);
            }
            return "0: 00";
        }
        public void Pause()
        {
            if (reader != null || waveReader != null)
            {
                waveOut.Pause();
            }
        }

        public int NextMusic(int max, int index)
        {
            if (index + 1 >= max || index < 0)
            {
                return 0;
            }
            else
            {
                return ++index;
            }
        }
        public int PrevMusic(int max, int index)
        {
            if (index < 1)
            {
                return max - 1;
            }
            else
            {
                return --index;
            }
        }

        //перемотка
        public void Scroll(float Value)
        {
            if (reader != null)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(reader.TotalTime.TotalSeconds * Value / 100.0);
            }
            if (waveReader != null)
            {
                waveReader.CurrentTime = TimeSpan.FromSeconds(waveReader.TotalTime.TotalSeconds * Value / 100.0);
            }
        }

        public void volume(float volume)
        {
            waveOut.Volume = (1 - volume);
        }

        public void FormatAudio(ListBox listMusicFiles)
        {
            reader = null;
            waveReader = null;
            if ((listMusicFiles.SelectedItem as FileInfo).FullName.EndsWith(".mp3"))
            {
                reader = new Mp3FileReader((listMusicFiles.SelectedItem as FileInfo).FullName);
                //MessageBox.Show((listMusicFiles.SelectedItem as FileInfo).FullName);
                waveOut.Init(reader);
            }
            else
            {
                waveReader = new WaveFileReader((listMusicFiles.SelectedItem as FileInfo).FullName);
                waveOut.Init(waveReader);
            }
        }

    }


}
