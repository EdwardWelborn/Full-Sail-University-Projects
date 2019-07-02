using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WelbornEdward_CE09
{
    class Validation
    {
        // VALIDATION NEEDS COMPLETELY REDONE EXCEPT FOR INT AND INTRANGE

       public static int GetInt(string sMessage)
        {
            int validationInt = 0;
            string input = null;
            bool valid = false;

            // (?<=^| )\d+(\.\d+)?(?=$| )|(?<=^| )\.\d+(?=$| )
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
            int validationInt = 0;
            string input = null;
            bool valid = false;

            do
            {
                Console.Write(sMessage);
                input = Console.ReadLine();
                if ((Int32.TryParse(input, out validationInt) && (validationInt >= min) && (validationInt <= max)))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Please Input a Valid number: (numbers only between {min} and {max}");
                }
            } while (!valid);

            return validationInt; 

        }
 

        // ----
        public static decimal GetDecimal(string sMessage = "Please Enter a Decimal")
        {
            decimal validationDecimal = 0; ;
            string input = null;
            bool valid = false;

            do
            {
                Console.Write(sMessage);
                input = Console.ReadLine();
                if ((decimal.TryParse(input, out validationDecimal)))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Please Input a Valid number: (numbers only) ");
                }
            } while (!valid);

            return validationDecimal;
        }

    }
}
