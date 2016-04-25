﻿namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            var firstStr = "tree";
            var secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
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
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            var sequance = new List<char>();
            for (int x = lcs.GetUpperBound(0); x >= 0; x--)
            {
                for (int y = lcs.GetUpperBound(1); y >= 0; y--)
                {
                    while (x > 0 && y > 0)
                    {
                        if (firstStr[x - 1] == secondStr[y - 1])
                        {
                            sequance.Add(firstStr[x - 1]);
                            x--;
                            y--;
                        }
                        else if (lcs[x, y] == lcs[x - 1, y])
                        {
                            x--;
                        }
                        else
                        {
                            y--;
                        }
                    }
                }
            }

            sequance.Reverse();

            return new string(sequance.ToArray());
        }
    }
}