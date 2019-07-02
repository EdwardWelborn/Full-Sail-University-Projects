using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE01
{
    class Utility
    {
        public Utility()
        {

        }
        public static void PressAnyKey(string sMessage)
        {
            Console.WriteLine(sMessage);
            Console.ReadKey();
        }
    }
 

}
