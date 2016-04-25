namespace Problem1.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DistanceBetweenVertices
    {

        static void Main()
        {
            Node graphElementOne = new Node(1);
            Node graphElementTwo = new Node(2);
            Node graphElementThree = new Node(3);
            Node graphElementFour = new Node(4);
            Node graphElementFive = new Node(5);
            Node graphElementSix = new Node(6);
            Node graphElementSeven = new Node(7);
            Node graphElementEight = new Node(8);

            graphElementOne.Children.Add(graphElementFour);
            graphElementTwo.Children.Add(graphElementFour);
            graphElementThree.Children = new List<Node>()
            {
                graphElementFour, graphElementFive
            };
            graphElementFour.Children.Add(graphElementSix);
            graphElementFive.Children = new List<Node>()
            {
                graphElementThree, graphElementSeven, graphElementEight
            };
            graphElementSeven.Children.Add(graphElementEight);

            var graph = new List<Node>()
            {
                graphElementOne,graphElementTwo,
                graphElementThree, graphElementFour, 
                graphElementFive,graphElementSix,
                graphElementSeven,graphElementEight
            };

            var distanceToFind = new List<int>[]
            {
                new List<int> {1, 6},
                new List<int> {1, 5},
                new List<int> {5, 6},
                new List<int> {5, 8}
            };
            for (int i = 0; i < distanceToFind.Length; i++)
            {
                BFS(graph, distanceToFind[i][0], distanceToFind[i][1]);
            }
        }

        public static void BFS(List<Node> graph, int startValue, int endValue)
        {
            foreach (var node in graph)
            {
                node.Distance = -1;
            }

            var nodes = new Queue<Node>();
            Node start = graph.First(x => x.Value == startValue);
            start.Distance = 0;
            Node end = graph.First(x => x.Value == endValue);
            nodes.Enqueue(start);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (currentNode == end)
                {
                    break;
                }

                foreach (var childNode in currentNode.Children)
                {
                    if (childNode.Distance == -1)
                    {
                        childNode.Distance = currentNode.Distance + 1;
                        nodes.Enqueue(childNode);
                    }
                }
            }

            Console.WriteLine("{{{0},{1}}} -> {2}", startValue, endValue, end.Distance);
        }
    }
}