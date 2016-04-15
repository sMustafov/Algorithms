namespace Part1.GenerateVariationsWithRepetition
{
    using System;

    class VariationsWithRepetition
    {
        static void Main()
        {
            int n = 2;
            int k = 2;

            int[] array = new int[k];
            GenerateVariations(array, n);
        }

        private static void GenerateVariations(int[] array, int sizeOfSet, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 0; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateVariations(array, sizeOfSet, index + 1);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");
        }
    }
}