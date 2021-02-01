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
        int n, L, nB;

        private void  LockBMP(Bitmap bmp)
        {
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            ImgData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, bmp.PixelFormat);
            ptr = ImgData.Scan0;
            L = ImgData.Stride;
            nB = (int)Math.Floor((double)L / (double)bmp.Width);
            n = L * bmp.Height;
            RGB = new byte[n];

            Marshal.Copy(ptr, RGB, 0, n);
        }

        private void UnlockBMP(Bitmap bmp)
        {
            Marshal.Copy(RGB, 0, ptr, 0);
            bmp.UnlockBits(ImgData);
        }
    }
}
