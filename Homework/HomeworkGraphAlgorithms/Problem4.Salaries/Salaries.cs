namespace Problem4.Salaries
{
    using System;
    using System.Collections.Generic;
    
    class Salaries
    {
        private static Dictionary<int, List<int>> graph;

        private static Dictionary<int, long> salaries;

        static void Main()
        {
            graph = new Dictionary<int, List<int>>();
            salaries = new Dictionary<int, long>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
                string input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            long total = 0;
            foreach (var employee in graph.Keys)
            {
                total += Calculate(employee);
            }

            Console.WriteLine(total);
        }

        private static long Calculate(int employee)
        {
            if (graph[employee].Count == 0)
            {
                return 1;
            }

            if (salaries.ContainsKey(employee))
            {
                return salaries[employee];
            }

            long salary = 0;
            foreach (var subordinate in graph[employee])
            {
                salary += Calculate(subordinate);
            }

            salaries.Add(employee, salary);
            return salary;
        }
    }
}