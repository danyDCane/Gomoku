using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku
{
    abstract class Piece : PictureBox
    {
        public static readonly int LONG = 50;
        public Piece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x- LONG/2, y- LONG/2);
            this.Size = new Size(LONG, LONG);
        }
        public abstract PieceType GetPieceType();
    }  
     
}
