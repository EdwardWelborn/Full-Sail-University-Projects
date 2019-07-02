using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EdwardWelborn_CE08
{
    class Validation
    {

        public static int ValidateInt(string _number)
        {
            int number;

            while (!int.TryParse(_number, out number) || (string.IsNullOrWhiteSpace(_number)))
            {
                Console.Write("You did not enter a valid number. Please try again: ");
                _number = Console.ReadLine();
            }
            return number;
        }
        public static int ValidateIntRange(int min, int max, string _number)
        {
            bool bValidInput = false;
            int number = 0;

            while (!(bValidInput))
            {
                bValidInput = int.TryParse(_number, out number);
                if ((number >= min) && (number <= max))
                {
                    bValidInput = true;
                }
                else
                {
                    Console.Write($"You did not enter a valid number. Must be between {min} and {max}: ");
                    _number = Console.ReadLine();
                    bValidInput = false;
                }
            }
            // Console.WriteLine(number);
            // Utility.PressAnyKeyToContinue("pause");
            return number;
        }
    }
}
