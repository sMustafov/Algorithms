namespace Problem4.RepresentingASumWithUnlimitedAmountOfCoins
{
    using System;

    class RepresentingASumWithUnlimitedAmountOfCoins
    {
        private static int count = 0;

        static void Main()
        {
            int targetSum = 6;
            int[] res = new int[targetSum + 1];
            int[] nums = { 1, 2, 3, 4, 6 };

            res[0] = targetSum;
            DevNum(targetSum, 1, nums, res);

            Console.WriteLine("Count: " + count);
        }

        private static void DevNum(int target, int pos, int[] nums, int[] resultArray)
        {
            for (int i = nums.Length; i > 0; i--)
            {
                int currentNum = nums[i - 1];

                if (target > currentNum)
                {
                    resultArray[pos] = currentNum;

                    if (resultArray[pos] <= resultArray[pos - 1])
                    {
                        DevNum(target - currentNum, pos + 1, nums, resultArray);
                    }
                }
                else if (target == currentNum)
                {
                    resultArray[pos] = currentNum;

                    if (resultArray[pos] <= resultArray[pos - 1])
                    {
                        count++;
                        //Print(pos, resultArray);
                    }
                }
            }
        }

        private static void Print(int pos, int[] res)
        {
            for (int i = 1; i < pos; i++)
            {
                Console.Write(res[i] + " + ");
            }
            Console.Write(res[pos]);
            Console.WriteLine(" = " + res[0]);
        }
    }
}