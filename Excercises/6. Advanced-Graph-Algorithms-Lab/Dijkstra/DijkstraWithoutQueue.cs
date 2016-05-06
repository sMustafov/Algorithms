namespace Dijkstra
{
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);
            int[] distances = new int[n];

            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[sourceNode] = 0;

            bool[] used = new bool[n];
            int?[] prev = new int?[n];

            Dijkstra(used, distances, graph, prev);
            var reconstructedSequance = Reconstruct(distances, prev, destinationNode);

            return reconstructedSequance;
        }

        public static void Dijkstra(bool[] used, int[] distances, int[,] graph, int?[] previous)
        {
            while (true)
            {
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < distances.Length; node++)
                {
                    if (!used[node] && distances[node] < minDistance)
                    {
                        minDistance = distances[node];
                        minNode = node;
                    }
                }
                if (minDistance == int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < distances.Length; i++)
                {

                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = distances[minNode] + graph[minNode, i];
                        if (newDistance < distances[i])
                        {
                            distances[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }
        }

        public static List<int> Reconstruct(int[] distance, int?[] previоus, int destinationNode)
        {
            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            List<int> path = new List<int>();
            int? currentNode = destinationNode;

            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previоus[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}