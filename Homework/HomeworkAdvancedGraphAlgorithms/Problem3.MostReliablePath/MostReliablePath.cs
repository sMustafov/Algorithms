namespace Problem3.MostReliablePath
{
    using System;
    using System.Collections.Generic;

    class MostReliablePath
    {
        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            string input = Console.ReadLine();
            string[] path = input.Substring(input.IndexOf(' '))
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int startPath = int.Parse(path[0]);
            int endPath = int.Parse(path[1]);
            int edges = int.Parse(Console.ReadLine().Substring(7));

            int[] prev = new int[nodes];
            bool[] visited = new bool[nodes];
            List<Node> graph = new List<Node>();

            for (int i = 0; i < nodes; i++)
            {
                graph.Add(new Node(i, -1));
            }

            for (int i = 0; i < edges; i++)
            {
                string[] parameter = Console.ReadLine().Split();

                int start = int.Parse(parameter[0]);
                int end = int.Parse(parameter[1]);
                double reliability = double.Parse(parameter[2]);

                Edge edge = new Edge(start, end, reliability);
                Edge reversedEdge = new Edge(end, start, reliability);

                graph[start].Edges.Add(edge);
                graph[end].Edges.Add(reversedEdge);
            }

            Dijkstra(startPath, endPath, visited, graph, prev);

            List<int> result = ReconstructPath(prev, startPath, endPath, graph);

            Console.WriteLine("Most reliable path reliability: {0:0.00}", graph[endPath].Reliability);
            Console.WriteLine(result.Count > 0 ? string.Join(" -> ", result) : "Unreachable");
        }

        private static void Dijkstra(int startPath, int endPath, bool[] visited, List<Node> graph, int[] prev)
        {
            graph[startPath].Reliability = 100;
            BinaryHeap<Node> priorityQueue = new BinaryHeap<Node>();
            priorityQueue.Insert(graph[startPath]);
            visited[startPath] = true;

            while (priorityQueue.Count > 0)
            {
                Node currentNode = priorityQueue.ExtractMax();

                if (currentNode.Value == endPath)
                {
                    break;
                }

                foreach (var edge in currentNode.Edges)
                {
                    if (!visited[edge.Child])
                    {
                        priorityQueue.Insert(graph[edge.Child]);
                        visited[edge.Child] = true;

                        double currentReliability = (currentNode.Reliability * edge.Weight) / 100;

                        if (graph[edge.Child].Reliability < currentReliability)
                        {
                            graph[edge.Child].Reliability = currentReliability;
                            prev[edge.Child] = edge.Parent;
                            priorityQueue.Reorder(graph[edge.Child]);
                        }
                    }
                }
            }
        }

        private static List<int> ReconstructPath(int[] prev, int startPath, int endPath, List<Node> graph)
        {
            if (graph[endPath].Reliability < 0)
            {
                return new List<int>();
            }

            List<int> path = new List<int>();
            path.Add(endPath);
            while (endPath != startPath)
            {
                path.Add(prev[endPath]);
                endPath = prev[endPath];
            }

            path.Reverse();
            return path;
        }
    }
}