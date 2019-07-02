using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WelbornEdward_CE02
{
    static class Validataion
    {
         public static string GetName(string sMessage)
        {
            string sInput = null;
            bool bValid = false;
            Console.Write($"\r\n{sMessage} ");
            sInput = Console.ReadLine();
            while (!bValid)
            {
                if (string.IsNullOrEmpty(sInput) || string.IsNullOrWhiteSpace(sInput))
                {
                    Console.Write($"\r\nPlease input a valid name: ");
                    sInput = Console.ReadLine();
                }
                else
                {
                    bValid = true;
                }
            }
            return sInput;
        }
        public static string GetDescription(string sMessage)
        {
            string sInput = null;
            String validName = null;
            bool bValid = false;
            Console.Write($"{sMessage} ");
            sInput = Console.ReadLine();
            while (!bValid)
            {
                //!(Regex.IsMatch(sInput, @"^[a-zA-Z0-9# ]\S+$")   
                if (string.IsNullOrEmpty(sInput) || string.IsNullOrWhiteSpace(sInput))
                {
                    Console.Write($"\nPlease input a valid entry: ");
                    sInput = Console.ReadLine();
                }
                else
                {
                    bValid = true;
                }
            }
            validName = sInput;
            return validName;
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
/*
 * Input Validation

The menu must handle the user typing the text of a selection or the number
Input should be handled in a case insensitive format
Ex: “1. Create course”
The user should be able to choose the option “1”, “create course”, or even “CrEaTe CoUrSe”.

 */

