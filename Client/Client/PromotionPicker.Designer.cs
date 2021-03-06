
namespace Client
{
    partial class PromotionPicker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Queen = new System.Windows.Forms.PictureBox();
            this.Bishop = new System.Windows.Forms.PictureBox();
            this.Knight = new System.Windows.Forms.PictureBox();
            this.Rook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Queen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Knight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rook)).BeginInit();
            this.SuspendLayout();
            // 
            // Queen
            // 
            this.Queen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(189)))), ((int)(((byte)(109)))));
            this.Queen.Image = global::Client.Properties.Resources.QueenW;
            this.Queen.Location = new System.Drawing.Point(362, 18);
            this.Queen.Name = "Queen";
            this.Queen.Size = new System.Drawing.Size(100, 100);
            this.Queen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Queen.TabIndex = 3;
            this.Queen.TabStop = false;
            this.Queen.Click += new System.EventHandler(this.Queen_Click);
            // 
            // Bishop
            // 
            this.Bishop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(189)))), ((int)(((byte)(109)))));
            this.Bishop.Image = global::Client.Properties.Resources.BishopW;
            this.Bishop.Location = new System.Drawing.Point(251, 18);
            this.Bishop.Name = "Bishop";
            this.Bishop.Size = new System.Drawing.Size(100, 100);
            this.Bishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Bishop.TabIndex = 4;
            this.Bishop.TabStop = false;
            this.Bishop.Click += new System.EventHandler(this.Bishop_Click);
            // 
            // Knight
            // 
            this.Knight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(189)))), ((int)(((byte)(109)))));
            this.Knight.Image = global::Client.Properties.Resources.KnightW;
            this.Knight.Location = new System.Drawing.Point(140, 18);
            this.Knight.Name = "Knight";
            this.Knight.Size = new System.Drawing.Size(100, 100);
            this.Knight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Knight.TabIndex = 5;
            this.Knight.TabStop = false;
            this.Knight.Click += new System.EventHandler(this.Knight_Click);
            // 
            // Rook
            // 
            this.Rook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(189)))), ((int)(((byte)(109)))));
            this.Rook.Image = global::Client.Properties.Resources.RookW;
            this.Rook.Location = new System.Drawing.Point(29, 18);
            this.Rook.Name = "Rook";
            this.Rook.Size = new System.Drawing.Size(100, 100);
            this.Rook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Rook.TabIndex = 6;
            this.Rook.TabStop = false;
            this.Rook.Click += new System.EventHandler(this.Rook_Click);
            // 
            // PromotionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.Wood;
            this.Controls.Add(this.Queen);
            this.Controls.Add(this.Rook);
            this.Controls.Add(this.Bishop);
            this.Controls.Add(this.Knight);
            this.Name = "PromotionPicker";
            this.Size = new System.Drawing.Size(495, 135);
            this.Load += new System.EventHandler(this.PromotionPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Queen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Knight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Queen;
        private System.Windows.Forms.PictureBox Bishop;
        private System.Windows.Forms.PictureBox Knight;
        private System.Windows.Forms.PictureBox Rook;
    }
}
