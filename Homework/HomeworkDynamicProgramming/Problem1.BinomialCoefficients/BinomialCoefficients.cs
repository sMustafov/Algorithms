namespace Problem1.BinomialCoefficients
{
    using System;

    class BinomialCoefficients
    {
        private const int MAX = 10;
        private static readonly decimal[,] binomCoeff = new decimal[MAX, MAX];

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n, k));
        }

        public static decimal Binom(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }
            
            if (binomCoeff[n, k] == 0)
            {
                binomCoeff[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);
            }
            
            return binomCoeff[n, k];
        }
    }
}