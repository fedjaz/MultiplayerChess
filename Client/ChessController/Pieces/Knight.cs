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

        public override List<Move> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            

            return moves;
        }

        public static List<Move> GetKnightMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            int i = piecePos.Item1, j = piecePos.Item2;

            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default, 
                piecePos, (i - 1, j - 2)), moves);
            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i + 1, j - 2)), moves);

            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i - 2, j - 1)), moves);
            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i + 2, j - 1)), moves);

            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i - 2, j + 1)), moves);
            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i + 2, j + 1)), moves);

            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i - 1, j + 2)), moves);
            CheckAndAddKnightMove(chessGame, new Move(Move.MoveTypes.Default,
                piecePos, (i + 1, j + 2)), moves);

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

        static void CheckAndAddKnightMove(ChessGame chessGame, Move move, List<Move> moves)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
            if(dj >= 0 && di >= 0 && dj < 8 && di < 8 &&
                (chessGame.Board[di, dj] == null ||
                 chessGame.Board[di, dj].Color != chessGame.Board[i, j].Color))
            {
                moves.Add(move);
            }
        }
    }
}
