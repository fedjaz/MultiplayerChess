using System;
using ChessController;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ChessClient
    {
        public delegate void ClickedArgs(ChessPiecePicturebox sender);
        public event ClickedArgs Clicked;
        ChessGame ChessGame { get; set; }
        List<ChessPiecePicturebox> FigurePictureboxes;
        PictureBox Parent;
        ChessPiecePicturebox Activated { get; set; }

        public ChessClient(PictureBox parent)
        {
            ChessGame = new ChessGame();
            FigurePictureboxes = new List<ChessPiecePicturebox>();
            Parent = parent;

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(ChessGame.Board[i, j] != null)
                    {
                        ChessPiecePicturebox piecePicturebox =
                            new ChessPiecePicturebox(ChessGame.Board[i, j], (i, j), parent);
                        piecePicturebox.Clicked += PieceClicked;

                        FigurePictureboxes.Add(piecePicturebox);
                    }
                }
            }
        }

        void PieceClicked(ChessPiecePicturebox sender)
        {
            if(Activated == sender)
            {
                return;
            }
            if(Activated != null & Activated != sender)
            {
                Activated.Deactivate();
                Activated = null;
            }

            List<Move> moves = ChessGame.GetMoves(sender.PiecePos);
            if(moves.Count == 0)
            {
                return;
            }

            sender.Activate();
            Activated = sender;
        }
    }
}
