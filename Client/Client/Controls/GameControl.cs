﻿using System;
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
            ChessClient = new ChessClient(ChessBoard);
        }
    }
}