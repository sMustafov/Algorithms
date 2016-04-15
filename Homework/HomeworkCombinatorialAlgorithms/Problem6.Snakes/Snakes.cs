namespace Problem6.Snakes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Snakes
    {
        private static HashSet<string> foundSnakes = new HashSet<string>();
        private static Stack<Coordinates> visitedCoordinates = new Stack<Coordinates>();
        private static string snake;
        private static int n;
        private static int snakeCounter = 0;

        public struct Coordinates
        {
            public Coordinates(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X;

            public int Y;
        }

        static void Main()
        {
            snake = string.Empty;
            n = int.Parse(Console.ReadLine());
            CreateSnake("S", 0, 0);

            Console.WriteLine("Snakes count = " + snakeCounter);
        }

        private static void CreateSnake(string direction, int x, int y)
        {
            Coordinates coordinates = new Coordinates(x, y);

            if (visitedCoordinates.Contains(coordinates))
            {
                return;
            }

            snake = snake + direction;
            visitedCoordinates.Push(coordinates);

            if (snake.Length == n)
            {
                if (!foundSnakes.Contains(snake))
                {
                    MarkSnake(snake);
                    snakeCounter++;
                    Console.WriteLine(snake);
                }
                snake = snake.Remove(snake.Length - 1);
                visitedCoordinates.Pop();
                return;
            }

            CreateSnake("R", x + 1, y);
            if (snake.Length > 1)
            {
                CreateSnake("D", x, y - 1);
                CreateSnake("L", x - 1, y);
                CreateSnake("U", x, y + 1);
            }

            snake = snake.Remove(snake.Length - 1);
            visitedCoordinates.Pop();
        }

        private static bool MarkSnake(string snake)
        {
            foundSnakes.Add(snake);
            foundSnakes.Add(MirrorSnake(snake));

            string reversed = ReverseSnake(snake);
            while (reversed[1] != 'R')
            {
                reversed = RotateSnake(reversed);
            }

            foundSnakes.Add(reversed);
            foundSnakes.Add(MirrorSnake(reversed));

            return true;
        }

        private static string RotateSnake(string snake)
        {
            StringBuilder rotatedSnake = new StringBuilder("S");

            for (int i = 1; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'D':
                        rotatedSnake.Append("R");
                        break;
                    case 'L':
                        rotatedSnake.Append("D");
                        break;
                    case 'U':
                        rotatedSnake.Append("L");
                        break;
                    case 'R':
                        rotatedSnake.Append("U");
                        break;
                }
            }

            return rotatedSnake.ToString();
        }

        private static string MirrorSnake(string snake)
        {
            StringBuilder mirrorSnake = new StringBuilder("S");

            for (int i = 1; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U':
                        mirrorSnake.Append("D");
                        break;
                    case 'D':
                        mirrorSnake.Append("U");
                        break;
                    default:
                        mirrorSnake.Append(snake[i]);
                        break;
                }
            }

            return mirrorSnake.ToString();
        }

        private static string ReverseSnake(string snakeToReverse)
        {
            StringBuilder snakeBuilder = new StringBuilder("S");

            for (int i = snakeToReverse.Length - 1; i > 0; i--)
            {
                snakeBuilder.Append(snakeToReverse[i]);
            }

            return snakeBuilder.ToString();
        }
    }
}