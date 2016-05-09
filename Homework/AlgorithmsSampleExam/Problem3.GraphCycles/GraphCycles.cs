namespace Problem3.GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GraphCycles
    {
        private static List<int>[] graph;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                string[] input =
                    Console.ReadLine()
                        .Split(new string[] {"->"}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                int parent = int.Parse(input[0].Trim());
                graph[parent] = new List<int>();

                if (input.Length > 1)
                {
                    int[] children = input[1].Trim().Split().Select(int.Parse).Distinct().ToArray();
                    for (int j = 0; j < children.Length; j++)
                    {
                        int child = children[j];
                        graph[parent].Add(child);
                    }
                }
            }

            int cycles = 0;
            for (int firstElement = 0; firstElement < n; firstElement++)
            {
                graph[firstElement].Sort();

                foreach (var firstChild in graph[firstElement])
                {
                    if (firstElement < firstChild)
                    {
                        graph[firstChild].Sort();

                        foreach (var secondChild in graph[firstChild])
                        {
                            if (firstElement < secondChild && firstChild != secondChild)
                            {
                                if (graph[secondChild].Contains(firstElement))
                                {
                                    cycles++;
                                    Console.WriteLine("{{{0} -> {1} -> {2}}}", firstElement, firstChild, secondChild);
                                }
                            }
                        }
                    }
                }
            }

            if (cycles == 0)
            {
                Console.WriteLine("No cycles found");
            }
        }
    }
}