using System;
using System.Collections.Generic;

namespace find_all_numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<double>    numberList  = new List<double>();
            double          numberSum   = 0;

            Console.Clear();
            Console.WriteLine("Hej och välkommen till nummerplockaren V1.3.");
            Console.WriteLine("Vänligen banka huvudet i tangentbordet 100 gånger för att få fram en textrad (det går även bra att använda fingrarna sedan V1.2.).");
            Console.WriteLine("---------------------------------");
            Console.Write(": ");
            string inputString = Console.ReadLine();

            // If nothing was typed, ask if user wants to use a randomized string
            if (inputString == "") {
                while (true) {
                    Console.Clear();
                    Console.WriteLine("Det verkar som att du inte skrivit något. Vill du använda en genererad textrad?");
                    Console.Write("j/n: ");
                    inputString = Console.ReadLine().ToLower();
                    
                    if (inputString[0] == 'j') {
                        inputString = GenerateRandomString(200);
                        break;
                    }
                    else if (inputString[0] == 'n') {
                        Console.WriteLine("Nummerplockaren avslutas...");
                        return;
                    }
                }
            }

            // Find numbers in string and add them to list
            FindNumbersInList(inputString, ref numberList);
           
            // Print all numbers that was found
            Console.Clear();
            Console.WriteLine("Följande siffror gömdes i din textrad:");
            Console.WriteLine("-- " + inputString);
            
            foreach (var number in numberList) {
                Console.WriteLine(": {0}", number);
                numberSum += number;
            }

            // Print the sum of all numbers
            Console.WriteLine("---------");
            Console.WriteLine("= {0}", numberSum);
        }

        static string GenerateRandomString(int stringSize)
        {
            // BASIC LATIN NUMBERS 32-126
            const int UNICODE_MIN = 32;
            const int UNICODE_MAX = 126 + 1; // +1 to include 126 in random

            Random rand         = new Random();
            string randomString    = "";

            // Random a unicodedecimal and add it to stringlist
            for (int i = 0; i < stringSize; i++) {
                randomString += (char)(rand.Next(UNICODE_MIN, UNICODE_MAX));
            }

            return randomString;
        }

        static void FindNumbersInList(string listToCheck, ref List<double> listToAddNumbers)
        {
            for (int i = 0; i < listToCheck.Length; i++)
            {
                string numbersInSuccession = "";

                // Get numbers in succession
                while (char.IsDigit(listToCheck[i]) || listToCheck[i] == ',') {
                    numbersInSuccession += listToCheck[i];
                    i++;

                    if (i >= listToCheck.Length) {
                        break;
                    }
                }

                // If string only contains a ','. Reset string.
                if (numbersInSuccession.IndexOf(",") == 0 && numbersInSuccession.Length == 1) {
                    numbersInSuccession = "";
                    continue;
                }
                // If string starts with a ',', add a 0 in front (0,xxxx)
                else if (numbersInSuccession.IndexOf(",") == 0 && numbersInSuccession.Length > 1) {
                    numbersInSuccession = "0" + numbersInSuccession;
                }
                
                // If number(s) has been detected, add it to the list
                if (numbersInSuccession != "") {
                    listToAddNumbers.Add(Convert.ToDouble(numbersInSuccession));
                }
            }
        }
    }
}
