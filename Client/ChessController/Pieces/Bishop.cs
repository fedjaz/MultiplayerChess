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


        public override List<Move> GetAllMoves(Board board, (int, int) piecePos)
        {
            return GetBishopMoves(board, piecePos);
        }

        public static List<Move> GetBishopMoves(Board board, (int, int) piecePos)
        {       
            List<Move> moves = new List<Move>();

            //add lower right moves
            for(int i = piecePos.Item1 + 1, j = piecePos.Item2 + 1; i < 8 && j < 8; i++, j++)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }
            //add upper right moves
            for(int i = piecePos.Item1 - 1, j = piecePos.Item2 + 1; i >= 0 && j < 8; i--, j++)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }
            //add upper left moves
            for(int i = piecePos.Item1 - 1, j = piecePos.Item2 - 1; i >= 0 && j >= 0; i--, j--)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }
            //add lower left moves
            for(int i = piecePos.Item1 + 1, j = piecePos.Item2 - 1; i < 8 && j >= 0; i++, j--)
            {
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }

            return moves;
        }


        public override bool IsMoveAvailable(ChessGame chessGame, Move move)
        {
            throw new NotImplementedException();
        }

        public override ChessPiece Copy()
        {
            return new Bishop(Color);
        }
    }
}
