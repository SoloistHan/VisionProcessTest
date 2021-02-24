using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProcessTest
{
    public partial class Form_Main
    {
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Rv);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Gv);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Bv);
        }
        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] A = new byte[fastPixel.nx, fastPixel.ny];
            for (int Y = 0; Y < fastPixel.ny; Y++)
            {
                for (int X = 0; X < fastPixel.nx; X++)
                {
                    byte Gray = (byte)(fastPixel.Rv[X, Y] * 0.299 + fastPixel.Gv[X, Y] * 0.587 + fastPixel.Bv[X, Y] * 0.114);
                    A[X, Y] = Gray;
                }
            }
            PictureBox_Main.Image = fastPixel.GrayImg(A);
        }

        private void rGLowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] A = new byte[fastPixel.nx, fastPixel.ny];
            for (int Y = 0; Y < fastPixel.ny; Y++)
            {
                for (int X = 0; X < fastPixel.nx; X++)
                {
                    if (fastPixel.Rv[X, Y] > fastPixel.Gv[X, Y])
                        A[X, Y] = fastPixel.Gv[X, Y];
                    else
                        A[X, Y] = fastPixel.Rv[X, Y];
                }
            }
            PictureBox_Main.Image = fastPixel.GrayImg(A);
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] A = new byte[fastPixel.nx, fastPixel.ny];
            for (int Y = 0; Y < fastPixel.ny; Y++)
            {
                for (int X = 0; X < fastPixel.nx; X++)
                {
                    if ( fastPixel.Gv[X, Y] < 128)
                        A[X, Y] = 1;
                }
            }
            PictureBox_Main.Image = fastPixel.BinaryImg(A);
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] A = new byte[fastPixel.nx, fastPixel.ny];
            for (int Y = 0; Y < fastPixel.ny; Y++)
            {
                for (int X = 0; X < fastPixel.nx; X++)
                {
                    A[X, Y] = (byte)(255 - fastPixel.Rv[X, Y]);
                }
            }
            PictureBox_Main.Image = fastPixel.GrayImg(A);
        }
    }
}
