namespace Problem4.GenerateSubsetsOfStringArray
{
    using System;

    class GenerateSubsetsOfStringArray
    {
        static void Main()
        {
            string[] s = { "test", "rock", "fun" };
            int k = 2;
            string[] arr = new string[k];
            bool[] used = new bool[s.Length + 1];
            GenerateCombinations(s, arr, used, s.Length, 0);
        }

        private static void GenerateCombinations(string[] s, string[] arr, bool[] used, int n, int index, int start = 1)
        {
            if (index > arr.Length - 1)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = s[i - 1];
                        GenerateCombinations(s, arr, used, n, index + 1, i);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(string[] arr)
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
    }
}