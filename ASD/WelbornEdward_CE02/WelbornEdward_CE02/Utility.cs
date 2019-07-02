using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE02
{
    class Utility
    {
        public Utility()
        {
            // Placeholder for the public method of the class
        }
        public static void PressAnyKey(string sMessage)
        {
            Console.WriteLine($"\n{sMessage} ");
            Console.ReadKey();
        }
    }
 

}
