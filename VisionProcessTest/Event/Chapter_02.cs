using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProcessTest
{
    public partial class Form_Main
    {
        bool ch02_Control = false;

        int ch02_Gdim = 25;  // 將影像分成40*40區塊 做計算  (該直須能將影像長寬"除盡")
        int[,] ch02_Th;  // 每區塊平均亮度
        byte[,] Z;
        byte[,] Q;

        private void ch02_FFA(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Q == null)
                    return;

                int x = e.X;
                int y = e.Y;
                while(Q[x, y] == 0 && x > 0)
                {
                    x--;
                }
                ArrayList A = GetGrp(Q, x, y);
                Bitmap bitmap = fastPixel.BinaryImg(Q);
                for (int k = 0; k < A.Count; k++)
                {
                    Point p = (Point)A[k];
                    bitmap.SetPixel(p.X, p.Y, Color.Red);
                }
                PictureBox_Main.Image = bitmap;
            }
        }

        private ArrayList GetGrp(byte[,] q, int X, int Y)
        {
            if (q[X, Y] == 0)
                return new ArrayList();

            byte[,] b = (byte[,])q.Clone();
            ArrayList nc = new ArrayList();

            nc.Add(new Point(X, Y));
            b[X, Y] = 0;
            ArrayList A = nc; // 此目標中所有目標點的集合

            do
            {
                ArrayList nb = (ArrayList)nc.Clone();
                nc = new ArrayList();
                for (int First = 0; First < nb.Count; First++)
                {
                    Point p = (Point)nb[First]; // 搜尋起點
                    for (int Second = p.X - 1; Second <= p.X + 1; Second++) // 在此點周圍3*3區域內尋找輪廓
                    {
                        for (int Third = p.Y - 1; Third <= p.Y + 1; Third++)
                        {
                            if (b[Second, Third] == 0)
                                continue;
                            Point k = new Point(Second, Third);
                            nc.Add(k);
                            A.Add(k);
                            b[Second, Third] = 0;
                        }
                    }
                }
            }while (nc.Count > 0);
            return A;
        }

        private byte[,] Outline(byte[,] b)
        {
            byte[,] Q = new byte[fastPixel.nx, fastPixel.ny];
            for (int First = 1; First < fastPixel.nx - 1; First++)
            {
                for (int Second = 1; Second < fastPixel.ny - 1; Second++)
                {
                    if (b[First, Second] == 0)
                        continue;
                    if (b[First - 1, Second] == 0)
                    {
                        Q[First, Second] = 1;
                        continue;
                    }
                    if (b[First + 1, Second] == 0)
                    {
                        Q[First, Second] = 1;
                        continue;
                    }
                    if (b[First, Second - 1] == 0)
                    {
                        Q[First, Second] = 1;
                        continue;
                    }
                    if (b[First, Second + 1] == 0)                    
                        Q[First, Second] = 1;                    
                }
            }
            return Q;
        }
        private void outlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Q = Outline(Z);
            PictureBox_Main.Image = fastPixel.BinaryImg(Q);
            ch02_Control = true;
        }
        private void binaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Z = new byte[fastPixel.nx, fastPixel.ny];
            for (int First = 0; First < fastPixel.nx; First++)
            {
                int x = First / ch02_Gdim;
                for (int Second = 0; Second < fastPixel.ny; Second++)
                {
                    int y = Second / ch02_Gdim;
                    if (fastPixel.Gv[First, Second] < ch02_Th[x, y])
                        Z[First, Second] = 1;
                }
            }
            PictureBox_Main.Image = fastPixel.BinaryImg(Z);
        }
        
        private void aveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int kx = fastPixel.nx / ch02_Gdim,  ky = fastPixel.ny / ch02_Gdim;
            ch02_Th = new int[kx, ky];

            for (int First = 0; First < fastPixel.nx; First++) // 累計各區塊亮度總和
            {
                int x = First / ch02_Gdim;
                for (int Sec = 0; Sec < fastPixel.ny; Sec++)
                {
                    int y = Sec / ch02_Gdim;
                    ch02_Th[x, y] += fastPixel.Gv[First, Sec];
                }
            }

            byte[,] A = new byte[fastPixel.nx, fastPixel.ny];
            for (int First = 0; First < kx; First++)
            {
                for (int Sec = 0; Sec < ky; Sec++)
                {
                    ch02_Th[First, Sec] /= ch02_Gdim * ch02_Gdim;
                    for (int Third = 0; Third < ch02_Gdim; Third++)
                    {
                        for (int Fourth = 0; Fourth < ch02_Gdim; Fourth++)
                        {
                            A[First * ch02_Gdim + Third, Sec * ch02_Gdim + Fourth] = (byte)ch02_Th[First, Sec];
                        }
                    }
                }
            }
            PictureBox_Main.Image = fastPixel.GrayImg(A);
        }
        private void grayGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox_Main.Image = fastPixel.GrayImg(fastPixel.Gv);
        }
    }
}
