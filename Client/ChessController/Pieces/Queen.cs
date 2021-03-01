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
            #region Bishop-like moves
            //add lower right moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i < 8 && j < 8; i++, j++)
            {
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            //add upper right moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i >= 0 && j < 8; i--, j++)
            {
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            //add upper left moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i >= 0 && j >= 0; i--, j--)
            {
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            //add lower left moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i < 8 && j >= 0; i++, j--)
            {
                if(!CheckAndAddMove(moves, chessGame.Board, (i, j)))
                {
                    break;
                }
            }
            #endregion

            return moves;
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
