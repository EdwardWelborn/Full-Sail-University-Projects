using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EdwardWelborn_CE01
{
    class Validation
    {
        
        public static string GetCurrentCustomer(string sMessage = "Please Enter a Valid Name (Alpha Only)")
        {
            string sInput = null;
            bool isValid = false;
            
            do
            {
                Console.Write(sMessage);
                sInput = Console.ReadLine();
                isValid = IsAlpha(sInput);
                if(!isValid)
                {
                    Console.WriteLine("Please Input a Valid Name ");
                }

            } while (!isValid);
            
            return sInput;
        }
        public static uint GetCheckingAccount(string sMessage)
        {
            string sInput = null;
            uint validCheckingAccount = 0;
            uint iInput = 0;
            bool isValid = false;
            do
            {
                Console.Write(sMessage);
                sInput = Console.ReadLine();
                isValid = uint.TryParse(sInput, out iInput);
                if (!isValid)
                {
                    Console.WriteLine("Please Input a Valid Checking Account Number (number between 0 to 4,294,967,295) ");
                }

            } while (!isValid);
            validCheckingAccount = iInput;
            return validCheckingAccount;
        }
        public static decimal GetAccountBalance(string sMessage)
        {
            string sInput = null;
            decimal validBalance = 0;
            bool isValid = false;
            do
            {
                Console.Write(sMessage);
                sInput = Console.ReadLine();
                isValid = decimal.TryParse(sInput, out validBalance);
                if (!isValid)
                {
                    Console.WriteLine("Please Input a Valid Account Balance");
                }

            } while (!isValid);
            return validBalance;
        }
        public static bool IsAlpha(string sInput)
        {
            return Regex.IsMatch(sInput, "^(\\b[A-Za-z]*\\b(\\s+\\b[A-Za-z]*\\b)*(\\.[A-Za-z])?)$");
        }
    }
}
