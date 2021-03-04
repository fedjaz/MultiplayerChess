using System;
using ChessController;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Client
{
    class ChessClient
    {
        public delegate void Deativating();
        public event Deativating Deactivate; 
        ChessGame ChessGame { get; set; }
        ChessPiecePicturebox[,] PiecePictureboxes;
        List<Move> StoredMoves;

        PictureBox Parent;
        ChessPiecePicturebox Activated { get; set; }

        public ChessClient(PictureBox parent)
        {
            ChessGame = new ChessGame();
            PiecePictureboxes = new ChessPiecePicturebox[8, 8];
            StoredMoves = new List<Move>();
            Parent = parent;
            parent.MouseDown += ClickOnControl;

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(ChessGame.Board[i, j] != null)
                    {
                        ChessPiecePicturebox piecePicturebox =
                            new ChessPiecePicturebox(ChessGame.Board[i, j], (i, j), parent);
                        Parent.Controls.Add(piecePicturebox);
                        piecePicturebox.Clicked += PieceClicked;
                        Deactivate += piecePicturebox.Deactivate;
                        PiecePictureboxes[i, j] = piecePicturebox;
                    }
                }
            }
        }

        void PieceClicked((int, int) piecePos)
        {
            if(Activated != null && piecePos == Activated.PiecePos)
            {
                return;
            }
            else
            {
                int i = piecePos.Item1, j = piecePos.Item2;
                Parent.Image = Properties.Resources.Board;
                Deactivate?.Invoke();
                Move move;
                if(IsMovePossible(piecePos, out move))
                {
                    ChessGame.Move(move);
                    ChessPiecePicturebox mainPiece = 
                        PiecePictureboxes[move.FirstPos.Item1, move.FirstPos.Item2];
                    mainPiece.MovePiece(piecePos);
                    PiecePictureboxes[move.FirstPos.Item1, move.FirstPos.Item2] = null;
                    ChessPiecePicturebox toDelete = PiecePictureboxes[i, j];
                    if(toDelete != null)
                    {
                        PiecePictureboxes[i, j] = null;
                        Parent.Controls.Remove(toDelete);
                        toDelete.Dispose();
                    }
                    if(move.MoveType == Move.MoveTypes.EnPassant)
                    {
                        int di = move.SecondaryFirstPos.Item1, dj = move.SecondaryFirstPos.Item2;
                        toDelete = PiecePictureboxes[di, dj];
                        PiecePictureboxes[di, dj] = null;
                        Parent.Controls.Remove(toDelete);
                        toDelete.Dispose();
                    }
                    else if(move.MoveType == Move.MoveTypes.Castling)
                    {
                        i = move.SecondaryFirstPos.Item1;
                        j = move.SecondaryFirstPos.Item2;
                        int di = move.SecondarySecondPos.Item1, dj = move.SecondarySecondPos.Item2;
                        ChessPiecePicturebox castlingPiece = PiecePictureboxes[i, j];
                        castlingPiece.MovePiece(move.SecondarySecondPos);
                        PiecePictureboxes[i, j] = null;
                        PiecePictureboxes[di, dj] = castlingPiece;
                    }
                    PiecePictureboxes[move.SecondPos.Item1, move.SecondPos.Item2] = mainPiece;
                }
                else if(ChessGame.Board[i, j] != null)
                {
                    StoredMoves = ChessGame.GetMoves(piecePos);
                    if(StoredMoves.Count != 0)
                    {
                        PiecePictureboxes[i, j].Activate();
                        DrawMoves(StoredMoves);
                    }       
                }
            }


        }

        void DrawMoves(List<Move> moves)
        {
            Bitmap board = Properties.Resources.Board;
            Bitmap possible = Properties.Resources.Possible;
            Graphics g = Graphics.FromImage(board);
            foreach(Move move in moves)
            {
                int i = move.SecondPos.Item1, j = move.SecondPos.Item2;

                if(PiecePictureboxes[i, j] != null)
                {
                    PiecePictureboxes[i, j].ActivateMove();
                }
                else
                {
                    int cellSize = board.Width / 8;
                    g.DrawImage(possible,
                                new Rectangle(j * cellSize, i * cellSize, cellSize, cellSize));
                }
            }
            Parent.Image = board;
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

        void ClickOnControl(object sender, MouseEventArgs args)
        {
            int cellSize = (sender as Control).Width / 8;
            int i = args.Y / cellSize, j = args.X / cellSize;
            PieceClicked((i, j));
        }
    }
}
