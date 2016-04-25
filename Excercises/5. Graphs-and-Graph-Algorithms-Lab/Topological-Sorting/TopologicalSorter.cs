using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    private HashSet<string> visitedNodes;

    private HashSet<string> cycleNodes;

    private LinkedList<string> sortedNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.visitedNodes = new HashSet<string>();
        this.cycleNodes = new HashSet<string>();
        this.sortedNodes = new LinkedList<string>();

        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        var predecessorsCount = new Dictionary<string, int>();

        foreach (var node in this.graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
            {
                predecessorsCount[node.Key] = 0;
            }

            foreach (var childNode in node.Value)
            {
                if (!predecessorsCount.ContainsKey(childNode))
                {
                    predecessorsCount[childNode] = 0;
                }

                predecessorsCount[childNode]++;
            }
        }

        var removedNodes = new List<string>();

        while (true)
        {
            string nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorsCount[n] == 0);

            if (nodeToRemove == null)
            {
                break;
            }

            foreach (var child in this.graph[nodeToRemove])
            {
                predecessorsCount[child]--;
            }


            this.graph.Remove(nodeToRemove);
            predecessorsCount.Remove(nodeToRemove);
            removedNodes.Add(nodeToRemove);
        }

        if (graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }

        return removedNodes;
    }

    private void TopSortDFS(string node)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("A cycle detected in the graph!");
        }

        if (!this.visitedNodes.Contains(node))
        {
            this.visitedNodes.Add(node);
            this.cycleNodes.Add(node);
            foreach (var child in this.graph[node])
            {
                if (this.graph.ContainsKey(child))
                {
                    this.TopSortDFS(child);
                }
            }

            this.cycleNodes.Remove(node);
            this.sortedNodes.AddFirst(node);
        }
    }
}