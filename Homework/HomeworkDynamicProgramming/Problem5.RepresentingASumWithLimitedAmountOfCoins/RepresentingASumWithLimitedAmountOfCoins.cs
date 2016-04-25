namespace Problem5.RepresentingASumWithLimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class RepresentingASumWithLimitedAmountOfCoins
    {
        private static List<int> result = new List<int>();
        private static HashSet<string> variations = new HashSet<string>();

        static void Main()
        {
            int[] nums = { 1, 2, 2, 5, 5, 10 };
            int targetSum = 13;

            FindCombinations(targetSum, 0, nums);
            Console.WriteLine("Count: " + variations.Count);
        }

        private static void FindCombinations(int targetSum, int currentIndex, int[] nums)
        {
            if (targetSum == 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Count; i++)
                {
                    sb.Append(result[i] + " ");
                }
                variations.Add(sb.ToString());
            }
            else if (targetSum > 0)
            {
                for (int i = currentIndex; i < nums.Length; i++)
                {
                    targetSum -= nums[i];
                    result.Add(nums[i]);
                    FindCombinations(targetSum, i + 1, nums);//if currentIndex==i then it represents a sum with unlimited amount
                    result.Remove(nums[i]);
                    targetSum += nums[i];
                }
            }
        }
    }
}