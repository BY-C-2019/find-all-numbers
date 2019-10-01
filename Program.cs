using System;
using System.Collections.Generic;

namespace find_all_numbers
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            // List for all found numbers from the entered or randomized string of characters
            List<int> numbers = new List<int>();
            // The string
            string randomString = "";
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Hello. Please enter text with characters and numbers mixed. " + 
            "This app has the purpose of finding the numbers and add them together. If you just " + 
            "press ENTER the text is randomized automaticly.");
            Console.ResetColor();

            // String input from user. Random.
            randomString = Console.ReadLine();
            
            // If user just press ENTER randomize string with 200 characters.
            if(randomString == "")
            {
                for(int i = 0; i < 200; i++)
                {
                    randomString += RandomChar();
                }
            }

            System.Console.Write("The string is: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            // Print out the string in blue color
            System.Console.WriteLine(randomString);
            Console.ResetColor();

            string foundNumber = "";

            // Write loop that check all chars and pick out all digits(groups of).
            for (int i = 0; i < randomString.Length; i++)
            {
                if (randomString[i] >= '0' && randomString[i] <= '9')
                {
                    foundNumber += randomString[i];
                }
                else
                {
                    if (foundNumber.Length > 0)
                    {
                        // Delete all leading zeros, if string is more than 1 character long
                        while (foundNumber[0] == '0' && foundNumber.Length > 1)
                        {
                            foundNumber = foundNumber.Remove(0,1);
                        }
                    }

                    // If string contains any numbers convert to int and add to list
                    if (foundNumber.Length >= 1)
                    {
                        numbers.Add(Convert.ToInt32(foundNumber));
                        // Then reset the foundNumber string
                        foundNumber = "";
                    }
                }
            }

            // Print all numbers, add them up and print out sum.
            int sum = 0;
            System.Console.WriteLine("All the numbers found in the string is: ");
            foreach (var number in numbers)
            {
                sum += number;
                System.Console.Write(number + " | ");                
            }
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Total sum of all found numbers is: " + sum);
            Console.ResetColor();
        }


        /// <summary>
        /// Returns one character, 0-9 || a-z || A-Z
        /// </summary>
        /// <returns></returns>
        static char RandomChar()
        {
            char output = '0';
            int charNumber;
            int category = random.Next(0, 3);

            switch (category)
            {
                // Numbers 0 - 9
                case 0:
                    charNumber = random.Next(48, 58);
                    break;

                // Uppercase letters
                case 1:
                    charNumber = random.Next(65, 91);
                    break;

                // Lowercase letters    
                case 2:
                    charNumber = random.Next(97, 123);
                    break;
                
                default:
                    charNumber = 48;
                    break;
            }

            output = (char)charNumber;

            return output;
        }
    }
}
