using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public abstract class ChessPiece
    {
        public enum Colors
        {
            White,
            Black
        }

        public Colors Color { get; set; }

        public ChessPiece(Colors color)
        {
            Color = color;
        }

        public abstract bool IsMoveAvailable(ChessGame chessGame, (int, int) piecePos, (int, int) movePos);
        public abstract List<(int, int)> GetAwailableMoves(ChessGame chessGame, (int, int) piecePos);
        public abstract List<(int, int)> GetAllMoves(ChessGame chessGame, (int, int) piecePos);
    }
}
