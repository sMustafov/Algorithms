namespace Problem1.GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class GroupPermutations
    {
        private static Dictionary<char, int> lettersCount;

        private static List<char> letters;

        private static StringBuilder lettersSB;

        static void Main()
        {
            lettersCount = new Dictionary<char, int>();
            letters = new List<char>();
            lettersSB = new StringBuilder();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!lettersCount.ContainsKey(input[i]))
                {
                    letters.Add(input[i]);
                    lettersCount[input[i]] = 0;
                }

                lettersCount[input[i]]++;
            }

            GeneratePermutations(letters.ToArray());

            Console.Write(lettersSB);
        }

        private static void GeneratePermutations(char[] array, int startIndex = 0)
        {
            if (startIndex >= array.Length)
            {
                foreach (char letter in array)
                {
                    for (int j = 0; j < lettersCount[letter]; j++)
                    {
                        lettersSB.Append(letter);
                    }
                }
                lettersSB.AppendLine();
            }
            else
            {
                GeneratePermutations(array, startIndex + 1);

                for (int i = startIndex + 1; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    GeneratePermutations(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }
        }

        private static void Swap(ref char i, ref char j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}