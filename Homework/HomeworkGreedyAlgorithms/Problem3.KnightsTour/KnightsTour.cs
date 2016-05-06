namespace Problem3.KnightsTour
{
    using System;

    class KnightsTour
    {
        private static int[] Rows = { 1, -1, 2, 1, -1, -2, 2, -2 };

        private static int[] Cols = { 2, 2, 1, -2, -2, 1, -1, -1 };

        private static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            matrix[0, 0] = 1;
            int number = 2;

            int row = 0;
            int col = 0;

            while (number <= n * n)
            {
                int currRow = 0;
                int currCol = 0;
                int min = int.MaxValue;

                for (int i = 0; i < Rows.Length; i++)
                {
                    int currentMin = GetMoves(row + Rows[i], col + Cols[i], matrix);

                    if (currentMin < min)
                    {
                        min = currentMin;
                        currRow = row + Rows[i];
                        currCol = col + Cols[i];
                    }
                }

                row = currRow;
                col = currCol;

                matrix[row, col] = number;
                number++;
            }

            Print(matrix);
        }

        private static bool CanMove(int row, int col, int[,] matrix)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }

            if (matrix[row, col] != 0)
            {
                return false;
            }

            return true;
        }

        private static int GetMoves(int row, int col, int[,] matrix )
        {
            if (!CanMove(row, col, matrix))
            {
                return int.MaxValue;
            }

            int moves = 0;

            for (int i = 0; i < Rows.Length; i++)
            {
                if (CanMove(row + Rows[i], col + Cols[i], matrix))
                {
                    moves++;
                }
            }

            return moves;
        }

        private static void Print(int [,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}