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
        public Form_Main()
        {
            InitializeComponent();
            BLL_NewObject.NewSome(this);
        }
    }
}
