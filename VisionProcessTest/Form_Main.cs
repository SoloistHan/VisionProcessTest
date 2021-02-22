using System;
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
            InitialObj();
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

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CH_01_Red();
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CH_01_Green();
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CH_01_Blue();
        }
    }
}
