using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(Colors color) : base(color)
        {

        }

        public override List<(int, int)> GetAwailableMoves(ChessGame chessGame, (int, int) piecePos)
        {
            throw new NotImplementedException();
        }

        public override bool IsMoveAvailable(ChessGame chessGame, (int, int) piecePos, (int, int) movePos)
        {
            throw new NotImplementedException();
        }
    }
}
