namespace Problem3.CyclesInAGraph
{
    using System;
    using System.Collections.Generic;

    class CyclesInAGraph
    {
        static void Main()
        {
            // First Graph To Test 
            var graph = new List<int>[]
            {
                new List<int>{1}, // C = 0, G = 1
                new List<int>{} // G = 1
            };
            // Second Graph To Test
            var graph1 = new List<int>[]
            {
                new List<int>{1}, // A = 0, F = 1
                new List<int>{2}, // F = 1, D = 2
                new List<int>{0}, // D = 2, A = 0 
            };
            //Third Graph To Test
            var graph2 = new List<int>[]
            {
                new List<int> {1}, // E = 0, Q = 1
                new List<int> {2}, // Q = 1, P = 2
                new List<int> {3}, // P = 2, B = 3
                new List<int> {}      // B = 3
            };
            // Forth Graph To Test
            var graph3 = new List<int>[]
            {
                new List<int> {1}, // K = 0, J = 1
                new List<int> {2}, // J = 1, N = 2
                new List<int> {3}, // N = 2, L = 3
                new List<int> {4}, // N = 3, M = 4
                new List<int> {5},  // M = 4, I = 5
                new List<int> {}
            };

            CyclesInGraph(graph1);
        }

        private static void CyclesInGraph(List<int>[] graph)
        {
            // Calculate the predecessorsCount
            var predecessorsCount = new int[graph.Length];
            for (int node = 0; node < graph.Length; node++)
            {
                foreach (var childNode in graph[node])
                {
                    predecessorsCount[childNode]++;
                }
            }

            // Topological sorting: source removal algorithm
            var isRemoved = new bool[graph.Length];
            var removedNodes = new List<int>();
            bool nodeRemoved = true;

            while (nodeRemoved)
            {
                nodeRemoved = false;
                for (int node = 0; node < graph.Length; node++)
                {
                    if (predecessorsCount[node] == 0 && !isRemoved[node])
                    {
                        // Found a node with 0 predecessors -> remove it from the graph
                        foreach (var childNode in graph[node])
                        {
                            predecessorsCount[childNode]--;
                        }
                        isRemoved[node] = true;
                        removedNodes.Add(node);
                        nodeRemoved = true;
                        break;
                    }
                }
            }

            if (removedNodes.Count == graph.Length)
            {
                Console.WriteLine("Acyclic: Yes");
                Console.WriteLine("Topological sorting: " +
                    string.Join(" ", removedNodes));
            }
            else
            {
                Console.WriteLine("Acyclic: No");
            }
        }
    }
}