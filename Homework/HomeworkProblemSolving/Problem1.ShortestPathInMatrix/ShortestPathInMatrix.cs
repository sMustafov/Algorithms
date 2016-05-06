namespace Problem1.ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ShortestPathInMatrix
    {
        private static int[,] matrix;

        private static int[,] graph;

        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            var size = n * m;
            graph = new int[size, size];
            var number = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (col + 1 < m)
                    {
                        var rightValue = matrix[row, col + 1];
                        var rightNumber = number + 1;
                        graph[number, rightNumber] = rightValue;
                    }

                    if (col - 1 >= 0)
                    {
                        var leftValue = matrix[row, col - 1];
                        var leftNumber = number - 1;
                        graph[number, leftNumber] = leftValue;
                    }

                    if (row - 1 >= 0)
                    {
                        var upValue = matrix[row - 1, col];
                        var upNumber = number - m;
                        graph[number, upNumber] = upValue;
                    }

                    if (row + 1 < n)
                    {
                        var downValue = matrix[row + 1, col];
                        var downNumber = number + m;
                        graph[number, downNumber] = downValue;
                    }

                    number++;
                }
            }

            FindAndPrind(0, number - 1);
        }

        static void FindAndPrind(int sourceNode, int destinationNode)
        {
            var path = Dijkstra(sourceNode, destinationNode);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                int pathLength = matrix[0, 0];

                var formattedPath = new StringBuilder();
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                    var row = path[i] / matrix.GetLength(1);
                    var col = path[i] % matrix.GetLength(1);
                    formattedPath.Append(" " + matrix[row, col]);
                }

                formattedPath.Append(" " + matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);

                Console.WriteLine("Length: {0}", pathLength);
                Console.WriteLine("Path: {0}", formattedPath);
            }
        }

        static List<int> Dijkstra(int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);

            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[sourceNode] = 0;

            var used = new bool[n];
            int?[] previous = new int?[n];
            while (true)
            {
                int minDistance = int.MaxValue;
                int minNode = 0;

                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = distance[minNode] + graph[minNode, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;

            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();

            return path;
        }
    }
}