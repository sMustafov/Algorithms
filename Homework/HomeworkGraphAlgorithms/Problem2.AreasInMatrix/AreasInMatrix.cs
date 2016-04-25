namespace Problem2.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AreasInMatrix
    {
        // First matrix to test
        private static char[,] matrix = new char[,]
            {
                {'a','s','s','s','a','a','d','a','s'},
                {'a','d','s','d','a','s','d','a','d'},
                {'s','d','s','d','a','d','s','d','a'},
                {'s','d','a','s','d','s','d','s','a'},
                {'s','s','s','s','a','s','d','d','d'}
            };
        // Second matrix to test
        private static char[,] matrix1 = new char[,]
            {
                {'a','a','c','c','c','a','a','c'},
                {'b','a','a','a','a','c','c','c'},
                {'b','a','a','b','a','c','c','c'},
                {'b','b','d','a','a','c','c','c'},
                {'c','c','d','c','c','c','c','c'},
                {'c','c','d','c','c','c','c','c'}
            };
        // Third matrix to test
        private static char[,] matrix2 = new char[,]
            {
                {'a','a','a'},
                {'a','a','a'},
                {'a','a','a'}
            };

        private static bool[,] visited;

        static void Main()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            visited = new bool[rows, cols];

            SortedDictionary<char, int> areas = new SortedDictionary<char, int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visited[i, j])
                    {
                        char letter = matrix[i, j];
                        TryDirection(i, j, letter);

                        if (!areas.ContainsKey(letter))
                        {
                            areas.Add(letter, 0);
                        }

                        areas[letter] = areas[letter] + 1;
                    }
                }
            }

            Console.WriteLine("Areas: {0}", areas.Values.Sum());
            foreach (var pair in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", pair.Key, pair.Value);
            }
        }

        private static void TryDirection(int row, int col, char letter)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != letter)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            TryDirection(row + 1, col, letter); // Down
            TryDirection(row - 1, col, letter); // Up
            TryDirection(row, col - 1, letter); // Left
            TryDirection(row, col + 1, letter); // Right
        }
    }
}