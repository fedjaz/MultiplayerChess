using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class Queen : ChessPiece
    {
        public Queen(Colors color) : base(color)
        {

        }

        public override ChessPiece Copy()
        {
            return new Queen(Color)
            {
                WasMoved = WasMoved
            };
        }

        public override List<Move> GetAllMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            moves.AddRange(Rook.GetRookMoves(board, piecePos));
            moves.AddRange(Bishop.GetBishopMoves(board, piecePos));

            return moves;
        }
    }
}
