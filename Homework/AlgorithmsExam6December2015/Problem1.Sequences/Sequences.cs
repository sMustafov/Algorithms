namespace Problem1.Sequences
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Sequences
    {
        private static StringBuilder output;
        private static List<int> numbers;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            numbers = new List<int>();
            output = new StringBuilder();

            GenerateVariations(n);

            Console.Write(output);
        }

        private static void GenerateVariations(int maxSum, int index = 0)
        {
            for (int i = 1; i <= maxSum; i++)
            {
                if (index + i <= maxSum)
                {
                    numbers.Add(i);
                    output.AppendLine(string.Join(" ", numbers));
                    GenerateVariations(maxSum, index + i);
                    numbers.RemoveAt(numbers.Count - 1);
                }
                else
                {
                    break;
                }
            }
        }
    }
}