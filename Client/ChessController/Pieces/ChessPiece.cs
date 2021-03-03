using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public abstract class ChessPiece
    {
        public enum Colors
        {
            White,
            Black
        }

        public Colors Color { get; set; }
        public bool WasMoved { get; set; } = false;

        public ChessPiece(Colors color)
        {
            Color = color;
        }

        public abstract bool IsMoveAvailable(ChessGame chessGame, Move move);
        public List<Move> GetAvailableMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = GetAllMoves(board, piecePos);
            List<Move> availableMoves = new List<Move>();

            foreach(Move move in moves) 
            {
                int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
                Board copiedBoard = board.CopyBoard();
                Colors color = copiedBoard[i, j].Color;
                copiedBoard.ApplyMove(move);             

                (int, int) kingPos = board.FindKing(color);
                if(!board.IsCellInDanger(kingPos, color == Colors.White ? Colors.Black : Colors.White))
                {
                    availableMoves.Add(move);
                }
            }
            return availableMoves;
        }
        public abstract List<Move> GetAllMoves(Board board, (int, int) piecePos);

        protected static bool CheckAndAddMove(List<Move> moves, Board board, Move move)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;

            if(board[di, dj] == null)
            {
                moves.Add(move);
                return true;
            }
            else if(board[i, j].Color != board[di, dj].Color)
            {
                moves.Add(move);
                return false;
            }
            else
            {
                return false;
            }
        }

        public abstract ChessPiece Copy();
    }
}
