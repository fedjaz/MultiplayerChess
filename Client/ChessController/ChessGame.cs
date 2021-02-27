using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController
{
    public class ChessGame
    {
        public Pieces.ChessPiece[,] Board { get; set; }
        public Pieces.ChessPiece.Colors WhoseMoving { get; set; }

        public ChessGame()
        {
            SetupGame();
        }

        public void SetupGame()
        {
            WhoseMoving = Pieces.ChessPiece.Colors.White;
            Board = new Pieces.ChessPiece[8, 8];
            #region Pawns
            for(int i = 0; i < 8; i++)
            {
                Board[1, i] = new Pieces.Pawn(Pieces.ChessPiece.Colors.Black);
                Board[6, i] = new Pieces.Pawn(Pieces.ChessPiece.Colors.White);
            }
            #endregion
            #region Rooks
            Board[0, 0] = new Pieces.Rook(Pieces.ChessPiece.Colors.Black);
            Board[0, 7] = new Pieces.Rook(Pieces.ChessPiece.Colors.Black);
            Board[7, 0] = new Pieces.Rook(Pieces.ChessPiece.Colors.White);
            Board[7, 7] = new Pieces.Rook(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Knights
            Board[0, 1] = new Pieces.Knight(Pieces.ChessPiece.Colors.Black);
            Board[0, 6] = new Pieces.Knight(Pieces.ChessPiece.Colors.Black);
            Board[7, 1] = new Pieces.Knight(Pieces.ChessPiece.Colors.White);
            Board[7, 6] = new Pieces.Knight(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Bishops
            Board[0, 2] = new Pieces.Bishop(Pieces.ChessPiece.Colors.Black);
            Board[0, 5] = new Pieces.Bishop(Pieces.ChessPiece.Colors.Black);
            Board[7, 2] = new Pieces.Bishop(Pieces.ChessPiece.Colors.White);
            Board[7, 5] = new Pieces.Bishop(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Queens
            Board[0, 3] = new Pieces.Queen(Pieces.ChessPiece.Colors.Black);
            Board[7, 3] = new Pieces.Queen(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Kings
            Board[0, 4] = new Pieces.King(Pieces.ChessPiece.Colors.Black);
            Board[7, 4] = new Pieces.King(Pieces.ChessPiece.Colors.White);
            #endregion
        }

        bool IsBoardOK()
        {
            return true;
        }
    }
}
