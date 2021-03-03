using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(Colors color) : base(color)
        {

        }

        public override List<Move> GetAllMoves(Board board, (int, int) piecePos)
        {
            return GetKnightMoves(board, piecePos);
        }

        public static List<Move> GetKnightMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            int i = piecePos.Item1, j = piecePos.Item2;

            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default, 
                piecePos, (i - 1, j - 2)), moves);
            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i + 1, j - 2)), moves);

            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i - 2, j - 1)), moves);
            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i + 2, j - 1)), moves);

            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i - 2, j + 1)), moves);
            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i + 2, j + 1)), moves);

            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i - 1, j + 2)), moves);
            CheckAndAddKnightMove(board, new Move(Move.MoveTypes.Default,
                piecePos, (i + 1, j + 2)), moves);

            return moves;
        }

        public override bool IsMoveAvailable(ChessGame chessGame, Move move)
        {
            throw new NotImplementedException();
        }

        static void CheckAndAddKnightMove(Board board, Move move, List<Move> moves)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
            if(dj >= 0 && di >= 0 && dj < 8 && di < 8 &&
                (board[di, dj] == null ||
                 board[di, dj].Color != board[i, j].Color))
            {
                moves.Add(move);
            }
        }

        public override ChessPiece Copy()
        {
            return new Knight(Color);
        }
    }
}
