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
        public bool WasMoved { get; set; } = false;

        public ChessPiece(Colors color)
        {
            Color = color;
        }

        public abstract bool IsMoveAvailable(ChessGame chessGame, Move move);
        public abstract List<Move> GetAwailableMoves(ChessGame chessGame, (int, int) piecePos);
        public abstract List<Move> GetAllMoves(ChessGame chessGame, (int, int) piecePos);

        protected static bool CheckAndAddMove(List<Move> moves, ChessGame chessGame, Move move)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;

            if(chessGame.Board[di, dj] == null)
            {
                moves.Add(move);
                return true;
            }
            else if(chessGame.Board[i, j].Color != chessGame.Board[di, dj].Color)
            {
                moves.Add(move);
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
