﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProcessTest
{
    public partial class Form_Main
    {
        private void InitialObj()
        {
            PictureBox_Main.Top = MenuStrip_Main.Height;
            PictureBox_Main.Left = 0;
            PictureBox_Main.Image = VisionProcessTest.Properties.Resources.TEST_01;

            this.Height = MenuStrip_Main.Height + PictureBox_Main.Height;
            this.Width = PictureBox_Main.Width;
        }
    }
}