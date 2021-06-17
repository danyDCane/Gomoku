using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Blackpiece : Piece
    {
        public Blackpiece(int x,int y) : base(x, y)
        {
            this.Image = Properties.Resources.black;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.Black;
        }
    }
}
