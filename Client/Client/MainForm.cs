using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        Controls.GameControl GameControl;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            int boardSize = (screen.Height / 2) / 8 * 8;
            Height = boardSize + 43;
            Width = (int)(1.75 * boardSize);
            GameControl = new Controls.GameControl();
            GameControl.Location = new Point(0, 0);
            GameControl.Size = new Size(panel1.Width, boardSize);
            panel1.Controls.Add(GameControl);
            //Font.Size = 40;
        }
    }
}
