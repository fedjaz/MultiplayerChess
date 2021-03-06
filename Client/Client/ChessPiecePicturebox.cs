using System;
using ChessController;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Client
{
    class ChessPiecePicturebox : PictureBox
    {
        public delegate void ClickArgs((int, int) piecePos);
        public event ClickArgs Clicked;
        bool isCheck = false;

        public ChessController.Pieces.ChessPiece ChessPiece { get; set; }
        public ChessGame ChessGame { get; set; }
        public (int, int) PiecePos { get; set; }


        public ChessPiecePicturebox(ChessController.Pieces.ChessPiece piece, 
            (int, int) pos, PictureBox parent)
        {
            PiecePos = pos;
            ChessPiece = piece;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            Parent = parent;

            int size = parent.Width / 8;
            Size = new Size(size, size);
            //Image = new Bitmap(MapPicture(), new Size(size, size));
            Image = MapPicture(ChessPiece);

            int locationX = pos.Item2 * size, locationY = pos.Item1 * size;

            Location = new Point(locationX, locationY);
            BackColor = Color.Transparent;
            MouseDown += OnClick;
        }

        public void MovePiece((int, int) newPos)
        {
            Location = new Point(newPos.Item2 * Size.Width, newPos.Item1 * Size.Height);
            PiecePos = newPos;
        }

        public static Bitmap MapPicture(ChessController.Pieces.ChessPiece piece)
        {
            if(piece == null)
            {
                return null;
            }
            if(piece.Color == ChessController.Pieces.ChessPiece.Colors.White)
            {
                if(piece is ChessController.Pieces.King)
                {
                    return Properties.Resources.KingW;
                }
                else if(piece is ChessController.Pieces.Queen)
                {
                    return Properties.Resources.QueenW;
                }
                else if(piece is ChessController.Pieces.Rook)
                {
                    return Properties.Resources.RookW;
                }
                else if(piece is ChessController.Pieces.Bishop)
                {
                    return Properties.Resources.BishopW;
                }
                else if(piece is ChessController.Pieces.Knight)
                {
                    return Properties.Resources.KnightW;
                }
                else
                {
                    return Properties.Resources.PawnW;
                }
            }
            else
            {
                if(piece is ChessController.Pieces.King)
                {
                    return Properties.Resources.KingB;
                }
                else if(piece is ChessController.Pieces.Queen)
                {
                    return Properties.Resources.QueenB;
                }
                else if(piece is ChessController.Pieces.Rook)
                {
                    return Properties.Resources.RookB;
                }
                else if(piece is ChessController.Pieces.Bishop)
                {
                    return Properties.Resources.BishopB;
                }
                else if(piece is ChessController.Pieces.Knight)
                {
                    return Properties.Resources.KnightB;
                }
                else
                {
                    return Properties.Resources.PawnB;
                }
            }
        }

        void OnClick(object sender, MouseEventArgs e)
        {
            Clicked?.Invoke(PiecePos);
        }

        public void Activate()
        {
            BackgroundImage = Properties.Resources.Selected;
        }

        public void ActivateMove()
        {
            BackgroundImage = Properties.Resources.Possible;
        }

        public void Deactivate(ChessClient.DeactivatingModes mode)
        {
            if(mode == ChessClient.DeactivatingModes.Click && !isCheck)
            {
                BackgroundImage = null;
            }
            else if(mode == ChessClient.DeactivatingModes.NextMove)
            {
                BackgroundImage = null;
                isCheck = false;
            }
            else
            {
                BackgroundImage = Properties.Resources.Danger;
            }
        }

        public void ActivateDanger()
        {
            BackgroundImage = Properties.Resources.Danger;
            isCheck = true;
        }
    }
}
