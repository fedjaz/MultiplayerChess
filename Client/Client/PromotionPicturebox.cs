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
    class PromotionPicturebox : PictureBox
    {
        ChessClient chessClient;
        Move move;
        ChessController.Pieces.ChessPiece rook;
        ChessController.Pieces.ChessPiece knight;
        ChessController.Pieces.ChessPiece bishop;
        ChessController.Pieces.ChessPiece queen;

        PictureBox Back;
        PictureBox Rook;
        PictureBox Knight;
        PictureBox Bishop;
        PictureBox Queen;
        public PromotionPicturebox(Control parent, ChessClient chessClient, Move move, ChessController.Pieces.ChessPiece.Colors color)
        {
            Bitmap board = chessClient.GetImageOfBoard();
            Location = new Point(0, 0);
            Size = parent.Size;
            Parent = parent;
            Parent.Controls.Add(this);

            
            Graphics g = Graphics.FromImage(board);
            Brush b = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
            g.FillRectangle(b, new Rectangle(0, 0, board.Width, board.Height));
            Image = board;

            SizeMode = PictureBoxSizeMode.StretchImage;
            BringToFront();

            this.chessClient = chessClient;
            this.move = move;

            rook = new ChessController.Pieces.Rook(color);
            knight = new ChessController.Pieces.Knight(color);
            bishop = new ChessController.Pieces.Bishop(color);
            queen = new ChessController.Pieces.Queen(color);

            DrawAll();

            Rook.MouseDown += (sender, args) => SetPromotion(rook);
            Knight.MouseDown += (sender, args) => SetPromotion(knight);
            Bishop.MouseDown += (sender, args) => SetPromotion(bishop);
            Queen.MouseDown += (sender, args) => SetPromotion(queen);
        }

        void SetPromotion(ChessController.Pieces.ChessPiece piece)
        {
            move.PromotionPiece = piece;
            chessClient.SetPromotion(move);
        }

        void DrawAll()
        {
            Back = new PictureBox();
            Back.BackColor = Color.Transparent;
            
            Bitmap back = Properties.Resources.Background;
            Back.Image = back;
            float sizeCoeff = (float)back.Height / back.Width;
            int backSizeX = (int)(Size.Width * 0.8);
            int backSizeY = (int)(backSizeX * sizeCoeff);
            Back.Size = new Size(backSizeX, backSizeY);
            Back.SizeMode = PictureBoxSizeMode.StretchImage;
            Back.Location = new Point((Size.Width - backSizeX) / 2, (Size.Height - backSizeY) / 2);
            Back.BringToFront();
            Controls.Add(Back);


            int buttonSize = (int)(backSizeX * 0.2);
            int totalLength = buttonSize * 4;
            //rook
            Rook = new PictureBox();
            Rook.Image = ChessPiecePicturebox.MapPicture(rook);
            Rook.SizeMode = PictureBoxSizeMode.StretchImage;
            Rook.Size = new Size(buttonSize, buttonSize);
            Rook.BackColor = Color.Transparent;
            Rook.Parent = Back;
            Back.Controls.Add(Rook);
            int locationX = (Back.Width - totalLength) / 2;
            Rook.Location = new Point(locationX, (Back.Height - Rook.Height) / 2);

            //Knight
            Knight = new PictureBox();
            Knight.Image = ChessPiecePicturebox.MapPicture(knight);
            Knight.SizeMode = PictureBoxSizeMode.StretchImage;
            Knight.Size = new Size(buttonSize, buttonSize);
            Knight.BackColor = Color.Transparent;
            Knight.Parent = Back;
            Back.Controls.Add(Knight);
            locationX = (Back.Width - totalLength) / 2 + buttonSize;
            Knight.Location = new Point(locationX, (Back.Height - Knight.Height) / 2);

            //Bishop
            Bishop = new PictureBox();
            Bishop.Image = ChessPiecePicturebox.MapPicture(bishop);
            Bishop.SizeMode = PictureBoxSizeMode.StretchImage;
            Bishop.Size = new Size(buttonSize, buttonSize);
            Bishop.BackColor = Color.Transparent;
            Bishop.Parent = Back;
            Back.Controls.Add(Bishop);
            locationX = (Back.Width - totalLength) / 2 + 2 * buttonSize;
            Bishop.Location = new Point(locationX, (Back.Height - Bishop.Height) / 2);

            //Queen
            Queen = new PictureBox();
            Queen.Image = ChessPiecePicturebox.MapPicture(queen);
            Queen.SizeMode = PictureBoxSizeMode.StretchImage;
            Queen.Size = new Size(buttonSize, buttonSize);
            Queen.BackColor = Color.Transparent;
            Queen.Parent = Back;
            Back.Controls.Add(Queen);
            locationX = (Back.Width - totalLength) / 2 + 3 * buttonSize;
            Queen.Location = new Point(locationX, (Back.Height - Queen.Height) / 2);
        }
    }
}
