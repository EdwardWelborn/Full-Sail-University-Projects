using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Utility program that will hold exit prompt as well as any other utilities that will be used
namespace Histogram
{
    class Utility
    {
        public static void PressAnyKeyToContinue(string sMessage)
        {
            Console.WriteLine($"\r\n{sMessage}: ");
            Console.ReadKey();
        }
        public static void PrintBars(List<KeyValuePair<string, int>> list)
        {
            // get the max length of all the words so we can align
            int max = list.Max(x => x.Key.Length);
            
            foreach (var item in list)
            {
                // right align using PadLeft and max length
                Console.Write(item.Key.PadLeft(max));

                Console.Write(" ");

                // change color 
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                // Write the bars
                for (int i = 0; i < item.Value; i++)
                    Console.Write(" ");

                // change back
                Console.BackgroundColor = ConsoleColor.Black;

                Console.Write(" ");
                // this creates the new line
                Console.WriteLine(item.Value);
            }
        }
    }
}
