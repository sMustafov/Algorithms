namespace Problem5.EgyptianFractions
{
    using System;

    class EgyptianFractions
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split('/');

            long numerator = long.Parse(input[0]);
            long denominator = long.Parse(input[1]);

            if (numerator / denominator >= 1)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Fraction(numerator, denominator);
        }

        private static void Fraction(long numerator, long denominator)
        {
            Console.Write("{0}/{1} = ", numerator, denominator);

            if (denominator % numerator == 0)
            {
                denominator /= numerator;
                numerator = 1;
            }

            while (numerator > 1)
            {
                long r = (denominator + numerator) / numerator;

                Console.Write("1/{0} + ", r);

                numerator = numerator * r - denominator;
                denominator = denominator * r;

                if (denominator % numerator == 0)
                {
                    denominator /= numerator;
                    numerator = 1;
                }
            }

            if (numerator > 0)
            {
                Console.Write("{0}/{1} ", numerator, denominator);
            }

            Console.WriteLine();
        }
    }
}