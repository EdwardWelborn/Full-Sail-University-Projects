using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Polymorphism
{
    class Utility
    {
        public static void PauseBeforeExit()
        {
            Console.WriteLine("Press Any Key to Exit:");
            Console.ReadKey();
        }
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
        }


}
}
