using System;
using System.Collections.Generic;
using ChessController;
using System.Text;

namespace ChessController
{
    public class Board
    {
        Pieces.ChessPiece[,] board { get; set; }

        public Board()
        {
            board = new Pieces.ChessPiece[8, 8];
        }

        public void SetupBoard()
        {
            #region Pawns
            for(int i = 0; i < 8; i++)
            {
                board[1, i] = new Pieces.Pawn(Pieces.ChessPiece.Colors.Black);
                board[6, i] = new Pieces.Pawn(Pieces.ChessPiece.Colors.White);
            }
            #endregion
            #region Rooks
            board[0, 0] = new Pieces.Rook(Pieces.ChessPiece.Colors.Black);
            board[0, 7] = new Pieces.Rook(Pieces.ChessPiece.Colors.Black);
            board[7, 0] = new Pieces.Rook(Pieces.ChessPiece.Colors.White);
            board[7, 7] = new Pieces.Rook(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Knights
            board[0, 1] = new Pieces.Knight(Pieces.ChessPiece.Colors.Black);
            board[0, 6] = new Pieces.Knight(Pieces.ChessPiece.Colors.Black);
            board[7, 1] = new Pieces.Knight(Pieces.ChessPiece.Colors.White);
            board[7, 6] = new Pieces.Knight(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Bishops
            board[0, 2] = new Pieces.Bishop(Pieces.ChessPiece.Colors.Black);
            board[0, 5] = new Pieces.Bishop(Pieces.ChessPiece.Colors.Black);
            board[7, 2] = new Pieces.Bishop(Pieces.ChessPiece.Colors.White);
            board[7, 5] = new Pieces.Bishop(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Queens
            board[0, 3] = new Pieces.Queen(Pieces.ChessPiece.Colors.Black);
            board[7, 3] = new Pieces.Queen(Pieces.ChessPiece.Colors.White);
            #endregion
            #region Kings
            board[0, 4] = new Pieces.King(Pieces.ChessPiece.Colors.Black);
            board[7, 4] = new Pieces.King(Pieces.ChessPiece.Colors.White);
            #endregion
        }

        public Pieces.ChessPiece this[int i, int j]
        {
            get => board[i, j];
            set => board[i, j] = value;
        }

        public bool IsCellInDanger((int, int) cellPos, Pieces.ChessPiece.Colors threatColor)
        {
            int i = cellPos.Item1, j = cellPos.Item2;
            //check for king nearby
            List<Move> moves = Pieces.King.GetKingMoves(this, cellPos);
            foreach(Move move in moves)
            {
                int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
                if(board[di, dj] is Pieces.King && board[di, dj].Color == threatColor)
                {
                    return true;
                }
            }

            //check for pawns nearby
            if(threatColor == Pieces.ChessPiece.Colors.Black)
            {
                if(i > 0)
                {
                    //check pawn at right
                    if(j < 7)
                    {
                        if(board[i - 1, j + 1] is Pieces.Pawn &&
                           board[i - 1, j + 1].Color == threatColor)
                        {
                            return true;
                        }
                    }
                    //check pawn at left
                    if(j > 0)
                    {
                        if(board[i - 1, j - 1] is Pieces.Pawn &&
                           board[i - 1, j - 1].Color == threatColor)
                        {
                            return true;
                        }
                    }
                }
            }
            //white 
            else
            {
                //check pawn at right
                if(j < 7)
                {
                    if(board[i + 1, j + 1] is Pieces.Pawn &&
                       board[i + 1, j + 1].Color == threatColor)
                    {
                        return true;
                    }
                }
                //check pawn at left
                if(j > 0)
                {
                    if(board[i + 1, j - 1] is Pieces.Pawn &&
                       board[i + 1, j - 1].Color == threatColor)
                    {
                        return true;
                    }
                }
            }

            //check for knights
            moves = Pieces.Knight.GetKnightMoves(this, cellPos);
            foreach(Move move in moves)
            {
                int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
                if(board[di, dj] is Pieces.Knight &&
                   board[di, dj].Color == threatColor)
                {
                    return true;
                }
            }

            //check for bishops and queens
            moves = Pieces.Bishop.GetBishopMoves(this, cellPos);
            foreach(Move move in moves)
            {
                int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
                if((board[di, dj] is Pieces.Bishop || board[di, dj] is Pieces.Queen) &&
                   board[di, dj].Color == threatColor)
                {
                    return true;
                }
            }

            //check for rooks and queens
            moves = Pieces.Rook.GetRookMoves(this, cellPos);
            foreach(Move move in moves)
            {
                int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
                if((board[di, dj] is Pieces.Rook || board[di, dj] is Pieces.Queen) &&
                   board[di, dj].Color == threatColor)
                {
                    return true;
                }
            }

            return false;
        }

        public Board CopyBoard()
        {
            Board newBoard = new Board();

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(board[i, j] != null)
                    {
                        newBoard[i, j] = board[i, j].Copy();
                    }
                    
                }
            }

            return newBoard;
        }

        public (int, int) FindKing(Pieces.ChessPiece.Colors color)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(board[i, j] is Pieces.King &&
                       board[i, j].Color == color)
                    {
                        return (i, j);
                    }
                }
            }
            throw new Exception("King not found!");
        }

        public void ApplyMove(Move move)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
            Pieces.ChessPiece first = board[i, j];
            Pieces.ChessPiece.Colors color = board[i, j].Color;

            if(move.MoveType == Move.MoveTypes.Default)
            {
                //check EnPassant
                if(board[i, j] is Pieces.Pawn)
                {
                    CheckAndAddEnPassant(move);
                }
                board[di, dj] = first;
                board[i, j] = null;
            }
            else if(move.MoveType == Move.MoveTypes.Castling)
            {
                board[di, dj] = first;
                board[i, j] = null;

                i = move.SecondaryFirstPos.Item1;
                j = move.SecondaryFirstPos.Item2;
                di = move.SecondarySecondPos.Item1;
                dj = move.SecondarySecondPos.Item2;

                Pieces.ChessPiece second = board[i, j];
                board[di, dj] = second;
                board[i, j] = null;
            }
            else if(move.MoveType == Move.MoveTypes.EnPassant)
            {
                board[di, dj] = first;
                board[i, j] = null;

                di = move.SecondaryFirstPos.Item1;
                dj = move.SecondaryFirstPos.Item2;

                board[di, dj] = null;
            }
        }

        void CheckAndAddEnPassant(Move move)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            int di = move.SecondPos.Item1, dj = move.SecondPos.Item2;
            if((i == 6 && di == 4) || (i == 1 && di == 3))
            {
                //check right
                if(j < 7 && board[di, j + 1] != null &&
                   board[di, j + 1] is Pieces.Pawn &&
                   board[di, j + 1].Color != board[i, j].Color)
                {
                    (board[i, j] as Pieces.Pawn).EnPassantPassive = true;
                    (board[di, j + 1] as Pieces.Pawn).EnPassantActive = true;
                }

                //check left
                if(j > 0 && board[di, j - 1] != null &&
                   board[di, j - 1] is Pieces.Pawn &&
                   board[di, j - 1].Color != board[i, j].Color)
                {
                    (board[i, j] as Pieces.Pawn).EnPassantPassive = true;
                    (board[di, j - 1] as Pieces.Pawn).EnPassantActive = true;
                }
            }      
        }

        public void ResetEnPassant(Pieces.ChessPiece.Colors color)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(board[i, j] is Pieces.Pawn)
                    {
                        Pieces.Pawn pawn = board[i, j] as Pieces.Pawn;
                        if(color == pawn.Color)
                        {
                            pawn.EnPassantActive = false;
                        }
                        else
                        {
                            pawn.EnPassantPassive = false;
                        }
                    }
                }
            }
        }
    }
}
