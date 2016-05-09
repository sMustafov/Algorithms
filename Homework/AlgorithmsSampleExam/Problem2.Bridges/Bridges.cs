namespace Problem2.Bridges
{
    using System;
    using System.Linq;

    class Bridges
    {
        private static void Main()
        {
            var firstSeq = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondSeq = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var result = FindLongestCommonSubsequence(firstSeq, secondSeq);
            Console.WriteLine(result);
        }

        public static int FindLongestCommonSubsequence(int[] firstStr, int[] secondStr)
        {
            int firstLen = firstStr.Length + 1;
            int secondLen = secondStr.Length + 1;
            var lcs = new int[firstLen, secondLen];

            for (int i = 1; i < firstLen; i++)
            {
                for (int j = 1; j < secondLen; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j] + 1, lcs[i, j - 1] + 1);
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            return lcs[lcs.GetUpperBound(0), lcs.GetUpperBound(1)];
        }
    }
}