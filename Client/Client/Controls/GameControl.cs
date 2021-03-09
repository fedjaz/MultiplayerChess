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
    public partial class GameControl : UserControl
    {
        public delegate void ChatMessageArgs(RichTextBox chat, string message);
        public event ChatMessageArgs ChatMessage;
        ChessClient ChessClient;
        public GameControl()
        {
            InitializeComponent();
        }

        private void GameControl_Resize(object sender, EventArgs e)
        {
            ChessBoard.Size = new Size(Height, Height);
            ChatPanel.Location = new Point(Height, 0);
            ChatPanel.Size = new Size(Width - ChessBoard.Width, Height);
        }

        private void GameControl_Load(object sender, EventArgs e)
        {
            ChessClient = new ChessClient(ChessBoard, new Uri("http://fedjaz-001-site1.gtempurl.com/chess"), this, richTextBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += $"Me: {textBox1.Text}\n";
            ChatMessage?.Invoke(richTextBox1, textBox1.Text);
            textBox1.Text = "";
        }
    }
}
