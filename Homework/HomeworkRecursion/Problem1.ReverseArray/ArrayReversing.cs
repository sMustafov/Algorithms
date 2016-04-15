namespace Problem1.ReverseArray
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            ReverseArray(arr, arr.Length - 1);
        }

        static void ReverseArray(int[] arr, int index)
        {
            if (index == -1)
            {
                return;
            }

            Console.Write(arr[index] + " ");
            ReverseArray(arr, index - 1);
        }
    }
}
