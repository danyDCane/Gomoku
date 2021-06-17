using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Whitepiece : Piece
    {
        public Whitepiece(int x,int y): base(x, y)
        {
            this.Image= Properties.Resources.white;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.White;
        }
    }
}
