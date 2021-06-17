using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        private Board board = new Board();
        private PieceType currentplayer = PieceType.Black;
        private PieceType winner = PieceType.None;
        public PieceType Winner { get { return winner; } }
        public bool CanBePlace(int x, int y)
        {
            return board.CanBePlace(x, y);
        }
        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentplayer);
            if (piece != null)   //判斷可否放子
            {
                //間雜是否現在下棋的人獲勝
                CheckWinner();
                //轉換下棋顏色
                if (currentplayer == PieceType.Black)
                    currentplayer = PieceType.White;
                else if (currentplayer == PieceType.White)
                    currentplayer = PieceType.Black;
                return piece;
            }
            else
                return null;
        }
        private void CheckWinner()
        {
            //count記下連成幾子-//記錄現在看到幾顆相同的棋子，「=1」表現在下的這子
            int count = 1, countReverse = 0;//反方向檢查是不包括自己，故初始值為0
            int targetX = 0, targetY = 0;

            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    //略過中心點（自己位置）不檢查，當然要輻射出去八方
                    if (xDir == 0 && yDir == 0)
                        continue;//若是現在下的這一子則略過後面的程式碼，換下個方向檢查
                    while (count < 5)
                    {
                        //int centerX = lastPlaceNode.X;
                        //int centerY= lastPlaceNode.Y;

                        targetX = board.LastPlacePoint.X + xDir * count;
                        targetY = board.LastPlacePoint.Y + yDir * count;
                        //檢查是否有子、且顏色是否相同
                        if (targetX < 0 || targetY < 0 || targetX >= 9 ||
                            targetY >= 9 ||
                            board.GetPieceType(targetX, targetY) == PieceType.None ||
                            board.GetPieceType(targetX, targetY) != currentplayer)
                        //如果此方向已沒有棋子或換色時，就調頭去看還有沒有同色棋子
                        {
                            countReverse = 0;
                            while (countReverse + count < 5)
                            {
                                countReverse++;
                                targetX = board.LastPlacePoint.X + xDir * countReverse * -1;//調頭即*-1，即可反方向
                                targetY = board.LastPlacePoint.Y + yDir * countReverse * -1;
                                if (targetX < 0 || targetY < 0 || targetX >= 9 ||
                                    targetY >= 9 ||
                                    board.GetPieceType(targetX, targetY) == PieceType.None ||
                                    board.GetPieceType(targetX, targetY) != currentplayer)
                                //如果反方向已沒有棋子或換色時，就結束此方向的檢查
                                {
                                    //若該位置無子，或連不到五子則跳出最接近這個break的封閉式迴圈while
                                    goto  nextdir;
                                }
                                if (countReverse + count == 5)
                                {
                                    winner = currentplayer;
                                    return;//贏家確定了，就不用再找了
                                }
                            }
                        }
                        //要五子連棋,找到同色子就加1
                        count++;
                    }
                nextdir:
                    if (count == 5)
                    {
                        winner = currentplayer;
                        return;//決定了贏家之後，就不用再找了
                    }
                    else
                        count = 1;
                }
            }


        }

    }
}
