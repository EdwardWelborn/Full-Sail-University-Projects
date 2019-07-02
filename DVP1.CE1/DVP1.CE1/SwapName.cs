using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVP1.CE1
{
    class SwapName
    {
        public static string NameSwap(string sFirstName, string sLastName)
        {
            string sNewName = "";
            Console.WriteLine("Converting Name, One Moment Please...");
            sNewName = sLastName + " " + sFirstName;
            Console.ReadKey();
            return sNewName;

        }
    }
}
