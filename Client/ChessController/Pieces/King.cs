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

            //add castling
            if(!WasMoved)
            {
                //castle right
                if(j == 4 && (i == 0 || i == 7) &&
                    board[i, 7] is Rook && board[i, 7].Color == Color &&
                    !WasMoved && !board[i, 7].WasMoved && 
                    board[i, 5] == null && board[i, 6] == null)
                {
                    Colors threatColor = Color == Colors.Black ?
                                            Colors.White : Colors.Black;

                    Board copiedBoard = board.CopyBoard();
                    bool b1 = !copiedBoard.IsCellInDanger((i, 4), threatColor);
                    copiedBoard.ApplyMove(new Move(Move.MoveTypes.Default,
                        (i, 4), (i, 5)));
                    bool b2 = !copiedBoard.IsCellInDanger((i, 5), threatColor);
                    copiedBoard.ApplyMove(new Move(Move.MoveTypes.Default,
                        (i, 5), (i, 6)));
                    bool b3 = !copiedBoard.IsCellInDanger((i, 6), threatColor);
                    if(b1 && b2 && b3)
                    {
                        moves.Add(new Move(Move.MoveTypes.Castling,
                                            (i, j), (i, 6),
                                            (i, 7), (i, 5)));
                    }
                }
                //castle left
                if(j == 4 && (i == 0 || i == 7) &&
                    board[i, 0] is Rook && board[i, 0].Color == Color &&
                    !WasMoved && !board[i, 0].WasMoved &&
                    board[i, 1] == null && board[i, 2] == null && 
                    board[i, 3] == null)
                {
                    Colors threatColor = Color == Colors.Black ?
                                            Colors.White : Colors.Black;

                    Board copiedBoard = board.CopyBoard();
                    bool b1 = !copiedBoard.IsCellInDanger((i, 4), threatColor);
                    copiedBoard.ApplyMove(new Move(Move.MoveTypes.Default,
                        (i, 4), (i, 3)));
                    bool b2 = !copiedBoard.IsCellInDanger((i, 3), threatColor);
                    copiedBoard.ApplyMove(new Move(Move.MoveTypes.Default,
                        (i, 3), (i, 2)));
                    bool b3 = !copiedBoard.IsCellInDanger((i, 2), threatColor);
                    if(b1 && b2 && b3)
                    {
                        moves.Add(new Move(Move.MoveTypes.Castling,
                                            (i, j), (i, 2),
                                            (i, 0), (i, 3)));
                    }
                }
            }

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
            return new King(Color)
            {
                WasMoved = WasMoved
            };
        }
    }
}
