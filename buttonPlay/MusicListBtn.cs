﻿using ElementBaseView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonPlay
{
    public class MusicListBtn:AbstrButton
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (pic == null)
                pic = Resource1.musiclist;
            pevent.Graphics.DrawImage(pic, 0, 0, Width, Height);
        }
    }
}
