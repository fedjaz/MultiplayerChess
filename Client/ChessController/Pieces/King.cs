using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class King : ChessPiece
    {
        public King(Colors color) : base(color)
        {

        }

        public override List<(int, int)> GetAwailableMoves(ChessPiece[,] board, (int, int) piecePos)
        {
            throw new NotImplementedException();
        }

        public override bool IsMoveAvailable(ChessPiece[,] board, (int, int) piecePos, (int, int) movePos)
        {
            throw new NotImplementedException();
        }
    }
}
