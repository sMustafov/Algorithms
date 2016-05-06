namespace Problem2.ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ModifiedKruskalAlgorithm
    {
        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            int edges = int.Parse(Console.ReadLine().Substring(7));

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int[] parent = new int[nodes];
            BinaryHeap<Edge> priorityQueue = new BinaryHeap<Edge>();

            for (int i = 0; i < nodes; i++)
            {
                graph.Add(i, new List<int>());
                parent[i] = i;
            }

            for (int i = 0; i < edges; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int start = int.Parse(parameters[0]);
                int end = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);
                Edge edge = new Edge(start, end, weight);
                priorityQueue.Insert(edge);
            }

            List<Edge> krusal = Kruskal(priorityQueue, parent, graph);

            Console.WriteLine("Minimum spanning forest weight: {0}", krusal.Sum(x => x.Weight));
            Console.WriteLine(string.Join(Environment.NewLine, krusal));
        }

        public static List<Edge> Kruskal(BinaryHeap<Edge> priorityQueue, int[] parent, Dictionary<int, List<int>> graph)
        {
            List<Edge> kruskal = new List<Edge>();
            while (priorityQueue.Count > 0)
            {
                Edge edge = priorityQueue.ExtractMin();
                int startParent = parent[edge.Parent];
                int endParent = parent[edge.Child];

                if (startParent != endParent)
                {
                    if (graph[endParent].Count > graph[startParent].Count)
                    {
                        FindRoot(endParent, startParent, parent, graph);
                    }
                    else
                    {
                        FindRoot(startParent, endParent, parent, graph);
                    }

                    kruskal.Add(edge);
                }
            }

            return kruskal;
        }

        public static void FindRoot(int start, int end, int[] parent, Dictionary<int, List<int>> graph)
        {
            graph[start].Add(end);
            parent[end] = start;
            foreach (var child in graph[end])
            {
                graph[start].Add(child);
                parent[child] = start;
            }

            graph[end] = new List<int>();
        }
    }
}