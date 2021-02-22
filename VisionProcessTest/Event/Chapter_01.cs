using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProcessTest
{
    public partial class Form_Main
    {
        private void CH_01_Red()
        {
            if (PictureBox_Main.Image != null)
            {
                PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Rv);
            }
        }
        private void CH_01_Green()
        {
            if (PictureBox_Main.Image != null)
            {
                PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Gv);
            }
        }
        private void CH_01_Blue()
        {
            if (PictureBox_Main.Image != null)
            {
                PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Bv);
            }
        }
    }
}
