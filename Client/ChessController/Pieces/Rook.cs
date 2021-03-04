using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(Colors color) : base(color)
        {

        }

        public override bool IsMoveAvailable(ChessGame chessGame, Move move)
        {
            throw new NotImplementedException();
        }

        public override List<Move> GetAllMoves(Board board, (int, int) piecePos)
        {
            return GetRookMoves(board, piecePos);
        }

        public static List<Move> GetRookMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();
            //add vertical lower moves
            for(int i = piecePos.Item1 + 1; i < 8; i++)
            {
                int j = piecePos.Item2;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }
            //add vertical upper moves
            for(int i = piecePos.Item1 - 1; i >= 0; i--)
            {
                int j = piecePos.Item2;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }
            //add horizontal right moves
            for(int j = piecePos.Item2 + 1; j < 8; j++)
            {
                int i = piecePos.Item1;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }
            //add horizontal left moves
            for(int j = piecePos.Item2 - 1; j >= 0; j--)
            {
                int i = piecePos.Item1;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, board, move))
                {
                    break;
                }
            }

            return moves;
        }

        public override ChessPiece Copy()
        {
            return new Rook(Color)
            {
                WasMoved = WasMoved
            };
        }
    }
}
