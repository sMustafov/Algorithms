namespace Problem3.CombinationsWithRepetition
{
    using System;

    class CombinationsWithRepetition
    {
        private static int prev = int.MinValue;
        private static int combinationsCounter = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            Combinations(0, arr, n);
            Console.WriteLine("Combinations count: " + combinationsCounter);
        }

        static void Combinations(int index, int[] arr, int n)
        {
            if (index > arr.Length - 1)
            {
                Print(arr);
                combinationsCounter++;
                prev = int.MinValue;
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    if (arr[index] >= prev)
                    {
                        prev = arr[index];
                        Combinations(index + 1, arr, n);
                    }
                }
            }
        }

        private static void Print(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
