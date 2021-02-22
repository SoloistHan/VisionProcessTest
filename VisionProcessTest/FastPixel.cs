using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisionProcessTest
{
    public class FastPixel
    {
        public int nx, ny;
        public byte[,] Rv, Gv, Bv;
        byte[] RGB;
        BitmapData ImgData;
        IntPtr ptr;
        int n_All, n_Line, n_Byte;  // 影像總位元組數 ; 單行位元組數 ; 單點位元組數

        private void  LockBMP(Bitmap bmp)
        {
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            ImgData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, bmp.PixelFormat);
            ptr = ImgData.Scan0;
            n_Line = ImgData.Stride;
            n_Byte = (int)Math.Floor((double)n_Line / (double)bmp.Width);
            n_All = n_Line * bmp.Height;
            RGB = new byte[n_All];

            Marshal.Copy(ptr, RGB, 0, n_All);
        }

        private void UnlockBMP(Bitmap bmp)
        {
            Marshal.Copy(RGB, 0, ptr, n_All);
            bmp.UnlockBits(ImgData);
        }

        public void Bmp2RGB(Bitmap bmp)
        {
            nx = bmp.Width;  ny = bmp.Height;
            Rv = new byte[nx, ny];  Gv = new byte[nx, ny];  Bv = new byte[nx, ny];
            LockBMP(bmp);
            for (int Line = 0; Line < ny; Line++)
            {
                int LineData = Line * ImgData.Stride;
                for (int Column = 0; Column < nx; Column++)
                {
                    int AllData = LineData + Column * n_Byte;
                    Rv[Column, Line] = RGB[AllData + 2];
                    Gv[Column, Line] = RGB[AllData + 1];
                    Bv[Column, Line] = RGB[AllData];
                }
            }
            UnlockBMP(bmp);
        }

        public Bitmap GrayImg(byte[,] b)
        {
            Bitmap bitmap = new Bitmap(b.GetLength(0), b.GetLength(1));
            LockBMP(bitmap);
            for (int First = 0; First < b.GetLength(1); First++)
            {
                for (int Sec = 0; Sec < b.GetLength(0); Sec++)
                {
                    int k = First * n_Line + Sec * n_Byte;
                    byte c = b[Sec, First];
                    RGB[k] = c;
                    RGB[k + 1] = c;
                    RGB[k + 2] = c;
                    RGB[k + 3] = 255;
                }
            }
            UnlockBMP(bitmap);
            return bitmap;
        }

        public Bitmap BinaryImg(byte[,] b)
        {
            Bitmap bitmap = new Bitmap(b.GetLength(0), b.GetLength(1));
            LockBMP(bitmap);
            for (int First = 0; First < b.GetLength(1); First++)
            {
                for (int Sec = 0; Sec < b.GetLength(0); Sec++)
                {
                    int k = First * n_Line + Sec * n_Byte;
                    if (b[Sec, First] == 1)
                    {
                        RGB[k] = 0; RGB[k + 1] = 0; RGB[k + 2] = 0;
                    }
                    else
                    {
                        RGB[k] = 255; RGB[k + 1] = 255; RGB[k + 2] = 255;
                    }
                    RGB[k + 3] = 255;
                }
            }
            UnlockBMP(bitmap);
            return bitmap;
        }
    }
}
