namespace Blocks
{
    using System;
    using System.Text;

    public class Blocks
    {
        public static void Main()
        {
            int numberOfLetters = int.Parse(Console.ReadLine());

            int counter = 0;
            var blocks = new StringBuilder();
            var lastLetter = 'A' + numberOfLetters - 1;

            for (char firstLetter = 'A'; firstLetter <= lastLetter; firstLetter++)
            {
                for (char secondLetter = (char)(firstLetter + 1); secondLetter <= lastLetter; secondLetter++)
                {
                    for (char thirdLetter = (char)(firstLetter + 1); thirdLetter <= lastLetter; thirdLetter++)
                    {
                        if (thirdLetter != secondLetter)
                        {
                            for (char forthLetter = (char)(firstLetter + 1); forthLetter <= lastLetter; forthLetter++)
                            {
                                if (forthLetter != thirdLetter && forthLetter != secondLetter)
                                {
                                    var block = string.Format("{0}{1}{2}{3}", firstLetter, secondLetter, thirdLetter, forthLetter);
                                    blocks.AppendLine(block);
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Number of blocks: {0}", counter);
            Console.WriteLine(blocks.ToString().Trim());
        }
    }
}