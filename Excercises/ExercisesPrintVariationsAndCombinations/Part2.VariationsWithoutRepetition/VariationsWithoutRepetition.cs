namespace Part2.VariationsWithoutRepetition
{
    using System;

    class VariationsWithoutRepetition
    {
        static void Main()
        {
            int n = 3;
            int k = 2;

            int[] array = new int[k];
            bool[] used = new bool[n + 1];
            GenerateVariations(array, used, n);
        }

        private static void GenerateVariations(int[] array, bool[] used, int sizeOfSet, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariations(array, used, sizeOfSet, index + 1);
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