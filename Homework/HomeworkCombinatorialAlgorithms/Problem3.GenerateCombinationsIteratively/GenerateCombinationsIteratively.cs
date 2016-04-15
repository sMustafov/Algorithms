namespace Problem3.GenerateCombinationsIteratively
{
    using System;

    class GenerateCombinationsIteratively
    {
        private static int permutationCounter = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            GenerateCombinations(n, k);
            Console.WriteLine("Combinations: " + permutationCounter);
        }

        static void GenerateCombinations(int n, int k)
        {
            int[] com = new int[n];
            for (int i = 0; i < k; i++)
            {
                com[i] = i;
            }

            while (com[k - 1] < n)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write(com[i] + 1 + " ");
                }
                permutationCounter++;
                Console.WriteLine();

                int t = k - 1;
                while (t != 0 && com[t] == n - k + t)
                {
                    t--;
                }

                com[t]++;

                for (int i = t + 1; i < k; i++)
                {
                    com[i] = com[i - 1] + 1;
                }
            }
        }
    }
}
