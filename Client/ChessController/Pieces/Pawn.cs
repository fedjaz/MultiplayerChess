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

        public override List<(int, int)> GetAwailableMoves(ChessGame chessGame, (int, int) piecePos)
        {
            throw new NotImplementedException();
        }

        public override bool IsMoveAvailable(ChessGame chessGame, (int, int) piecePos, (int, int) movePos)
        {
            throw new NotImplementedException();
        }

        public override List<(int, int)> GetAllMoves(ChessGame chessGame, (int, int) piecePos)
        {
            List<(int, int)> moves = new List<(int, int)>();

            int i = piecePos.Item1, j = piecePos.Item2;
            //check is white
            if(chessGame.Board[i, j].Color == Colors.White)
            {
                //add default up move
                if(i > 0 && chessGame.Board[i - 1, j] == null)
                {
                    moves.Add((i - 1, j));
                }

                //add long start move
                if(i == 6)
                {
                    moves.Add((i - 2, j));
                }

                //add strike move right
                if(i > 0 && j < 7 && 
                   chessGame.Board[i - 1, j + 1].Color == Colors.Black)
                {
                    moves.Add((i - 1, j + 1));
                }

                //add strike move left
                if(i > 0 && j > 0 &&
                   chessGame.Board[i - 1, j - 1].Color == Colors.Black)
                {
                    moves.Add((i - 1, j - 1));
                }

                //add en passant
                if(EnPassantActive)
                {
                    //en passant right
                    if(j < 7 && chessGame.Board[i, j + 1] is Pawn 
                       && (chessGame.Board[i, j + 1] as Pawn).EnPassantPassive)
                    {
                        moves.Add((i - 1, j + 1));
                    }
                    //en passant left
                    if(j > 0 && chessGame.Board[i, j - 1] is Pawn
                       && (chessGame.Board[i, j - 1] as Pawn).EnPassantPassive)
                    {
                        moves.Add((i - 1, j - 1));
                    }
                }
            }
            //black
            else
            {
                //add default down move
                if(i < 7 && chessGame.Board[i + 1, j] == null)
                {
                    moves.Add((i + 1, j));
                }

                //add long start move
                if(i == 1)
                {
                    moves.Add((i + 2, j));
                }

                //add strike move right
                if(i < 7 && j < 7 &&
                   chessGame.Board[i + 1, j + 1].Color == Colors.White)
                {
                    moves.Add((i + 1, j + 1));
                }

                //add strike move left
                if(i < 7 && j > 0 &&
                   chessGame.Board[i + 1, j - 1].Color == Colors.White)
                {
                    moves.Add((i + 1, j - 1));
                }

                //add en passant
                if(EnPassantActive)
                {
                    //en passant right
                    if(j < 7 && chessGame.Board[i, j + 1] is Pawn
                       && (chessGame.Board[i, j + 1] as Pawn).EnPassantPassive)
                    {
                        moves.Add((i + 1, j + 1));
                    }
                    //en passant left
                    if(j > 0 && chessGame.Board[i, j - 1] is Pawn
                       && (chessGame.Board[i, j - 1] as Pawn).EnPassantPassive)
                    {
                        moves.Add((i + 1, j - 1));
                    }
                }
            }

            return moves;
        }
    }
}
