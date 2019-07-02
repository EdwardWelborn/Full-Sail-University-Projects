/* 
 * Welborn_Edward_MadLibs
 * Scalable Data Infrastructure
 * MDV2330-O
 * C20181002
 * MadLibs Assignment
 * 09/28/2018
 * Second Programming Assignment from SDI 
*/



using System;

namespace Welborn_Edward_MadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration and Initialization
            string[] sStringInput = new string[4];
            double[] dNumberInput = new double[3];

            // Input all the String Inputs
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\nMadlib Creation Kit:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Input an Animal: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sStringInput[0] = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Input a Name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sStringInput[1] = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Input an Adjective: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sStringInput[2] = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Input a Food Item: ");
            Console.ForegroundColor = ConsoleColor.Blue;   
            sStringInput[3] = Console.ReadLine();

            // Input all the number inputs
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Input a four Digit Year: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            dNumberInput[0] = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Input a Cost:(number only) ");
            Console.ForegroundColor = ConsoleColor.Blue;
            dNumberInput[1] = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Input any random number: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            dNumberInput[2] = Convert.ToDouble(Console.ReadLine());

            // Show the madlib the user created
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\nHere is the Madlib, that you created: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nIt was halloween, " + dNumberInput[0] + ", and " + sStringInput[1] + " was setting out all of the halloween candy and " + sStringInput[3] + " for the kids that will come visit.  He was very " + sStringInput[2] + " that the cost of the decorations was only {0:C2}", dNumberInput[1] + ". His pet " + sStringInput[0] + " was sitting in his lap as he was getting ready for the " + dNumberInput[2] + " children that may show up.");
            Console.ForegroundColor = ConsoleColor.Red;
            // Pause program before exit
            Console.WriteLine("\r\nPress any key to continue");
            Console.ReadKey();

        }
    }
}
/*	It was halloween {year} and {name] was setting out all of the halloween candy and {foot item} for the kids.
 *	he was very [adjective] that the cost of the decorations was only {cost].  His pet {animal} was sitting on his 
 *	lap as he was getting ready for the [random number} of children that may show up.
 *	
Test Result

Madlib Creation Kit:
--------------------


Please Input an Animal: Monkey
Please Input a Name: Roy
Please Input an Adjective: sleeping
Please Input a Food Item: hamburger


Please Input a four Digit Year: 2018
Please Input a Cost:(number only) 125.75
Please Input any random number: 234


Here is the Madlib, that you created:


It was halloween, 2018, and Roy was setting out all of the halloween candy and hamburger for the kids that will come visit.  He was very sleeping that the cost of the decorations was only 125.75. His pet Monkey was sitting in his lap as he was getting ready for the 234 children that may show up.


Press any key to continue


*/
