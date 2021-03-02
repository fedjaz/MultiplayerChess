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

        public override List<Move> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            moves.AddRange(Rook.GetRookMoves(chessGame, piecePos));
            moves.AddRange(Bishop.GetBishopMoves(chessGame, piecePos));

            return moves;
        }

        public override List<Move> GetAwailableMoves(ChessGame chessGame, (int, int) piecePos)
        {
            throw new NotImplementedException();
        }

        public override bool IsMoveAvailable(ChessGame chessGame, Move move)
        {
            throw new NotImplementedException();
        }
    }
}
