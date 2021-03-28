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
        byte[,] B; // 灰階陣列
        private void InitialObj(Bitmap input)
        {
            PictureBox_Main.Top = MenuStrip_Main.Height;
            PictureBox_Main.Left = 0;
            PictureBox_Main.Image = input;
            //PictureBox_Main.Image = VisionProcessTest.Properties.Resources.TEST_01;

            this.Height = MenuStrip_Main.Height + PictureBox_Main.Height + 50;
            this.Width = PictureBox_Main.Width;
            if (this.Width < 360)
                this.Width = 360;
            
            //fastPixel.Bmp2RGB(Properties.Resources.TEST_01);
            fastPixel.Bmp2RGB(input);
            B = fastPixel.Gv; // Ch04
            PictureBox_Main.Image = input;
            //PictureBox_Main.Image = Properties.Resources.TEST_01;
        }
    }
}
