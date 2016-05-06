namespace Problem1.ExtendACableNetwork
{
    using System;
    using System.Collections.Generic;
    using Problem2.ModifiedKruskalAlgorithm;

    class ExtendACableNetwork
    {
        static void Main()
        {
            int budget = int.Parse(Console.ReadLine().Substring(8));
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            int edges = int.Parse(Console.ReadLine().Substring(7));
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

            HashSet<int> connected = new HashSet<int>();

            for (int i = 0; i < nodes; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            for (int i = 0; i < edges; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int parent = int.Parse(parameters[0]);
                int child = int.Parse(parameters[1]);
                int weigth = int.Parse(parameters[2]);

                graph[parent].Add(new Edge(parent, child, weigth));
                graph[child].Add(new Edge(child, parent, weigth));
                if (parameters.Length == 4)
                {
                    connected.Add(parent);
                    connected.Add(child);
                }
            }

            PrimAlgorithm(graph, connected, budget);
        }

        private static void PrimAlgorithm(Dictionary<int, List<Edge>> graph, HashSet<int> connected, int budget)
        {
            int budgetUsed = 0;
            BinaryHeap<Edge> priorityQueue = new BinaryHeap<Edge>();

            foreach (var node in connected)
            {
                foreach (var edge in graph[node])
                {
                    if (!connected.Contains(edge.Child))
                    {
                        priorityQueue.Insert(edge);
                    }
                }
            }

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();

                if (budgetUsed + smallestEdge.Weight > budget || 
                    connected.Contains(smallestEdge.Child))
                {
                    continue;
                }

                Console.WriteLine(smallestEdge);
                budgetUsed += smallestEdge.Weight;

                connected.Add(smallestEdge.Child);

                foreach (var edge in graph[smallestEdge.Child])
                {
                    if (!connected.Contains(edge.Child))
                    {
                        priorityQueue.Insert(edge);
                    }
                }
            }

            Console.WriteLine("Budget Used: {0}", budgetUsed);
        }
    }
}