using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CardGame
{
    class Utility
    {
        public static void PressAnyKeyToContinue(string sMessage)
        {
            Console.WriteLine($"\r\n{sMessage}: ");
            Console.ReadKey();
        }
    }
}
