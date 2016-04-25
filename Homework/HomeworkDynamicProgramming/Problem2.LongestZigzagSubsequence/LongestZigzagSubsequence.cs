namespace Problem2.LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestZigzagSubsequence
    {
        static void Main()
        {
            var sequence = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var longestSeq = FindLongestZigzagSubsequence(sequence);
            Console.WriteLine("Longest zigzag subsequence: ");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        private static int[] FindLongestZigzagSubsequence(int[] sequence)
        {
            int[] lengthOdd = new int[sequence.Length];
            int[] lengthEven = new int[sequence.Length];
            int[] prevOdd = new int[sequence.Length];
            int[] prevEven = new int[sequence.Length];

            bool oddIsSmaller = false;
            int maxLen = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                lengthOdd[i] = 1;
                lengthEven[i] = 1;
                prevOdd[i] = -1;
                prevEven[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (lengthEven[j] + 1 > lengthEven[i])
                    {
                        if (lengthEven[j] % 2 == 0 && sequence[i] < sequence[j] ||
                            lengthEven[j] % 2 == 1 && sequence[i] > sequence[j])
                        {
                            lengthEven[i] = lengthEven[j] + 1;
                            prevEven[i] = j;
                        }
                    }
                    if (lengthOdd[j] + 1 > lengthOdd[i])
                    {
                        if (lengthOdd[j] % 2 == 0 && sequence[i] > sequence[j] ||
                            lengthOdd[j] % 2 == 1 && sequence[i] < sequence[j])
                        {
                            lengthOdd[i] = lengthOdd[j] + 1;
                            prevOdd[i] = j;
                        }
                    }
                }

                if (maxLen < lengthEven[i])
                {
                    oddIsSmaller = false;
                    maxLen = lengthEven[i];
                    lastIndex = i;
                }
                if (maxLen < lengthOdd[i])
                {
                    oddIsSmaller = true;
                    maxLen = lengthOdd[i];
                    lastIndex = i;
                }
            }

            var longestSeq = new List<int>();

            if (oddIsSmaller)
            {
                while (lastIndex != -1)
                {
                    longestSeq.Add(sequence[lastIndex]);
                    lastIndex = prevOdd[lastIndex];
                }
            }
            else
            {
                while (lastIndex != -1)
                {
                    longestSeq.Add(sequence[lastIndex]);
                    lastIndex = prevEven[lastIndex];
                }
            }
            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}