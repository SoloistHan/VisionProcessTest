using System;
using System.Collections.Generic;
using System.Drawing;
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

            fastPixel.Bmp2RGB(Properties.Resources.TEST_01);
            B = fastPixel.Gv; // Ch04
            PictureBox_Main.Image = Properties.Resources.TEST_01;
        }
    }
}
