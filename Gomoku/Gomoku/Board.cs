using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    class Board
    {
        private static readonly Point NoPoint = new Point(-1, -1); 
        private static readonly int OFFSET = 75;
        private static readonly int DISTANCE = 75;
        private static readonly int RANGE = 10;
        private Piece[,] pieces = new Piece[9, 9];  //建立陣列紀錄點是否已存在
        private Point lastPlacePoint = NoPoint;
        public Point LastPlacePoint { get { return lastPlacePoint; } }
        public PieceType GetPieceType (int nodelx, int nodely)
        {
            if (pieces[nodelx, nodely] == null)
                return PieceType.None;

            else 
                return pieces[nodelx, nodely].GetPieceType();
        }
        public bool CanBePlace (int x, int y)
        {
            //呼叫程式碼找點
            Point nodel = CheckPoint2(x, y);
            //沒有的話傳false
            if (nodel == NoPoint)
                return false;
            //有就傳true 並檢查棋子是否已經存在
            return true;
        }
        public Piece PlaceAPiece (int x,int y,PieceType type)
        {
            //呼叫找點碼找點
            Point nodel = CheckPoint2(x, y);
            //沒有的話傳false
            if (nodel == NoPoint)
                return null;
            //有的話檢查棋子是否存在點上
            if (pieces[nodel.X, nodel.Y] != null)
                return null;
            //根據type產生對應的棋子
            Point formpos = adjustpoint(nodel);
            if (type == PieceType.Black)
                pieces[nodel.X, nodel.Y] = new Blackpiece(formpos.X, formpos.Y);
            else if(type == PieceType.White)
                pieces[nodel.X, nodel.Y] = new Whitepiece(formpos.X, formpos.Y);
            //紀錄最後下棋的位置
            lastPlacePoint = nodel;
            return pieces[nodel.X, nodel.Y];
        }
       public Point adjustpoint (Point nodel) //調整點對齊格線
        {
            nodel.X = OFFSET + nodel.X * DISTANCE;
            nodel.Y = OFFSET + nodel.Y * DISTANCE;
            return nodel;
        }
        public Point CheckPoint2 (int x, int y)
        {
            //二維找點
            int nodelx = CheckPoint(x);
            if (nodelx == -1)
                return NoPoint;
            int nodely = CheckPoint(y);
            if (nodely == -1)
                return NoPoint;
            return new Point(nodelx, nodely);
        }
        public int CheckPoint(int pos)
        {
            //一維找點
            if (pos < OFFSET - RANGE)
                return -1;
            pos -= OFFSET;
            int quotient = pos / DISTANCE;
            int remainder = pos % DISTANCE;
            if (remainder <= RANGE)
                return quotient;
            else if (DISTANCE - remainder <= RANGE)
                return quotient + 1;
            else
                return -1;
        }
    }
}
