using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionProcessTest
{
    public class BLL_NewObject : Form_Main
    {
        public static void NewSome(Control Where)
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Name = "MenuStrip01";
            menuStrip.Items.Add("TEST");
            Where.Controls.Add(menuStrip);
        }
    }
}
