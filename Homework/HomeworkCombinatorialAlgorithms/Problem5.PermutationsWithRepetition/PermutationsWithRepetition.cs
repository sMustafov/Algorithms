namespace Problem5.PermutationsWithRepetition
{
    using System;

    class PermutationsWithRepetition
    {
        private static int permutationsCount;

        static void Main()
        {
            var arr = new int[]{1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3};// {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}; //{1, 1, 2, 3}; //{ 3, 5, 1, 5, 5 };
            Array.Sort(arr);
            GeneratePermutationsWithRepetition(arr, 0, arr.Length - 1);

            Console.WriteLine("Permutations: " + permutationsCount);
        }

        static void GeneratePermutationsWithRepetition(int[] arr, int start, int end)
        {
            Print(arr);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        GeneratePermutationsWithRepetition(arr, left + 1, end);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[end] = firstElement;
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
            permutationsCount++;
        }
    }
}
