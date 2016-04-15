namespace Problem2.GeneratePermutationsIteratively
{
    using System;

    class GeneratePermutationsIteratively
    {
        private static int permutationCounter = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] p = new int[n];

            for (int k = 0; k < n; k++)
            {
                a[k] = k + 1;
                p[k] = 0;
            }

            int i = 1;
            int j = 0;

            Console.WriteLine("(" + string.Join(",", a) + ")");
            permutationCounter++;

            while (i < n)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i];

                    int tmp = 0;
                    tmp = a[j];
                    a[j] = a[i];
                    a[i] = tmp;

                    Console.WriteLine("(" + string.Join(",", a) + ")");
                    permutationCounter++;
                    p[i]++;
                    i = 1;
                }
                else
                {
                    p[i] = 0;
                    i += 1;
                }
            }

            Console.WriteLine("Permutation count: " + permutationCounter);
        }
    }
}