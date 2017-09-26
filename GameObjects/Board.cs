using System;

namespace _4Gewinnt.GameObjects
{
    public class Board
    {
        public int MaxRow;
        public int MaxCol;
        public int WinningCount;
        public Stone[,] board;

        public Board(BoardSizes Size)
        {
            SetSizes(Size);
            InitBoard();
        }

        
        private void SetSizes(BoardSizes size)
        {
            switch (size)
            {
                case BoardSizes.Classic:
                    MaxRow = 6;
                    MaxCol = 7;
                    WinningCount = 4;
                    break;
                case BoardSizes.Advanced:
                    MaxRow = 12;
                    MaxCol = 14;
                    WinningCount = 5;
                    break;
                default:
                    break;
            }
        }

        //Gibt die aktuelle Größe des Spielfeldes wieder
        public int[] GetBoardSize()
        {
            return new int[] { MaxCol, MaxRow };
        }

        private void InitBoard()
        {
            if (this.board == null)
            {
                this.board = new Stone[MaxRow, MaxCol];
            }
            //Alle Felder mit leeren Steinen belegen
            for (int y = 0; y < MaxRow; y++)
            {
                for (int x = 0; x < MaxCol; x++)
                {
                    this.board[y, x] = Stone.Empty;
                }
            }
        }

        //Stein Auf das Spielfeld legen
        public void LayStoneOnBoard(Stone StoneToPlace, int Column, int Row)
        {
            board[Row, Column] = StoneToPlace;
        }

        //Prüfen ob die Siegbedingung erreicht wurde
        public bool IsGameOver(int row, int col, Stone LastStone)
        {
            //Horizontale Prüfen
            int count = 0;
            for (int x = 0; x < MaxCol; x++)
            {
                if (this.board[row, x] == LastStone)
                {
                    count++;
                    if (count == WinningCount) return true;
                }
                else
                {
                    count = 0;
                }
            }

            //Vertikal prüfen

            count = 0;
            for (int y = 0; y < MaxRow; y++)
            {
                if (this.board[y, col] == LastStone)
                {
                    count++;
                    if (count == WinningCount) return true;
                }
                else
                {
                    count = 0;
                }
            }

            //Diagonale 1 prüfen (links oben / rechts unten)
            count = 0;
            int delta1 = Math.Min(MaxRow - row - 1, col);
            int delta2 = Math.Min(row, MaxCol - col - 1);

            var row1 = row + delta1;
            var col1 = col - delta1;
            var row2 = row - delta2;
            var col2 = col + delta2;

            for (int i = row1, j = col1; i >= row2 && j <= col2; i--, j++)
            {
                if (this.board[i, j] == LastStone)
                {
                    count++;
                    if (count == WinningCount) return true;
                }
                else
                {
                    count = 0;
                }
            }

            //Diagonale 2 prüfen (links unten / rechts oben)
            delta1 = Math.Min(row, col);
            delta2 = Math.Min(MaxRow - row, MaxCol - col);
            row1 = row - delta1;
            col1 = col - delta1;
            row2 = row + delta2;
            col2 = col + delta2;
            count = 0;

            for (int i = row1, j = col1; i < row2 && j < col2; i++, j++)
            {
                if (this.board[i, j] == LastStone)
                {
                    count++;
                    if (count == WinningCount) return true;
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }

        
    }
}
