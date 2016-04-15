namespace Problem1.Permutations
{
    using System;
    using System.Linq;

    class Permutations
    {
        private static int permutationsCount;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();

            GeneratePermutations(array);
            Console.WriteLine("Permutations: " + permutationsCount);
        }

        private static void GeneratePermutations(int[] array, int startIndex = 0)
        {
            if (startIndex >= array.Length)
            {
                Console.WriteLine("(" + string.Join(", ", array) + ")");
                permutationsCount++;
            }
            else
            {
                GeneratePermutations(array, startIndex + 1);
                for (int i = startIndex + 1; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    GeneratePermutations(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
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
    }
}
