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
        ChessClient chessClient;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            int boardSize = (screen.Height / 2) / 8 * 8;
            pictureBox1.Width = boardSize;
            pictureBox1.Height = boardSize;
            Height = boardSize + 41;
            Width = (int)(1.75 * boardSize);
            pictureBox2.Location = new Point(boardSize, 0);
            

            chessClient = new ChessClient(pictureBox1);

           
        }
    }
}
