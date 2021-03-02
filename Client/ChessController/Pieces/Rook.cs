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

        public override List<Move> GetAwailableMoves(ChessGame chessGame, (int, int) piecePos)
        {
            throw new NotImplementedException();
        }

        public override bool IsMoveAvailable(ChessGame chessGame, Move move)
        {
            throw new NotImplementedException();
        }

        public override List<Move> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            return GetRookMoves(chessGame, piecePos);
        }

        public static List<Move> GetRookMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();
            //add vertical lower moves
            for(int i = piecePos.Item1; i < 8; i++)
            {
                int j = piecePos.Item2;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }
            //add vertical upper moves
            for(int i = piecePos.Item1; i >= 0; i--)
            {
                int j = piecePos.Item2;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }
            //add horizontal right moves
            for(int j = piecePos.Item2; j < 8; j++)
            {
                int i = piecePos.Item1;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }
            //add horizontal left moves
            for(int j = piecePos.Item2; j >= 0; j--)
            {
                int i = piecePos.Item1;
                Move move = new Move(Move.MoveTypes.Default, piecePos, (i, j));
                if(!CheckAndAddMove(moves, chessGame, move))
                {
                    break;
                }
            }

            return moves;
        }
    }
}
