namespace Problem6.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PathsBetweenCellsInMatrix
    {
        private static int pathCounter = 0;
        private static int startingRow;
        private static int startingCol;
        private static List<char> path = new List<char>();

        private static char[,] lab = { 
        {'s', ' ', ' ', ' '},
        {' ', '*', '*', ' '},
        {' ', '*', '*', ' '},
        {' ', '*', 'e', ' '},
        {' ', ' ', ' ', ' '}
                             };
        private static char[,] lab1 = {
        {'s', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', ' ', '*', ' '},
        {' ', '*', '*', ' ', '*', ' '},
        {' ', '*', 'e', ' ', ' ', ' '},
        {' ', ' ', ' ', '*', ' ', ' '}
                             };

        static void Main()
        {
            FindStartingRowAndCol();
            FindExit(startingRow, startingCol, ' ');
            Console.WriteLine("Total paths found: {0}", pathCounter);
        }

        static void FindStartingRowAndCol()
        {
            for (int r = 0; r < lab1.GetLength(0); r++)
            {
                for (int c = 0; c < lab1.GetLength(1); c++)
                {
                    if (lab1[r, c] == 's')
                    {
                        startingRow = r;
                        startingCol = c;
                        return;
                    }
                }
            }
        }

        static void FindExit(int row, int col, char direction)
        {
            if (col < 0 || row < 0 ||
                 col >= lab1.GetLength(1) ||
                 row >= lab1.GetLength(0))
            {
                return;
            }

            if (lab1[row, col] == 'e')
            {
                path.Add(direction);
                pathCounter++;
                path.Remove(' ');
                Console.WriteLine(string.Join("", path));

                if (path.Any())
                {
                    path.RemoveAt(path.Count - 1);
                }
            }

            if (lab1[row, col] != ' ' && lab1[row, col] != 's')
            {
                return;
            }

            lab1[row, col] = '.';
            path.Add(direction);

            FindExit(row, col - 1, 'L'); // Left 
            FindExit(row - 1, col, 'U'); // Up 
            FindExit(row, col + 1, 'R'); // Right 
            FindExit(row + 1, col, 'D'); // Down 

            lab1[row, col] = ' ';
            if (path.Any())
            {
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
