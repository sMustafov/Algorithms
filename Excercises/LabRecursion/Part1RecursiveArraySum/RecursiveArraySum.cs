namespace Part1RecursiveArraySum
{
    using System;

    class RecursiveArraySum
    {
        static void Main()
        {
            int[] arr =
            {
                1, 2 ,3 ,4 ,5 ,6 ,7 ,8 ,9, 10
            };

            Console.WriteLine("Sum: " + FindSum(arr, 0));
        }

        static int FindSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + FindSum(arr, index + 1);
        }
    }
}
