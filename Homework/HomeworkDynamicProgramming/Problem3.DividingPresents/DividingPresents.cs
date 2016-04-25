namespace Problem3.DividingPresents
{
    using System;
    using System.Linq;

    class DividingPresents
    {
        private const int NotSet = -1;

        public static void Main()
        {
            int[] presents = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            Dividing(presents);
        }

        public static void Dividing(int[] presents)
        {
            int length = presents.Length;
            int sum = 0;
            int currentSum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += presents[i];
            }

            int[] last = new int[sum*length];
            last[0] = 0;
            for (int i = 1; i <= sum; i++)
            {
                last[i] = NotSet;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = sum; j + 1 > 0; j--)
                {
                    if (last[j] != NotSet && NotSet == last[j + presents[i]])
                    {
                        last[j + presents[i]] = i;
                    }
                }

                currentSum += presents[i];
            }

            for (int i = sum/2; i > 1; i--)
            {
                if (last[i] != NotSet)
                {
                    Console.WriteLine("Difference: " + Math.Abs(i - (sum - i)));
                    Console.WriteLine("Alan:{0} Bob:{1}", i, sum - i);
                    Console.Write("Alan takes: ");
                    while (i > 0)
                    {
                        Console.Write(presents[last[i]] + " ");
                        i -= presents[last[i]];
                    }
                    Console.WriteLine();
                    Console.WriteLine("Bob takes the rest.");
                    return;
                }
            }
        }
    }
}