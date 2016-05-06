namespace Problem4.ShortestPathsBetweenAllPairsOfNodes
{
    using System;

    class ShortestPathsBetweenAllPairsOfNodes
    {
        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            int edges = int.Parse(Console.ReadLine().Substring(7));
            long[,] distances = new long[nodes, nodes];

            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    if (i != j)
                    {
                        distances[i, j] = int.MaxValue;
                    }
                }
            }

            for (int i = 0; i < edges; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int start = int.Parse(parameters[0]);
                int end = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);

                distances[start, end] = weight;
                distances[end, start] = weight;
            }

            FloydWarshall(distances, nodes);

            Console.WriteLine("Shortest paths matrix:");
            for (int i = 0; i < nodes; i++)
            {
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
            for (int i = 0; i < nodes; i++)
            {
                Console.Write("---");
            }
            Console.WriteLine();
            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    Console.Write("{0,2} ", distances[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void FloydWarshall(long[,] distances, int nodes)
        {
            for (int k = 0; k < nodes; k++)
            {
                for (int i = 0; i < nodes; i++)
                {
                    for (int j = 0; j < nodes; j++)
                    {
                        if (distances[i, j] > distances[i, k] + distances[k, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }
        }
    }
}