namespace Part4.GenerateCombinationsWithoutRepetition
{
    using System;

    class GenerateCombinationsWithoutRepetition
    {
        static void Main()
        {
            int n = 3;
            int k = 2;
            int[] arr = new int[k];
            bool[] used = new bool[n + 1];

            GenerateCombinations(arr, used, n, 0);
        }

        static void GenerateCombinations(int[] arr, bool[] used, int sizeOfSet, int index, int start = 1)
        {
            if (index > arr.Length - 1)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateCombinations(arr, used, sizeOfSet, index + 1, i);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");
        }
    }
}