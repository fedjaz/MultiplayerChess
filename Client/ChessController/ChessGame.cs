using System;
using System.Collections.Generic;
using System.Text;

namespace ChessController
{
    public class ChessGame
    {
        public delegate void ChessEventArgs(ChessGame sender, (int, int) piecePos);
        public event ChessEventArgs Check;
        public event ChessEventArgs Checkmate;
        public event ChessEventArgs Stalemate;
        public Board Board { get; set; }
        public Pieces.ChessPiece.Colors WhoseMoving { get; set; }

        public ChessGame()
        {
            SetupGame();
        }

        public void SetupGame()
        {
            WhoseMoving = Pieces.ChessPiece.Colors.White;
            Board = new Board();
            Board.SetupBoard();
        }   

        public List<Move> GetMoves((int, int) piecePos)
        {
            int i = piecePos.Item1, j = piecePos.Item2;
            Pieces.ChessPiece piece = Board[i, j];
            if(piece.Color != WhoseMoving)
            {
                return new List<Move>();
            }
            return piece.GetAvailableMoves(Board, piecePos);
        }

        public void Move(Move move)
        {
            int i = move.FirstPos.Item1, j = move.FirstPos.Item2;
            Board[i, j].WasMoved = true;
            Pieces.ChessPiece.Colors color = Board[i, j].Color;

            Board.ApplyMove(move);

            Board.ResetEnPassant(color);

            WhoseMoving = WhoseMoving == Pieces.ChessPiece.Colors.White ?
                Pieces.ChessPiece.Colors.Black : Pieces.ChessPiece.Colors.White;

            (int, int) kingPos = Board.FindKing(WhoseMoving);
            if(Board.IsCellInDanger(kingPos, color))
            {
                Check?.Invoke(this, kingPos);
                if(!Board.IsAnyMoveAvailable(WhoseMoving))
                {
                    Checkmate?.Invoke(this, kingPos);
                }
            }
            else if(!Board.IsAnyMoveAvailable(WhoseMoving))
            {
                Stalemate?.Invoke(this, kingPos);
            }
        }
    }
}
