namespace Needles
{
    using System;
    using System.Linq;

    class Needles
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            int[] sequance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] needles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < needles.Length; i++)
            {
                int zeroes = 0;
                bool isFound = false;

                for (int j = 0; j < sequance.Length; j++)
                {
                    if (needles[i] <= sequance[j])
                    {
                        Console.Write(j - zeroes + " ");
                        isFound = true;
                        break;
                    }

                    if (sequance[j] == 0)
                    {
                        zeroes++;
                    }
                    else
                    {
                        zeroes = 0;
                    }
                }

                if (!isFound)
                {
                    Console.Write(sequance.Length - zeroes + " ");
                }
            }
            Console.WriteLine();
        }
    }
}