using ElementBaseView;
using MusicList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
   public class MusicPlayer:BaseElement
    {
        //Вперед
        private buttonPlay.NextBtn nextBtn1;
        //Запуск\пауза
        private buttonPlay.PlayBtn playBtn1;
        //Назад
        private buttonPlay.PrevBtn prevBtn1;

        private buttonPlay.SpectreBtn spectreBtn1;
        private buttonPlay.LoadFileBtn loadFileBtn1;
        private buttonPlay.MusicListBtn musicListBtn1;
        private buttonPlay.ChangeStyleBtn ChangeStyleBtn1;

        //Регулятор звука
        private SoundTrackBar.VolumeTrackBar volumeTrackBar1;
        //Обычный трек бар
        private SoundTrackBar.RoundedTrackBar roundedTrackBar1;
        //Круглый трек бар в минимизированном виде
        private SoundTrackBar.MusicTrackBar musicTrackBar1;
        //Визуализатор звука
        private SoundSpectrumVisualisation.SoundSpectrum soundSpectrum1;
        //Лист списка композиций
        private MusicList.MusicList musicList1;
        //Лейбл отсчета времени
        private Label count_time;
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }


        }
        private void InitializeComponent()
        {
            this.count_time = new Label();
            this.nextBtn1 = new buttonPlay.NextBtn();
            this.roundedTrackBar1 = new SoundTrackBar.RoundedTrackBar();
            this.playBtn1 = new buttonPlay.PlayBtn();
            this.prevBtn1 = new buttonPlay.PrevBtn();
            this.volumeTrackBar1 = new SoundTrackBar.VolumeTrackBar();
            this.musicTrackBar1 = new SoundTrackBar.MusicTrackBar();
            this.soundSpectrum1 = new SoundSpectrumVisualisation.SoundSpectrum();
            this.musicList1 = new MusicList.MusicList();
            this.spectreBtn1 = new buttonPlay.SpectreBtn();
            this.loadFileBtn1 = new buttonPlay.LoadFileBtn();
            this.musicListBtn1 = new buttonPlay.MusicListBtn();
            this.ChangeStyleBtn1 = new buttonPlay.ChangeStyleBtn();
            this.SuspendLayout();

            this.count_time.Location = new System.Drawing.Point(275, 255);
            this.count_time.Text = "00:00/00:00";

            this.spectreBtn1.Location = new System.Drawing.Point(1, 190);
            this.spectreBtn1.Size = new System.Drawing.Size(20, 20);
            this.spectreBtn1.Click += SpectreBtn1_Click;

            this.loadFileBtn1.Location = new System.Drawing.Point(1, 215);
            this.loadFileBtn1.Size = new System.Drawing.Size(20, 20);
            this.loadFileBtn1.Click += LoadFileBtn1_Click;

            this.musicListBtn1.Location = new System.Drawing.Point(1, 240);
            this.musicListBtn1.Size = new System.Drawing.Size(20, 20);
            this.musicListBtn1.Click += MusicListBtn1_Click;

            this.ChangeStyleBtn1.Location = new System.Drawing.Point(1, 265);
            this.ChangeStyleBtn1.Size = new System.Drawing.Size(20, 20);
            this.ChangeStyleBtn1.Click += ChangeStyleBtn1_Click;

            this.nextBtn1.Location = new System.Drawing.Point(260, 192);
            this.nextBtn1.Name = "nextBtn1";
            this.nextBtn1.Size = new System.Drawing.Size(60,50);
            this.nextBtn1.TabIndex = 0;
            this.nextBtn1.Text = "nextBtn1";

            // 
            // roundedTrackBar1
            // 
       
            this.roundedTrackBar1.Location = new System.Drawing.Point(145, 165);
            this.roundedTrackBar1.MaximumValue = 100;
            this.roundedTrackBar1.MinimumValue = 0;
            this.roundedTrackBar1.Name = "roundedTrackBar1";
            this.roundedTrackBar1.Size = new System.Drawing.Size(110, 110);
            this.roundedTrackBar1.TabIndex = 0;
            this.roundedTrackBar1.Text = "roundedTrackBar1";
            this.roundedTrackBar1.Theme = System.Drawing.Color.Empty;
            this.roundedTrackBar1.Value = 0;
            // 
            // playBtn1
            // 

            this.playBtn1.Location = new System.Drawing.Point(170, 190);
            this.playBtn1.Name = "playBtn1";
            this.playBtn1.Size = new System.Drawing.Size(60, 60);
            this.playBtn1.TabIndex = 0;
            this.playBtn1.Text = "playBtn1";

            playBtn1.Click += PlayBtn1_Click;
            // 
            // prevBtn1
            // 
            this.prevBtn1.Location = new System.Drawing.Point(85, 192);
            this.prevBtn1.Name = "prevBtn1";
            this.prevBtn1.Size = new System.Drawing.Size(60, 50);
            this.prevBtn1.TabIndex = 0;
            this.prevBtn1.Text = "prevBtn1";
            prevBtn1.Click += PrevBtn1_Click;

            // 
            // volumeTrackBar1
            // 

            this.volumeTrackBar1.Location = new System.Drawing.Point(355, 225);
            this.volumeTrackBar1.MaximumValue = 100;
            this.volumeTrackBar1.MinimumValue = 0;
            this.volumeTrackBar1.Name = "volumeTrackBar1";
            this.volumeTrackBar1.Size = new System.Drawing.Size(20, 60);
            this.volumeTrackBar1.TabIndex = 0;
            this.volumeTrackBar1.Text = "volumeTrackBar1";
            this.volumeTrackBar1.Value = 0;
            // 
            // musicTrackBar1
            // 
            
            this.musicTrackBar1.Location = new System.Drawing.Point(25, 270);
            this.musicTrackBar1.MaximumValue = 100;
            this.musicTrackBar1.MinimumValue = 0;
            this.musicTrackBar1.Name = "musicTrackBar1";
            this.musicTrackBar1.Size = new System.Drawing.Size(310, 20);
            this.musicTrackBar1.TabIndex = 0;
            this.musicTrackBar1.Text = "musicTrackBar1";
            this.musicTrackBar1.Theme = System.Drawing.Color.Empty;
            this.musicTrackBar1.Value = 0;
            // 
            // soundSpectrum1
            // 

            this.soundSpectrum1.H_S_Size = 1F;
            this.soundSpectrum1.Location = new System.Drawing.Point(25, 10);
            this.soundSpectrum1.MaximumSize = this.soundSpectrum1.MinimumSize = this.soundSpectrum1.Size=new System.Drawing.Size(350,150);
            this.soundSpectrum1.Name = "soundSpectrum1";
            this.soundSpectrum1.Size = new System.Drawing.Size(100, 100);
            this.soundSpectrum1.TabIndex = 0;
            this.soundSpectrum1.Text = "soundSpectrum1";
            this.soundSpectrum1.Theme = System.Drawing.Color.Red;

            // 
            // MusicPlayer
            // 
            MaximumSize= MinimumSize= Size = new System.Drawing.Size(400,450);
            this.musicList1.MaximumSize = this.musicList1.MinimumSize = this.musicList1.Size = new System.Drawing.Size(398, 150);
            this.musicList1.Location = new Point(2,300);
            this.Controls.Add(this.nextBtn1);
            this.Controls.Add(this.ChangeStyleBtn1);
            this.Controls.Add(this.musicListBtn1);
            this.Controls.Add(this.spectreBtn1);
            this.Controls.Add(this.loadFileBtn1);
            this.Controls.Add(musicList1);
            this.Controls.Add(this.playBtn1);
            this.Controls.Add(this.roundedTrackBar1);
            this.Controls.Add(this.prevBtn1);
            this.Controls.Add(this.volumeTrackBar1);
            this.Controls.Add(this.musicTrackBar1);
            this.Controls.Add(this.soundSpectrum1);
            this.Controls.Add(this.count_time);
            Application.ApplicationExit += Application_ApplicationExit;
            this.ResumeLayout(true);
            roundedTrackBar1.Visible = false;
           


        }
        private bool minimized=false;
        private void ChangeStyleBtn1_Click(object sender, EventArgs e)
        {
            ChangeStyle();
        }
        private void ChangeStyle()
        {
            if (!minimized&&soundSpectrum1.Visible)
               displaySoundSpectrum(minimized);
            if (!minimized && musicList1.Visible)
                displayMusicList(minimized);

            spectreBtn1.Visible = minimized;
            musicListBtn1.Visible = minimized;
            
            musicTrackBar1.Visible = minimized;
            roundedTrackBar1.Visible = !minimized;
            MaximumSize=MinimumSize= Size = new Size(Width,Height+45 * (minimized ? 1 : -1));
            roundedTrackBar1.Location = new Point(roundedTrackBar1.Location.X, roundedTrackBar1.Location.Y+15 * (minimized ? 1 : -1));
            playBtn1.Location = new Point(playBtn1.Location.X, playBtn1.Location.Y + 15 * (minimized ? 1 : -1));
            prevBtn1.Location = new Point(prevBtn1.Location.X, prevBtn1.Location.Y + 15 * (minimized ? 1 : -1));
            nextBtn1.Location = new Point(nextBtn1.Location.X, nextBtn1.Location.Y + 15 * (minimized ? 1 : -1));
            ChangeStyleBtn1.Location=new Point(ChangeStyleBtn1.Location.X, ChangeStyleBtn1.Location.Y + 40 *(minimized ? 1 : -1));
            loadFileBtn1.Location = new Point(loadFileBtn1.Location.X, loadFileBtn1.Location.Y + 20 * (minimized ? 1 : -1));
            volumeTrackBar1.Location = new Point(volumeTrackBar1.Location.X, volumeTrackBar1.Location.Y + 40 * (minimized ? 1 : -1));
            // foreach (var c in Controls) {
            //     if ((c as Control).Visible)
            //         (c as Control).Location = new Point((c as Control).Location.X, (c as Control).Location.Y+ 20 * (minimized ? 1 : -1));
            //  }
            
            minimized = !minimized;
            ChangeStyleBtn1.setStatementIcon(minimized);

        }
        private void MusicListBtn1_Click(object sender, EventArgs e)
        {
            displayMusicList(!musicList1.Visible);
        }
        //Клик по кнопке выбора файла
        private void LoadFileBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();

        }

        private void SpectreBtn1_Click(object sender, EventArgs e)
        {
            displaySoundSpectrum(!soundSpectrum1.Visible);
        }
        //Клик покнопке назад
        private void PrevBtn1_Click(object sender, EventArgs e)
        {
            
            
        }
        private bool started=false;
        //Клик по кнопке Play
        private void PlayBtn1_Click(object sender, EventArgs e)
        {
            if(!started)
            soundSpectrum1.StartVisualization();
           else
                soundSpectrum1.StopVisualization();
            started = !started;
            playBtn1.setStatementIcon(!started);
            

        }

        public MusicPlayer() {
            InitializeComponent();
            
        }
        private void displayMusicList(bool show)
        {
            musicList1.Visible = show;
            int h = musicList1.Height * (show ? 1 : -1);
            MaximumSize = MinimumSize = Size = new System.Drawing.Size(Size.Width, Size.Height + h);
            //тестовое добавление в список композиций
               musicList1.addItem("Allah Akbar");
            
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            soundSpectrum1.StopVisualization();
        }

        private void displaySoundSpectrum(bool show) {
            soundSpectrum1.Visible = show;
            int h = soundSpectrum1.Height * (show ? 1 : -1);
            

            foreach (var c in Controls) {
                (c as Control).Location=new Point((c as Control).Location.X, (c as Control).Location.Y+h);
            }
            
            MaximumSize = MinimumSize =  Size = new System.Drawing.Size(Size.Width, Size.Height+h);
         //   musicList1.Items.Add();
        }

        private bool set_theme = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BackColor = Color.Black;

                foreach (var c in Controls)
                {
                    (c as Control).MaximumSize = new System.Drawing.Size(1000, 1000);
                    if (c is BaseElement)
                        (c as BaseElement).Theme = Theme;
                    if (c is AbstrButton)
                        (c as AbstrButton).Theme = Theme;
                }
            musicList1.ForeColor = Theme;
            count_time.ForeColor = Theme;
        }
    }
}
