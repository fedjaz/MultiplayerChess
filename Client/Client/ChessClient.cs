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
        ChessGame ChessGame { get; set; }
        ChessPiecePicturebox[,] PiecePictureboxes;
        ChessPiecePicturebox[,] MoveBoxes;
        List<Move> StoredMoves;

        PictureBox Parent;
        ChessPiecePicturebox Activated { get; set; }

        public ChessClient(PictureBox parent)
        {
            ChessGame = new ChessGame();
            PiecePictureboxes = new ChessPiecePicturebox[8, 8];
            MoveBoxes = new ChessPiecePicturebox[8, 8];
            StoredMoves = new List<Move>();
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

                        PiecePictureboxes[i, j] = piecePicturebox;
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
            Move checkMove = null;
            if(IsMovePossible(sender.PiecePos, out checkMove))
            {
                ChessGame.Move(checkMove);
                int i = checkMove.FirstPos.Item1, j = checkMove.FirstPos.Item2;
                int di = checkMove.SecondPos.Item1, dj = checkMove.SecondPos.Item2;
                PiecePictureboxes[i, j].MovePiece(checkMove.SecondPos);

                PiecePictureboxes[di, dj] = PiecePictureboxes[i, j];
                PiecePictureboxes[i, j] = null;
                return;
            }

            if(Activated != null & Activated != sender)
            {
                Activated.Deactivate();
                Activated = null;
            }

            StoredMoves = ChessGame.GetMoves(sender.PiecePos);
            if(StoredMoves.Count == 0)
            {
                return;
            }
            foreach(Move move in StoredMoves)
            {
                int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
                int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;

                if(ChessGame.Board[di, dj] == null)
                {
                    ChessPiecePicturebox moveBox =
                        new ChessPiecePicturebox(null, (di, dj), Parent);
                    moveBox.Clicked += PieceClicked;

                    MoveBoxes[di, dj] = moveBox;
                    moveBox.ActivateMove();
                }
                else
                {
                    PiecePictureboxes[di, dj].ActivateMove();
                }
            }


            sender.Activate();
            Activated = sender;
        }

        bool IsMovePossible((int, int) movePos, out Move outMove)
        {
            foreach(Move move in StoredMoves)
            {
                if(move.SecondPos.Item1 == movePos.Item1 &&
                   move.SecondPos.Item2 == movePos.Item2)
                {
                    outMove = move;
                    return true;
                }
            }
            outMove = null;
            return false;
        }
    }
}
