namespace Problem2.ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProcessorScheduling
    {
        static void Main()
        {
            int tasksCount = int.Parse(Console.ReadLine().Substring(7));

            Dictionary<int, List<Task>> tasks = new Dictionary<int, List<Task>>();
            int maxDeadline = 0;

            for (int i = 0; i < tasksCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                int value = int.Parse(parameters[0]);
                int deadline = int.Parse(parameters[1]);

                if (deadline > maxDeadline)
                {
                    maxDeadline = deadline;
                }

                Task task = new Task(i, value, deadline);

                if (!tasks.ContainsKey(deadline))
                {
                    tasks.Add(deadline, new List<Task>());
                }

                tasks[deadline].Add(task);
            }

            BinaryHeap<Task> newTasks = new BinaryHeap<Task>();
            List<Task> result = new List<Task>();

            for (int i = maxDeadline; i >= 1; i--)
            {
                if (tasks.ContainsKey(i))
                {
                    foreach (var task in tasks[i])
                    {
                        newTasks.Insert(task);
                    }
                }

                if (newTasks.Count == 0)
                {
                    continue;
                }

                result.Add(newTasks.ExtractMax());
            }

            Console.WriteLine("Optimal schedule: {0}",
                string.Join(" -> ", result.OrderBy(x => x.Deadline).ThenByDescending(x => x.Value).Select(x => x.Number)));

            Console.WriteLine("Total value: {0}", result.Sum(x => x.Value));
        }
    }
}