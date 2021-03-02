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


        public override List<Move> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            return GetBishopMoves(chessGame, piecePos);
        }

        public static List<Move> GetBishopMoves(ChessGame chessGame, (int, int) piecePos)
        {       
            List<Move> moves = new List<Move>();

            //add lower right moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i < 8 && j < 8; i++, j++)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }
            //add upper right moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i >= 0 && j < 8; i--, j++)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }
            //add upper left moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i >= 0 && j >= 0; i--, j--)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }
            //add lower left moves
            for(int i = piecePos.Item1, j = piecePos.Item2; i < 8 && j >= 0; i++, j--)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }

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
