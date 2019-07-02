using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE05
{
    class Utility
    {
        public static void PressAnyKey(string sMessage)
        {
            Console.WriteLine("\r\n" + sMessage);
            Console.ReadKey();
        }
    }
 

}
