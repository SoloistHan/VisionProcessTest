using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionProcessTest
{
    public partial class Form_Main : Form
    {
        FastPixel fastPixel = new FastPixel(); 
        public Form_Main()
        {
            InitializeComponent();
            //InitialObj(VisionProcessTest.Properties.Resources.TEST_01);

            Bitmap bitmap = new Bitmap(@"D:\TEST\Test_004.bmp");
            //Bitmap bitmap = new Bitmap(@"D:\Soloist\Project\EPISIL\20200507_Camera_\Picture\20201118_FD-9360\20201118_Front\20201118_163553_TEST.bmp");
            //Bitmap bitmap = new Bitmap(@"D:\Soloist\Project\EPISIL\20200507_Camera_\Picture\20200716\getimg_027.bmp");
            InitialObj(bitmap);
            this.AutoScroll = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFile.FileName);
                fastPixel.Bmp2RGB(bitmap);
                PictureBox_Main.Image = bitmap;
            }
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox_Main.Image = Properties.Resources.TEST_01;
        }

        private void PictureBox_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (ch02_Control == true)
                ch02_FFA(e);
            else if (ch04_Control == true)
                ch04_AreaData(e);
        }

        
    }
}
