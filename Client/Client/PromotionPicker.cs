using System;
using ChessController;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    partial class PromotionPicker : UserControl
    {
        ChessClient chessClient;
        Move move;
        ChessController.Pieces.ChessPiece rook;
        ChessController.Pieces.ChessPiece knight;
        ChessController.Pieces.ChessPiece bishop;
        ChessController.Pieces.ChessPiece queen;

        public PromotionPicker()
        {

        }

        public PromotionPicker(ChessClient client, Move move, ChessController.Pieces.ChessPiece.Colors color)
        {
            InitializeComponent();

            chessClient = client;
            this.move = move;

            rook = new ChessController.Pieces.Rook(color);
            knight = new ChessController.Pieces.Knight(color);
            bishop = new ChessController.Pieces.Bishop(color);
            queen = new ChessController.Pieces.Queen(color);

            Rook.Image = ChessPiecePicturebox.MapPicture(rook);
            Knight.Image = ChessPiecePicturebox.MapPicture(knight);
            Bishop.Image = ChessPiecePicturebox.MapPicture(bishop);
            Queen.Image = ChessPiecePicturebox.MapPicture(queen);
        }

        void SetPromotion(ChessController.Pieces.ChessPiece piece)
        {
            move.PromotionPiece = piece;
            chessClient.SetPromotion(move);
        }

        private void Bishop_Click(object sender, EventArgs e)
        {
            SetPromotion(bishop);
        }

        private void Rook_Click(object sender, EventArgs e)
        {
            SetPromotion(rook);
        }

        private void Knight_Click(object sender, EventArgs e)
        {
            SetPromotion(knight);
        }

        private void PromotionPicker_Load(object sender, EventArgs e)
        {

        }

        private void Queen_Click(object sender, EventArgs e)
        {
            SetPromotion(queen);
        }
    }
}
