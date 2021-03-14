using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProcessTest
{
    class TgInfo
    {
        public int np = 0;
        public ArrayList P = null;
        public int xmn = 0, xmx = 0, ymn = 0, ymx = 0; // 四面極座標值
        public int width = 0, height = 0;
        public int pm = 0;
        public int cx = 0;
        public int ID = 0;
    }
    public partial class Form_Main
    {
        byte[,] B; // 灰階陣列
        byte[,] Z_ch04; // 二值化陣列
        byte[,] Q_ch04; // 輪廓線陣列
        int Gdim_ch04 = 25; // 計算區域亮度區塊的寬與高
        int[,] Th_ch04; // 每區塊平均亮度 
        ArrayList C_ch04; // 目標物件集合
        Bitmap Mb;

//---------------------------------------------------------------------------------------------------------------------------

        private void binary04ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Th_ch04 = ThresholdBuild(B);
            Z_ch04 = new byte[fastPixel.nx, fastPixel.ny];
            for (int First = 0; First < fastPixel.nx - 1; First++)
            {
                int x = First / Gdim_ch04;
                for (int Second = 0; Second < fastPixel.ny - 1; Second++)
                {
                    int y = Second / Gdim_ch04;
                    if (fastPixel.Gv[First, Second] < Th_ch04[x, y])
                        Z_ch04[First, Second] = 1;
                }
            }
            PictureBox_Main.Image = fastPixel.BinaryImg(Z_ch04);
        }
        private int[,] ThresholdBuild(byte[,] b)
        {
            int kx = fastPixel.nx / Gdim_ch04, ky = fastPixel.ny / Gdim_ch04;
            Th_ch04 = new int[kx, ky];

            for (int First = 0; First < fastPixel.nx; First++)
            {
                int x = First / Gdim_ch04;
                for (int Second = 0; Second < fastPixel.ny; Second++)
                {
                    int y = Second / Gdim_ch04;
                    Th_ch04[x, y] += fastPixel.Gv[First, Second];
                }
            }
            for (int First = 0; First < kx; First++)
            {
                for (int Second = 0; Second < ky; Second++)
                {
                    Th_ch04[First, Second] /= Gdim_ch04 * Gdim_ch04;
                }
            }
            return Th_ch04;
        }
//---------------------------------------------------------------------------------------------------------------------------

        private void outline04ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Q_ch04 = Outline_ch04(Z_ch04);
            PictureBox_Main.Image = fastPixel.BinaryImg(Q_ch04);
        }

        private byte[,] Outline_ch04(byte[,] b)
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

 //---------------------------------------------------------------------------------------------------------------------------

        private void targetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C_ch04 = getTargets(Q_ch04);
            Bitmap bitmap = new Bitmap(fastPixel.nx, fastPixel.ny);
            for (int First = 0; First < C_ch04.Count - 1; First++)
            {
                TgInfo tgInfo = (TgInfo)C_ch04[First];
                for (int Second = 0; Second < tgInfo.P.Count; Second++)
                {
                    Point point = (Point)tgInfo.P[Second];
                    bitmap.SetPixel(point.X, point.Y, Color.Black);
                }
            }
            PictureBox_Main.Image = bitmap;
        }

        private ArrayList getTargets(byte[,] q)
        {
            ArrayList A = new ArrayList();
            byte[,] b = (byte[,])q.Clone();
            for (int First = 1; First < fastPixel.nx - 1; First++)
            {
                for (int Second = 1; Second < fastPixel.ny - 1; Second++)
                {
                    if (b[First, Second] == 0)
                        continue;
                    TgInfo G = new TgInfo();
                    G.xmn = First; G.xmx = First; G.ymn = Second; G.ymx = Second;
                    G.P = new ArrayList();
                    ArrayList nc = new ArrayList(); // 每一輪搜尋的起點集合
                    nc.Add(new Point(First, Second));
                    G.P.Add(new Point(First, Second));
                    b[First, Second] = 0;

                    do
                    {
                        ArrayList nb = (ArrayList)nc.Clone();
                        nc = new ArrayList(); // 清除準備搜尋下一輪 搜尋起點之集合
                        for (int Third = 0; Third < nb.Count; Third++)
                        {
                            Point p = (Point)nb[Third]; // 搜尋起點
                            // 在此周邊 3X3區域內找輪廓點
                            for (int ii = p.X - 1; ii <= p.X + 1; ii++)
                            {
                                for (int jj = p.Y - 1; jj <= p.Y + 1; jj++)
                                {
                                    if (b[ii, jj] == 0)
                                        continue;
                                    Point k = new Point(ii, jj);
                                    nc.Add(k);
                                    G.P.Add(k);
                                    G.np += 1;
                                    if (ii < G.xmn)
                                        G.xmn = ii;
                                    if (ii > G.xmx)
                                        G.xmx = ii;
                                    if (jj < G.ymn)
                                        G.ymn = jj;
                                    if (jj > G.ymx)
                                        G.ymx = jj;
                                    b[ii, jj] = 0; // 清除輪廓點標記
                                }
                            }
                        }
                    } while (nc.Count > 0);

                    if (Z_ch04[First - 1, Second] == 1)
                        continue;
                    G.width = G.xmx - G.xmn + 1; // 寬度計算
                    G.height = G.ymx - G.ymn + 1; // 高度計算
                    A.Add(G);
                }
            }
            return A;
        }

        //---------------------------------------------------------------------------------------------------------------------------

        int minHeight = 16, maxHeight = 100, minWidth = 2, maxWidth = 100;

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList D = new ArrayList();
            for (int First = 0; First < C_ch04.Count; First++)
            {
                TgInfo tgInfo = (TgInfo)C_ch04[First];
                if (tgInfo.height < minHeight)
                    continue;
                if (tgInfo.height > maxHeight)
                    continue;
                if (tgInfo.width < minWidth)
                    continue;
                if (tgInfo.width > maxWidth)
                    continue;
                D.Add(tgInfo);
            }
            C_ch04 = D;
            Bitmap bitmap = new Bitmap(fastPixel.nx, fastPixel.ny);
            for (int First = 0; First < C_ch04.Count - 1; First++)
            {
                TgInfo tgInfo = (TgInfo)C_ch04[First];
                for (int Second = 0; Second < tgInfo.P.Count; Second++)
                {
                    Point point = (Point)tgInfo.P[Second];
                    bitmap.SetPixel(point.X, point.Y, Color.Black);
                }
            }
            PictureBox_Main.Image = bitmap;
            Mb = (Bitmap)bitmap.Clone();
        }

//---------------------------------------------------------------------------------------------------------------------------


        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
