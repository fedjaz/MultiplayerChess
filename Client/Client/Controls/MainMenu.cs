using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Controls
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            panel2.Location = new Point((int)(0.33 * panel1.Width), (int)(0.33 * panel1.Height));
            panel2.Size = new Size((int)(0.33 * panel1.Width), (int)(0.33 * panel1.Height));
            button1.Size = new Size(0, (int)(0.4 * panel2.Height));
            button1.TabStop = false;
            button1.FlatAppearance.BorderSize = 0;
            
            button2.Size = new Size(0, (int)(0.4 * panel2.Height));
            button2.TabStop = false;
            button2.FlatAppearance.BorderSize = 0;
        }
    }
}
