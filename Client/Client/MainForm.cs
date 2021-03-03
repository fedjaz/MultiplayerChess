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
            chessClient = new ChessClient(pictureBox1);

            Bitmap b = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(b);
            for(int i = 0; i < 8; i++)
            {
                bool isWhite = (i % 2) == 0;
                
                for(int j = 0; j < 8; j++)
                {
                    Color color;
                    if(isWhite)
                    {
                        color = Color.FromArgb(214, 189, 109);
                    }
                    else
                    {
                        color = Color.FromArgb(128, 51, 0);
                    }

                    g.FillRectangle(new SolidBrush(color), 125 * i, 125 * j, 125, 125);
                    isWhite = !isWhite;
                }
            }
            b.Save("Board.png");
        }
    }
}
