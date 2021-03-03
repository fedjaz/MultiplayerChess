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

        public override List<Move> GetAllMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            int i = piecePos.Item1, j = piecePos.Item2;

            moves.AddRange(GetKingMoves(board, piecePos));

            //CACTLING IS NOT ADDED!!!!
            ////add castling
            //if(!WasMoved)
            //{
            //    //white castling
            //    if(Color == Colors.White)
            //    {
            //        //castle right
            //        if(chessGame.Board[7, 7] is Rook && chessGame.Board[7, 7].Color == Color &&
            //           !chessGame.Board[7, 7].WasMoved && 
            //           chessGame.Board[7, 5] == null && chessGame.Board[7, 6] == null)
            //        {

            //        }
            //    }
            //}

            return moves;
        }

        public static List<Move> GetKingMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            int i = piecePos.Item1, j = piecePos.Item2;

            for(int di = i - 1; di < i + 2; di++)
            {
                for(int dj = j - 1; dj < j + 2; dj++)
                {
                    if(!(di == i && dj == j))
                    {
                        CheckAndAddKingMove(board, new Move(Move.MoveTypes.Default, (i, j), (di, dj)), moves);
                    }
                }
            }

            return moves;
        }
        public override bool IsMoveAvailable(ChessGame chessGame, Move move)
        {
            throw new NotImplementedException();
        }

        static void CheckAndAddKingMove(Board board, Move move, List<Move> moves)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;

            if(di >= 0 && dj >= 0 && di < 8 && dj < 8 &&
                (board[di, dj] == null || 
                 board[di, dj].Color != board[i, j].Color))
            {
                moves.Add(move);
            }
        }

        public override ChessPiece Copy()
        {
            return new King(Color);
        }
    }
}
