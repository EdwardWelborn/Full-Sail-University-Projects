using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WelbornEdward_CE04
{
    class Validation
    {
        public static string GetString(string sMessage)
        {
            string sInput = null;
            bool bValid = false;
            Console.Write($"\r\n{sMessage} ");
            sInput = Console.ReadLine();
            while (!bValid)
            {
                // !(Regex.IsMatch(sInput, @"^[a-zA-Z]+([ ][a-zA-Z]+)?$")))
                if(string.IsNullOrEmpty(sInput) || string.IsNullOrWhiteSpace(sInput))
                //if (string.IsNullOrEmpty(sInput) || string.IsNullOrWhiteSpace(sInput))
                {
                    Console.Write($"\r\nPlease input a valid name: (letters and space only)");
                    sInput = Console.ReadLine();
                }
                else
                {
                    bValid = true;
                }
            }
            return sInput;
        }
        public static decimal GetDecimal(string sMessage)
        {
            string input = null;
            bool valid = false;
            decimal validCardValue = 0;
            do
            {
                Console.Write(sMessage);
                input = Console.ReadLine();
                if ((decimal.TryParse(input, out validCardValue)))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please Input a Valid decimal number: (numbers and period only)");
                }
            } while (!valid);

            return validCardValue;
        }
        public static int GetInt(string sMessage)
        {
            int validationInt = 0;
            string input = null;
            bool valid = false;

            do
            {
                Console.Write(sMessage);
                input = Console.ReadLine();
                if ((Int32.TryParse(input, out validationInt)))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please Input a Valid number: (numbers only)");
                }
            } while (!valid);

            return validationInt;
        }
        public static int GetIntRange(int min, int max, string sMessage = "Please enter an integer (between 1 and 50): ")
        {
            int validationIntRange = 0;
            string input = null;
            bool valid = false;

            do
            {
                Console.Write(sMessage);
                input = Console.ReadLine();
                if ((Int32.TryParse(input, out validationIntRange) && (validationIntRange >= min) && (validationIntRange <= max)))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Please Input a Valid number: (numbers only between {min} and {max}");
                }
            } while (!valid);

            return validationIntRange;
        }
    }
}

