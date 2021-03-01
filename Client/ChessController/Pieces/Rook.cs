using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class Rook : ChessPiece
    {
        public bool WasMoved { get; set; } = false;
        public Rook(Colors color) : base(color)
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

        public override List<(int, int)> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<(int, int)> moves = new List<(int, int)>();

            #region Rook-like moves
            //add vertical lower moves
            for(int i = piecePos.Item1; i < 8; i++)
            {
                int j = piecePos.Item2;
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            //add vertical upper moves
            for(int i = piecePos.Item1; i >= 0; i--)
            {
                int j = piecePos.Item2;
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            //add horizontal right moves
            for(int j = piecePos.Item2; j < 8; j++)
            {
                int i = piecePos.Item1;
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            //add horizontal left moves
            for(int j = piecePos.Item2; j >= 0; j--)
            {
                int i = piecePos.Item1;
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }

            #endregion

            return moves;
        }
    }
}
