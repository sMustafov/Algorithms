namespace Problem2.NestedLoopsToRecursion
{
    using System;

    class NestedLoopsToRecursion
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            NestedLoops(0, vector);
        }

        static void NestedLoops(int index, int[] vector)
        {
            if (index > vector.Length - 1)
            {
                Print(vector);
            }
            else
            {
                for (int i = 1; i <= vector.Length; i++)
                {
                    vector[index] = i;
                    NestedLoops(index + 1, vector);
                }
            }
        }

        private static void Print(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
