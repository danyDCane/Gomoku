using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)   //判斷可否放子
            {
                this.Controls.Add(piece);
                //檢查是否有人獲勝
                if (game.Winner == PieceType.Black)
                {
                    MessageBox.Show("黑棋獲勝");
                }
                else if (game.Winner == PieceType.White)
                {
                    MessageBox.Show("白棋獲勝");
                }
            }
                
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //滑鼠游標形狀
            if (game.CanBePlace(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else 
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
