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

        public override List<(int, int)> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<(int, int)> moves = new List<(int, int)>();

            int i = piecePos.Item1, j = piecePos.Item2;

            CheckAndAddKnightMove(chessGame, piecePos, (i - 1, j - 2), moves);
            CheckAndAddKnightMove(chessGame, piecePos, (i + 1, j - 2), moves);

            CheckAndAddKnightMove(chessGame, piecePos, (i - 2, j - 1), moves);
            CheckAndAddKnightMove(chessGame, piecePos, (i + 2, j - 1), moves);

            CheckAndAddKnightMove(chessGame, piecePos, (i - 2, j + 1), moves);
            CheckAndAddKnightMove(chessGame, piecePos, (i + 2, j + 1), moves);

            CheckAndAddKnightMove(chessGame, piecePos, (i - 1, j + 2), moves);
            CheckAndAddKnightMove(chessGame, piecePos, (i + 1, j + 2), moves);

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

        public void CheckAndAddKnightMove(ChessGame chessGame, (int, int) knightPos, 
                                          (int, int) movePos, List<(int, int)> moves)
        {
            int i = knightPos.Item1, j = knightPos.Item2;
            int di = movePos.Item1, dj = movePos.Item2;
            if(dj >= 0 && di >= 0 && dj < 8 && di < 8 &&
                (chessGame.Board[di, dj] == null ||
                 chessGame.Board[di, dj].Color != Color))
            {
                moves.Add((di, dj));
            }
        }
    }
}
