namespace Problem3.MessageSharing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MessageSharing
    {
        static void Main()
        {
            var people = Console.ReadLine()
                .Substring(7)
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var connections = Console.ReadLine().Substring(12)
                .Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var starts = Console.ReadLine().Substring(7)
                .Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var graph = new Dictionary<string, List<string>>();

            foreach (var person in people)
            {
                graph[person] = new List<string>();
            }

            foreach (var connection in connections)
            {
                var data = connection.Split('-');
                var personA = data[0].Trim();
                var personB = data[1].Trim();
                graph[personA].Add(personB);
                graph[personB].Add(personA);
            }

            var queue = new Queue<string>();
            var steps = new Dictionary<string, int>();

            foreach (var start in starts)
            {
                steps[start] = 0;
                queue.Enqueue(start);
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var child in graph[current])
                {
                    if (!steps.ContainsKey(child))
                    {
                        steps[child] = steps[current] + 1;
                        queue.Enqueue(child);
                    }

                }
            }

            var nonReached = new List<string>();

            var lastStep = steps.Values.Max();
            var lastVisited = steps.Where(p => p.Value == lastStep).Select(p => p.Key).ToList();

            foreach (var person in people)
            {
                if (!steps.ContainsKey(person))
                {
                    nonReached.Add(person);
                }
            }

            if (nonReached.Count > 0)
            {
                nonReached.Sort();
                Console.WriteLine("Cannot reach: {0}", string.Join(", ", nonReached));
            }
            else
            {
                lastVisited.Sort();
                Console.WriteLine("All people reached in {0} steps", lastStep);
                Console.WriteLine("People at last step: {0}", string.Join(", ", lastVisited));
            }
        }
    }
}