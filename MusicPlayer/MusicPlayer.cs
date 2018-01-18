using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Design;
using System.ComponentModel;
using Controller;

namespace MusicPlayer
{
    public class MusicPlayer : BaseElement
    {
        //Вперед
        Controller.Controller cont = new Controller.Controller();
        private buttonPlay.NextBtn nextBtn1 = new buttonPlay.NextBtn();
        //Запуск\пауза
        private buttonPlay.PlayBtn playBtn1 = new buttonPlay.PlayBtn();
        //Назад
        private buttonPlay.PrevBtn prevBtn1 = new buttonPlay.PrevBtn();

        private buttonPlay.SpectreBtn spectreBtn1 = new buttonPlay.SpectreBtn();
        private buttonPlay.LoadFileBtn loadFileBtn1 = new buttonPlay.LoadFileBtn();
        private buttonPlay.MusicListBtn musicListBtn1 = new buttonPlay.MusicListBtn();
        private buttonPlay.ChangeStyleBtn ChangeStyleBtn1 = new buttonPlay.ChangeStyleBtn();

        //Регулятор звука
        private SoundTrackBar.VolumeTrackBar volumeTrackBar1;
        //Обычный трек бар
        private SoundTrackBar.RoundedTrackBar roundedTrackBar1;
        //Круглый трек бар в минимизированном виде
        private SoundTrackBar.MusicTrackBar musicTrackBar1;
        //Визуализатор звука
        private SoundSpectrumVisualisation.SoundSpectrum soundSpectrum1 = new SoundSpectrumVisualisation.SoundSpectrum();
        //Лист списка композиций
        private MusicList.MusicList musicList1 = new MusicList.MusicList();
        //Лейбл отсчета времени
        private Label count_time = new Label();
        
        private List<Rectangle> comp_rect_list;
        private List<string> comp_name_list;


        public List<string> CompNameList {
            get { return comp_name_list; }
        }
        private void InitializeComponent()
        {
                    //Регулятор звука
        volumeTrackBar1 = new SoundTrackBar.VolumeTrackBar(cont);
        //Обычный трек бар
      roundedTrackBar1 = new SoundTrackBar.RoundedTrackBar(cont);
        //Круглый трек бар в минимизированном виде
        musicTrackBar1 = new SoundTrackBar.MusicTrackBar(cont);
        BackColor = Color.Black;
            if (comp_rect_list == null)
            {
                comp_rect_list = new List<Rectangle>();
                comp_name_list = new List<string>();
                comp_rect_list.Add(new Rectangle(275, 255, 25, 8));
                comp_name_list.Add("00:00");
                comp_rect_list.Add(new Rectangle(1, 190, 20, 20));
                comp_name_list.Add("ili");
                comp_rect_list.Add(new Rectangle(1, 215, 20, 20));
                comp_name_list.Add("f");
                comp_rect_list.Add(new Rectangle(1, 240, 20, 20));
                comp_name_list.Add(":=");
                comp_rect_list.Add(new Rectangle(1, 265, 20, 20));
                comp_name_list.Add("st");
                comp_rect_list.Add(new Rectangle(260, 192, 60, 50));
                comp_name_list.Add("> >");
                comp_rect_list.Add(new Rectangle(145, 165, 110, 110));
                comp_name_list.Add("rTrackBar");
                comp_rect_list.Add(new Rectangle(170, 190, 60, 60));
                comp_name_list.Add("| |");
                comp_rect_list.Add(new Rectangle(85, 192, 60, 50));
                comp_name_list.Add("< <");
                comp_rect_list.Add(new Rectangle(355, 225, 20, 60));
                comp_name_list.Add("V");
                comp_rect_list.Add(new Rectangle(25, 270, 310, 20));
                comp_name_list.Add("trackBar");
                comp_rect_list.Add(new Rectangle(25, 10, 350, 150));
                comp_name_list.Add("ililililili");
                comp_rect_list.Add(new Rectangle(2, 300, 398, 150));
                comp_name_list.Add("1.-\n2.-\n3.-");
            }

            this.count_time.Location = comp_rect_list[0].Location;
            this.count_time.Text = "00:00/00:00";

            this.spectreBtn1.Location = comp_rect_list[1].Location;
            this.spectreBtn1.Size = comp_rect_list[1].Size;
            this.spectreBtn1.Click += SpectreBtn1_Click;

            this.loadFileBtn1.Location = comp_rect_list[2].Location;
            this.loadFileBtn1.Size = comp_rect_list[2].Size;
            this.loadFileBtn1.Click += LoadFileBtn1_Click;

            this.musicListBtn1.Location = comp_rect_list[3].Location;
            this.musicListBtn1.Size = comp_rect_list[3].Size;
            this.musicListBtn1.Click += MusicListBtn1_Click;

            this.ChangeStyleBtn1.Location = comp_rect_list[4].Location;
            this.ChangeStyleBtn1.Size = comp_rect_list[4].Size;
            this.ChangeStyleBtn1.Click += ChangeStyleBtn1_Click;

            this.nextBtn1.Location = comp_rect_list[5].Location;
            this.nextBtn1.Name = "nextBtn1";
            this.nextBtn1.Size = comp_rect_list[5].Size;
            this.nextBtn1.TabIndex = 0;
            this.nextBtn1.Text = "nextBtn1";

            // 
            // roundedTrackBar1
            // 

            this.roundedTrackBar1.Location = comp_rect_list[6].Location;
            this.roundedTrackBar1.MaximumValue = 100;
            this.roundedTrackBar1.MinimumValue = 0;
            this.roundedTrackBar1.Name = "roundedTrackBar1";
            this.roundedTrackBar1.Size = comp_rect_list[6].Size;
            this.roundedTrackBar1.TabIndex = 0;
            this.roundedTrackBar1.Text = "roundedTrackBar1";
            this.roundedTrackBar1.Theme = System.Drawing.Color.Empty;
            this.roundedTrackBar1.Value = 0;
            // 
            // playBtn1
            // 

            this.playBtn1.Location = comp_rect_list[7].Location;
            this.playBtn1.Name = "playBtn1";
            this.playBtn1.Size = comp_rect_list[7].Size;
            this.playBtn1.TabIndex = 0;
            this.playBtn1.Text = "playBtn1";

            playBtn1.Click += PlayBtn1_Click;
            // 
            // prevBtn1
            // 
            this.prevBtn1.Location = comp_rect_list[8].Location;
            this.prevBtn1.Name = "prevBtn1";
            this.prevBtn1.Size = comp_rect_list[8].Size;
            this.prevBtn1.TabIndex = 0;
            this.prevBtn1.Text = "prevBtn1";
            //prevBtn1.Click += NextBtn1_Click;

            // 
            // volumeTrackBar1
            // 

            this.volumeTrackBar1.Location = comp_rect_list[9].Location;
            this.volumeTrackBar1.MaximumValue = 100;
            this.volumeTrackBar1.MinimumValue = 0;
            this.volumeTrackBar1.Name = "volumeTrackBar1";
            this.volumeTrackBar1.Size = comp_rect_list[9].Size;
            this.volumeTrackBar1.TabIndex = 0;
            this.volumeTrackBar1.Text = "volumeTrackBar1";
            this.volumeTrackBar1.Value = 0;
            // 
            // musicTrackBar1
            // 

            this.musicTrackBar1.Location = comp_rect_list[10].Location;
            this.musicTrackBar1.MaximumValue = 100;
            this.musicTrackBar1.MinimumValue = 0;
            this.musicTrackBar1.Name = "musicTrackBar1";
            this.musicTrackBar1.Size = comp_rect_list[10].Size;
            this.musicTrackBar1.TabIndex = 0;
            this.musicTrackBar1.Text = "musicTrackBar1";
            this.musicTrackBar1.Theme = System.Drawing.Color.Empty;
            this.musicTrackBar1.Value = 0;
            // 
            // soundSpectrum1
            // 

            this.soundSpectrum1.H_S_Size = 1F;
            this.soundSpectrum1.Location = comp_rect_list[11].Location;
            this.soundSpectrum1.Size = comp_rect_list[11].Size;
            this.soundSpectrum1.Name = "soundSpectrum1";
            this.soundSpectrum1.TabIndex = 0;
            this.soundSpectrum1.Text = "soundSpectrum1";
            this.soundSpectrum1.Theme = System.Drawing.Color.Red;
            this.musicList1.SelectedIndexChanged += MusicList1_SelectedIndexChanged;
            // 
            // MusicPlayer
            // 
            MinimumSize = Size = new System.Drawing.Size(400, 450);
            this.musicList1.Size = comp_rect_list[12].Size;
            this.musicList1.Location = comp_rect_list[12].Location;
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


            prevBtn1.Click += PrevBtn1_Click;
            nextBtn1.Click += NextBtn1_Click;
            musicList1.MouseDoubleClick += MusicList1_MouseDoubleClick;
            //roundedTrackBar1.va
            t1.Tick += printTime;
            t1.Interval = 200;

        }

        private void MusicList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            play_composition = false;
        }

        private bool show_rTrackBar = false;
        private void ChangeStyleBtn1_Click(object sender, EventArgs e)
        {
            ChangeStyle();
        }
        private void ChangeStyle()
        {

            musicTrackBar1.Visible = show_rTrackBar;
            roundedTrackBar1.Visible = !show_rTrackBar;
            show_rTrackBar = !show_rTrackBar;
            ChangeStyleBtn1.setStatementIcon(show_rTrackBar);
        }
        private void PrevBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                cont.Pause();
                musicList1.SelectedIndex = cont.PrevMusic(musicList1.Items.Count, musicList1.SelectedIndex);
                MusicList1_MouseDoubleClick(sender, e as MouseEventArgs);
            }
            catch (Exception ex)
            {

            }
        }

        private void NextBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                cont.Pause();
                musicList1.SelectedIndex = cont.NextMusic(musicList1.Items.Count, musicList1.SelectedIndex);
                MusicList1_MouseDoubleClick(sender, e as MouseEventArgs);
            }
            catch (Exception ex)
            {

            }


        }
        private void MusicList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            play_composition = true;
            if (!started)
            {
                cont.FormatAudio(musicList1);
                roundedTrackBar1.Value = musicTrackBar1.Value = 0;
                t1.Enabled = true;
                all_time = cont.Play();
                soundSpectrum1.StartVisualization();
                count_time.Text = cont.TotalTime() + ": " + all_time;
                playBtn1.setStatementIcon(started);
                started = !started;
            }
            else
            {
                t1.Enabled = false;
                cont.Pause();
                soundSpectrum1.StopVisualization();
                started = !started;
                MusicList1_MouseDoubleClick(sender, e);
            }


        }

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        private bool started = false;
        bool isPlaying;
        string all_time;
        bool play_composition=false;
        //Клик по кнопке Play
        private void PlayBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!started)
                {
                    if (!play_composition) {
                        play_composition = true;
                        cont.FormatAudio(musicList1);
                        roundedTrackBar1.Value = musicTrackBar1.Value = 0;
                    }
                    t1.Enabled = true;
                    all_time = cont.Play();
                    soundSpectrum1.StartVisualization();
                    count_time.Text = cont.TotalTime() + ": " + all_time;
                    playBtn1.setStatementIcon(started);
                    started = !started;
                }
                else
                {
                    t1.Enabled = false;
                    cont.Pause();
                    soundSpectrum1.StopVisualization();
                    playBtn1.setStatementIcon(started);
                    started = !started;
                }
            }
            catch (Exception ex)
            {

            }

        }


        private void MusicListBtn1_Click(object sender, EventArgs e)
        {
            displayMusicList(!musicList1.Visible);
        }
        //Клик по кнопке выбора файла
        private void LoadFileBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                musicList1.Items.Clear();
                OpenFileDialog music_file = new OpenFileDialog();
                music_file.Filter = "Файлы Музыки (*.wav,*.aiff,*.mp3,*.aac)|*.wav;*.aiff;*.mp3;*.aac";

                if (music_file.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(music_file.FileName);
                    List<string> files = new List<string>();
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (var fi in di.GetFiles())
                    {
                        if (fi.Name.EndsWith(".mp3") || fi.Name.EndsWith(".wav") || fi.Name.EndsWith(".aiff") || fi.Name.EndsWith(".aac"))
                        {
                            musicList1.Items.Add(fi);
                        }
                    }
                }
                musicList1.SelectedIndex = 0;
            }
            catch
            {

            }



        }

        private void SpectreBtn1_Click(object sender, EventArgs e)
        {
            displaySoundSpectrum(!soundSpectrum1.Visible);
        }
        //Клик покнопке назад


        //Клик по кнопке Play
        

        public MusicPlayer() {
            InitializeComponent();

        }
        private void displayMusicList(bool show)
        {
            musicList1.Visible = show;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            soundSpectrum1.StopVisualization();
        }

        private void displaySoundSpectrum(bool show) {
            soundSpectrum1.Visible = show;
        }

        private bool set_theme = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            musicList1.BackColor = soundSpectrum1.BackColor = loadFileBtn1.BackColor=spectreBtn1.BackColor=ChangeStyleBtn1.BackColor=musicListBtn1.BackColor= BackColor;

            if (useTheme)
            {
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
            else {
                nextBtn1.Theme = next_clr;
                prevBtn1.Theme = prev_clr;
                playBtn1.Theme = play_clr;
                soundSpectrum1.Theme = spectrum_clr;
                volumeTrackBar1.Theme = volume_clr;
                musicTrackBar1.Theme = Mus_bar_clr;
                roundedTrackBar1.Theme = rounded_bar_clr;
                musicList1.ForeColor = mus_list_clr;
                count_time.ForeColor = count_time_clr;
                if (File_img != null)
                    loadFileBtn1.Picture = File_img;
                if (Spectrum_img != null)
                    spectreBtn1.Picture = Spectrum_img;
                if (Muslist_img != null)
                    musicListBtn1.Picture = Muslist_img;
                if (Sytle_img != null)
                    ChangeStyleBtn1.Picture = Sytle_img;
                if (Next_img != null)
                    nextBtn1.Picture = Next_img;
                if (prev_img != null)
                    prevBtn1.Picture = prev_img;
                if (Play_img != null)
                    playBtn1.Picture = Play_img;
            }
        }
        float time;
        protected void printTime(object sender, EventArgs e)
        {
            try
            {

                time = Convert.ToInt32(all_time.Split(':')[0]) * 60 + Convert.ToInt32(all_time.Split(':')[1]);
                roundedTrackBar1.Value = musicTrackBar1.Value += 1 / (time / 100) / 5;
                count_time.Text = cont.TotalTime() + ": " + all_time;
                if (cont.TotalTime().Equals(all_time))
                {
                    NextBtn1_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle PlayBtnLocation
        {
            get { return new Rectangle(playBtn1.Location, playBtn1.Size); }
            set
            {
                playBtn1.Location = value.Location;
                playBtn1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle PrevBtnLocation
        {
            get { return new Rectangle(prevBtn1.Location, prevBtn1.Size); }
            set
            {
                prevBtn1.Location = value.Location;
                prevBtn1.Size = value.Size;
            }
        }
        //
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle NextBtnLocation
        {
            get { return new Rectangle(nextBtn1.Location, nextBtn1.Size); }
            set
            {
                nextBtn1.Location = value.Location;
                nextBtn1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle SpectrumLocation
        {
            get { return new Rectangle(soundSpectrum1.Location, soundSpectrum1.Size); }
            set
            {
                soundSpectrum1.Location = value.Location;
                soundSpectrum1.Size = value.Size;
            }
        }
        //
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle rTrackBarLocation
        {
            get { return new Rectangle(roundedTrackBar1.Location, roundedTrackBar1.Size); }
            set
            {
                roundedTrackBar1.Location = value.Location;
                roundedTrackBar1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle TrackBarLocation
        {
            get { return new Rectangle(musicTrackBar1.Location, musicTrackBar1.Size); }
            set
            {
                musicTrackBar1.Location = value.Location;
                musicTrackBar1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle VolumeBarBtnLocation
        {
            get { return new Rectangle(volumeTrackBar1.Location, volumeTrackBar1.Size); }
            set
            {
                volumeTrackBar1.Location = value.Location;
                volumeTrackBar1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle MusicListLocation
        {
            get { return new Rectangle(musicList1.Location, musicList1.Size); }
            set
            {
                musicList1.Location = value.Location;
                musicList1.Size = value.Size;
            }
        }

        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle TimerLocation
        {
            get { return new Rectangle(count_time.Location, count_time.Size); }
            set
            {
                count_time.Location = value.Location;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle FileBtnLocation
        {
            get { return new Rectangle(loadFileBtn1.Location, loadFileBtn1.Size); }
            set
            {
                loadFileBtn1.Location = value.Location;
                loadFileBtn1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle SpectrumBtnLocation
        {
            get { return new Rectangle(spectreBtn1.Location, spectreBtn1.Size); }
            set
            {
                spectreBtn1.Location = value.Location;
                spectreBtn1.Size = value.Size;
            }
        }
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle MusicListBtnLocation
        {
            get { return new Rectangle(musicListBtn1.Location, musicListBtn1.Size); }
            set
            {
                musicListBtn1.Location = value.Location;
                musicListBtn1.Size = value.Size;
            }
        }
        //
        [
            Category("Components' Location"),
            Editor(typeof(ComponentLayerEditor), typeof(UITypeEditor)),
        ]
        public Rectangle rTrackBarBtnLocation
        {
            get { return new Rectangle(ChangeStyleBtn1.Location, ChangeStyleBtn1.Size); }
            set
            {
                ChangeStyleBtn1.Location = value.Location;
                ChangeStyleBtn1.Size = value.Size;
            }
        }
        private bool useTheme = false;
        public bool UseTheme {
            get { return useTheme; }
            set { useTheme = value;
                Invalidate();

            }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Play_clr { get => play_clr; set => play_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Prev_clr { get => prev_clr; set => prev_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Next_clr { get => next_clr; set => next_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Volume_clr { get => volume_clr; set => volume_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Spectrum_clr { get => spectrum_clr; set => spectrum_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Mus_list_clr { get => mus_list_clr; set => mus_list_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Rounded_bar_clr { get => rounded_bar_clr; set => rounded_bar_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Count_time_clr { get => count_time_clr; set => count_time_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image File_img { get => file_img; set => file_img = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image Muslist_img { get => muslist_img; set => muslist_img = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image Spectrum_img { get => spectrum_img; set => spectrum_img = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image Sytle_img { get => sytle_img; set => sytle_img = value; }
        public SoundSpectrumVisualisation.SoundSpectrum.SpectrumForm Form_Of_Sectre{
            get { return soundSpectrum1.Form_of_Spectrum; }
            set { soundSpectrum1.Form_of_Spectrum = value; }
            }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Mus_bar_clr { get => mus_bar_clr; set => mus_bar_clr = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image Prev_img { get => prev_img; set => prev_img = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image Next_img { get => next_img; set => next_img = value; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Image Play_img { get => play_img; set => play_img = value; }
        public bool High_spectre_detalization {
        get { return soundSpectrum1.High_spectre_detalization; }
            set { soundSpectrum1.High_spectre_detalization = value; }
        }
        Color play_clr=Color.Lime;
        Color prev_clr = Color.Lime;
        Color next_clr = Color.Lime;
        Color volume_clr = Color.Lime;
        Color mus_bar_clr = Color.Lime;
        Color spectrum_clr = Color.Lime;
        Color mus_list_clr = Color.Lime;
        Color rounded_bar_clr = Color.Lime;
        Color count_time_clr = Color.Lime;
        Image file_img = null;
        Image muslist_img = null;
        Image spectrum_img = null;
        Image sytle_img = null;
        Image prev_img = null;
        Image next_img = null;
        Image play_img = null;
        //путь к директории для правильных дочерних элементов


        #region DeleteProperty
        // залоченные свойства




        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get { return Color.Black; }
            set { ForeColor = Color.Black; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get { return RightToLeft.No; }
            set { RightToLeft = RightToLeft.No; }
        }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize
        {
            get { return false; }
            set { AutoSize = false; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AllowDrop
        {
            get { return false; }
            set { AllowDrop = false; }
        }
        
        #endregion

        #region Events







        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseCaptureChanged
        {
            add { }
            remove { }
        }



        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Scroll
        {
            add { }
            remove { }
        }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PreviewKeyDown
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Layout
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MarginChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Move
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Resize
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseDown
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseEnter
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseHover
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseLeave
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseMove
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseUp
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragDrop
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragEnter
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragLeave
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragOver
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler GiveFeedback
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler QueryContinueDrag
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ChangeUICues
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ControlAdded
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ControlRemoved
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler HelpRequested
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Load
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler QueryAccessibilityHelp
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler StyleChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler SystemColorsChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler AutoSizeChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler AutoValidateChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackColorChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageLayoutChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BindingContextChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler CausesValidationChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ClientSizeChanged
        {
            add { }
            remove { }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ContextMenuChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ContextMenuStripChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler CursorChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DockChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler EnabledChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler LocationChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ParentChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RegionChanged
        {
            add { }
            remove { }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler SizeChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabIndexChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler VisibleChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Enter
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Leave
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Validated
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Validating
        {
            add { }
            remove { }
        }

        #endregion
        public new event EventHandler OnPaused
        {
            add { playBtn1.OnPause += value; }
            remove { playBtn1.OnPause -= value; }
        }
        public new event EventHandler OnPlaying
        {
            add { playBtn1.OnPlay += value; }
            remove { playBtn1.OnPlay -= value; }
        }
        public new event EventHandler OnSwitchingTrackForward
        {
            add { nextBtn1.Click += value; }
            remove { nextBtn1.Click -= value; }
        }
        public new event EventHandler OnSwitchingTrackBackward
        {
            add { prevBtn1.Click += value; }
            remove { prevBtn1.Click -= value; }
        }
        public new event EventHandler<SoundTrackBar.ValueEventArgs> OnVolumeValueChanged
        {
            add { volumeTrackBar1.OnValueChanged += value; }
            remove { volumeTrackBar1.OnValueChanged -= value; }
        }
        public new event EventHandler<SoundTrackBar.ValueEventArgs> OnTrackBarValueChanged
        {
            add { musicTrackBar1.OnValueChanged += value; }
            remove { musicTrackBar1.OnValueChanged -= value; }
        }
        public new event EventHandler<SoundTrackBar.ValueEventArgs> OnrTrackBarValueChanged
        {
            add { roundedTrackBar1.OnValueChanged += value; }
            remove { roundedTrackBar1.OnValueChanged -= value; }
        }
    }
}

