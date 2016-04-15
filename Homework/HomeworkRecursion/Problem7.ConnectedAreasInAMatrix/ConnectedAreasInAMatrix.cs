namespace Problem7.ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;

    class ConnectedAreasInAMatrix
    {
        private static SortedSet<ConnectedArea> matches = new SortedSet<ConnectedArea>();
        private static int size = 0;

        private static char[,] lab =
        {
            {' ', ' ',' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ',' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ',' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ',' ', ' ', '*', ' ', '*', ' ', ' '}
        };

        private static char[,] lab2 =
        {
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '}
        };

        static void Main()
        {
            FindCell();
            PrintAreas();
        }

        static void FindCell()
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == ' ')
                    {
                        Mark(row, col);
                        matches.Add(new ConnectedArea(size, row, col));
                        size = 0;
                    }
                }
            }
        }

        static void Mark(int row, int col)
        {
            if (col < 0 || row < 0 ||
                 col >= lab.GetLength(1) ||
                 row >= lab.GetLength(0))
            {
                return;
            }

            if (lab[row, col] == '.' || lab[row, col] == '*')
            {
                return;
            }

            size++;
            lab[row, col] = '.';

            Mark(row, col - 1); // Left 
            Mark(row - 1, col); // Up 
            Mark(row, col + 1); // Right 
            Mark(row + 1, col); // Down 
        }


        static void PrintAreas()
        {
            if (matches.Count <= 0)
            {
                Console.WriteLine("No area's found!");
            }
            else
            {
                int areaNum = 1;

                foreach (var area in matches)
                {
                    Console.WriteLine("Area #{0} at {1}", areaNum, area);
                    areaNum++;
                }
            }
        }
    }
}
