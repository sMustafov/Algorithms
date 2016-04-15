namespace Problem5.CombinationsWithoutRepetition
{
    using System;

    class CombinationsWithoutRepetition
    {
        private static int prev = int.MinValue;
        private static int combinationsCounter = 0;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            Combinations(1, arr, 0, n);
            Console.WriteLine("Combinations count: " + combinationsCounter);
        }

        static void Combinations(int index, int[] arr, int after, int n)
        {
            if (index > arr.Length)
            {
                return;
            }
            else
            {
                for (int i = after + 1; i <= n; i++)
                {
                    arr[index - 1] = i;
                    if (index == arr.Length)
                    {
                        Print(arr);
                        combinationsCounter++;
                    }

                    Combinations(index + 1, arr, i, n);
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
