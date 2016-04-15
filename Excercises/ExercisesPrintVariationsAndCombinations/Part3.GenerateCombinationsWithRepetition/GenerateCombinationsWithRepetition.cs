namespace Part3.GenerateCombinationsWithRepetition
{
    using System;

    class GenerateCombinationsWithRepetition
    {
        static void Main()
        {
            int n = 3;
            int k = 2;
            int[] arr = new int[k];

            GenerateCombinations(arr, n, 0);
        }

        static void GenerateCombinations(int[] arr, int sizeOfSet, int index, int start = 1)
        {
            if (index > arr.Length - 1)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, sizeOfSet, index + 1, i);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");
        }
    }
}