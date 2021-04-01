using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionProcessTest
{    
    public partial class Form_Main
    {
        bool ch05_Control = false;

        int minH_05 = 25, maxH_05 = 40;
        int minW_05 = 18, maxW_05 = 60;
        int Tgmax_05 = 20;

        //int minH_05 = 20, maxH_05 = 80;
        //int minW_05 = 2, maxW_05 = 80;
        //int Tgmax_05 = 20;

        byte[,] Z_ch05; // 二值化陣列
        byte[,] Q_ch05; // 輪廓線陣列
        //int Gdim_ch05 = 40; // 計算區域亮度區塊的寬與高
        int Gdim_ch05 = 10; // 20210330 EPISIL_Camera setting value = 10
        int[,] Th_ch05; // 每區塊平均亮度 
        ArrayList C_ch05; // 目標物件集合
        Bitmap Mb_ch05;
        Rectangle rectangle;

//-------------------------------------------Outline_Ch05----------------------------------------------------------------------

        private void outline05ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Z_ch05 = DoBinary(B);
            Q_ch05 = Outline_ch04(Z_ch05);
            PictureBox_Main.Image = fastPixel.BinaryImg(Q_ch05);
        }

        private byte[,] DoBinary(byte[,] b)
        {
            Th_ch05 = ThresholdBuild(b, Gdim_ch05, Th_ch05);
            Z_ch05 = new byte[fastPixel.nx, fastPixel.ny];
            for (int First = 1; First < fastPixel.nx - 1; First++)
            {
                int x = First / Gdim_ch05;
                for (int Second = 1; Second < fastPixel.ny - 1; Second++)
                {
                    int y = Second / Gdim_ch05;
                    if (fastPixel.Gv[First, Second] < Th_ch05[x, y])
                        Z_ch05[First, Second] = 1;
                }
            }
            return Z_ch05;
        }

//-------------------------------------GeTarget_Ch05--------------------------------------------------------------------------------

        private void targets05ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            C_ch05 = getTargets_05(Q_ch05);
            Bitmap bitmap = new Bitmap(fastPixel.nx, fastPixel.ny);
            //for (int First = 0; First <= 10; First++)
            for (int First = 0; First < C_ch05.Count; First++)
            {
                TgInfo tgInfo = (TgInfo)C_ch05[First];
                for (int Second = 0; Second < tgInfo.P.Count; Second++)
                {
                    Point point = (Point)tgInfo.P[Second];
                    bitmap.SetPixel(point.X, point.Y, Color.Black);
                }
            }
            PictureBox_Main.Image = bitmap;
            Mb_ch05 = (Bitmap)bitmap.Clone();
        }

        private ArrayList getTargets_05(byte[,] q)
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

                    if (Z_ch05[First - 1, Second] == 1)
                        continue;
                    G.width = G.xmx - G.xmn + 1; // 寬度計算
                    G.height = G.ymx - G.ymn + 1; // 高度計算

                    if (G.height < minH_05)
                        continue;
                    if (G.height > maxH_05)
                        continue;
                    if (G.width < minW_05)
                        continue;
                    if (G.width > maxW_05)
                        continue;
                    G.cx = (G.xmn + G.xmx) / 2;
                    G.cy = (G.ymn + G.ymx) / 2;

                    for(int Third = 0; Third < G.P.Count; Third++)
                    {
                        int pm = PointPm((Point)G.P[Third]);
                        if (pm > G.pm) //取得高對比 輪廓點
                            G.pm = pm;
                    }
                    A.Add(G);
                }
            }
            for (int First = 0; First <= Tgmax_05; First++)
            {
                if (First > A.Count - 1)
                    break;
                for (int Second = First + 1; Second < A.Count ; Second++)
                {
                    TgInfo T = (TgInfo)A[First], G = (TgInfo)A[Second];
                    if (T.pm < G.pm) // 互換位置 高對比目標在前
                    {
                        A[First] = G;
                        A[Second] = T;
                    }
                }
            }

            C_ch05 = new ArrayList();
            for (int First = 0; First < Tgmax_05; First++)
            {
                if (First > A.Count - 1)
                    break;

                TgInfo T = (TgInfo)A[First];
                T.ID = First;
                C_ch05.Add(T);
            }
            return C_ch05;
        }


        private void align05ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList R = AlignTgs(C_ch05);
            Bitmap bmp = (Bitmap)Mb_ch05.Clone();

            for (int First = 0; First < R.Count; First++)
            {
                TgInfo T = (TgInfo)R[First];
                if (First == 0) //搜尋的中心目標畫成實心
                {
                    for (int Second = T.xmn; Second <= T.xmx; Second++)
                    {
                        for (int Third = T.ymn; Third <= T.ymx; Third++)
                        {
                            if (Z_ch05[Second, Third] == 1)
                                bmp.SetPixel(Second, Third, Color.Yellow);

                        }
                    }
                }
                else // 畫輪廓
                {
                    for (int Sec = 0; Sec < T.P.Count; Sec++)
                    {
                        Point point = (Point)T.P[Sec];
                        bmp.SetPixel(point.X, point.Y, Color.Red);
                    }
                }
            }
            Graphics Gr = Graphics.FromImage(bmp);
            Gr.DrawRectangle(Pens.Lime, rectangle);
            PictureBox_Main.Image = bmp;
        }

        private ArrayList AlignTgs(ArrayList C)
        {
            ArrayList R = new ArrayList();
            int pmx = 0; //最佳目標組合與最佳對比度

            for (int First = 0; First < C.Count; First++)
            {
                TgInfo tgInfo = (TgInfo)C[First];
                ArrayList D = new ArrayList();
                int Dm = 0;
                D.Add(tgInfo);
                Dm = tgInfo.pm;

                int x1 = (int)(tgInfo.cx - tgInfo.height * 2); //搜尋X範圍
                int x2 = (int)(tgInfo.cx + tgInfo.height * 2); //搜尋X範圍
                int y1 = (int)(tgInfo.cy - tgInfo.height * 1); //搜尋Y範圍
                int y2 = (int)(tgInfo.cy + tgInfo.height * 1); //搜尋Y範圍

                for (int Second = 0; Second < C.Count; Second++)
                {
                    if (First == Second)
                        continue; // 與起點重複 略過

                    TgInfo G = (TgInfo)C[Second];
                    if (G.cx < x1)
                        continue;
                    if (G.cx > x2)
                        continue;
                    if (G.cy < y1)
                        continue;
                    if (G.cy > y2)
                        continue;
                    if (G.width > tgInfo.height) continue;
                    //if (G.height > T.height * 1.5) continue;
                    if (G.height > tgInfo.height) continue;
                    D.Add(G);
                    Dm += G.pm; // 合格目標加入集合
                    if (D.Count >= 4)
                        break;
                }
                if (Dm > pmx)
                {
                    pmx = Dm;
                    R = D;
                    rectangle = new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1); //搜尋範圍
                }
            }
            return R;
        }
    }
}
