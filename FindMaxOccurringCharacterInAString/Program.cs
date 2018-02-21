using System;

namespace FindMaxOccurringCharacterInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------Program to find max occuring character in a string--------");
            Console.WriteLine("\n");

            Console.WriteLine("Input the string :");
            var inputString = Console.ReadLine();

            if (inputString != null && inputString.Length == 0)
            {
                Console.WriteLine("Given Input String is blank");
            }
            else if (inputString != null && inputString.Length == 1)
            {
                Console.WriteLine("The Highest frequency of character '{0}'", inputString);
            }

            char maxOccurringCharacter = GetOneMaxOccurringCharacter(inputString);

            Console.WriteLine("The Highest frequency of character '{0}'", maxOccurringCharacter);

            Console.ReadLine();
        }

        private static char GetOneMaxOccurringCharacter(string inputString)
        {
            int lastDistinctCharIndex = 0;
            char[] distinctChars = new char[inputString.Length];
            int [] charOccuranceCount = new int[inputString.Length];
            char maxOccurredChar = '\0';
            int maxOccurredTimes = 0;

            foreach (var character in inputString)
            {
                var index = GetIndexOfCharInDistinctChars(distinctChars, character);
                if(index > 0)
                {
                    ++charOccuranceCount[index];

                    if (charOccuranceCount[index] > maxOccurredTimes)
                    {
                        maxOccurredChar = character;
                        maxOccurredTimes = charOccuranceCount[index];
                    }
                }
                else
                {
                    distinctChars[lastDistinctCharIndex] = character;
                    charOccuranceCount[lastDistinctCharIndex] = 1;
                    ++lastDistinctCharIndex;

                    if (maxOccurredChar != '\0') continue;

                    maxOccurredChar = character;
                    maxOccurredTimes = 1;
                }
            }

            return maxOccurredChar;
        }

        private static int GetIndexOfCharInDistinctChars(char[] distinctChars, char character)
        {
            for(int i = 0; i< distinctChars.Length; i++)
            {
                if (distinctChars[i] == character)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
