using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE04
{
    class Utility
    {
        public Utility()
        {

        }
        public static void PressAnyKey(string sMessage)
        {
            Console.WriteLine("\r\n" + sMessage);
            Console.ReadKey();
        }
    }
 

}
