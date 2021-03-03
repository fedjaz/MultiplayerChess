using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController.Pieces
{
    public class Pawn : ChessPiece
    {
        public bool EnPassantActive { get; set; }
        public bool EnPassantPassive { get; set; }
        public Pawn(Colors color) : base(color)
        {

        }

        public override List<Move> GetAllMoves(Board board, (int, int) piecePos)
        {
            List<Move> moves = new List<Move>();

            int i = piecePos.Item1, j = piecePos.Item2;
            //check is white
            if(board[i, j].Color == Colors.White)
            {
                //add default up move
                if(i > 0 && board[i - 1, j] == null)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i - 1, j)));
                }

                //add long start move
                if(i == 6)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i - 2, j)));
                }

                //add strike move right
                if(i > 0 && j < 7 && board[i - 1, j + 1] != null &&
                   board[i - 1, j + 1].Color == Colors.Black)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i - 1, j + 1)));
                }

                //add strike move left
                if(i > 0 && j > 0 && board[i - 1, j - 1] != null &&
                   board[i - 1, j - 1].Color == Colors.Black)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i - 1, j - 1)));
                }

                //add en passant
                if(EnPassantActive)
                {
                    //en passant right
                    if(j < 7 && board[i, j + 1] is Pawn 
                       && (board[i, j + 1] as Pawn).EnPassantPassive)
                    {
                        Move move = new Move(Move.MoveTypes.EnPassant, piecePos, (i - 1, j + 1),
                                             (i, j + 1));
                        moves.Add(move);
                    }
                    //en passant left
                    if(j > 0 && board[i, j - 1] is Pawn
                       && (board[i, j - 1] as Pawn).EnPassantPassive)
                    {
                        Move move = new Move(Move.MoveTypes.EnPassant, piecePos, (i - 1, j + 1),
                                             (i - 1, j - 1));
                        moves.Add(move);
                    }
                }
            }
            //black
            else
            {
                //add default down move
                if(i < 7 && board[i + 1, j] == null)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i + 1, j)));
                }

                //add long start move
                if(i == 1)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i + 2, j)));
                }

                //add strike move right
                if(i < 7 && j < 7 && board[i - 1, j + 1] != null &&
                   board[i - 1, j + 1].Color == Colors.White)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i + 1, j + 1)));
                }

                //add strike move left
                if(i < 7 && j > 0 && board[i - 1, j - 1] != null &&
                   board[i - 1, j - 1].Color == Colors.White)
                {
                    moves.Add(new Move(Move.MoveTypes.Default, piecePos, (i + 1, j - 1)));
                }

                //add en passant
                if(EnPassantActive)
                {
                    //en passant right
                    if(j < 7 && board[i, j + 1] is Pawn
                       && (board[i, j + 1] as Pawn).EnPassantPassive)
                    {
                        Move move = new Move(Move.MoveTypes.EnPassant, piecePos, (i + 1, j + 1),
                                             (i, j + 1));
                        moves.Add(move);
                    }
                    //en passant left
                    if(j > 0 && board[i, j - 1] is Pawn
                       && (board[i, j - 1] as Pawn).EnPassantPassive)
                    {
                        Move move = new Move(Move.MoveTypes.EnPassant, piecePos, (i + 1, j - 1),
                                             (i, j - 1));
                        moves.Add(move);
                    }
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
            return new Pawn(Color);
        }
    }
}
