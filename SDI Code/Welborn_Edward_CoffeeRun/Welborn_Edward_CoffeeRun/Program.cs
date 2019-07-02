//  NAME:  Edward Welborn
//  DATE:  10/06/2018
//  SDI    MDV2330-O
//         C20181002
//  Coffee Run assignment
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_CoffeeRun
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            string[] aCoffeeType = new string[] { "coffee", "cappuccino", "latte", "decaf", "decaf", "cappuccino", "cappuccino", "coffee", "decaf" };
            // First Run Data
            //            { "coffee", "cappuccino", "latte", "cappuccino", "latte", "coffee", "cappuccino", "coffee", "decaf", "cappuccino" };
            int iCoffee = 0;
            int iCappucino = 0;
            int iLatte = 0;
            int iDecaf = 0;
            // Determine how many of each drink was sold
            Console.WriteLine("This will determine how many coffee drinks were sold today:\r\n");

            foreach (string value in aCoffeeType)
            {
                if (value == "coffee")
                {
                    iCoffee++;
                } else if (value == "cappuccino")
                {
                    iCappucino++;
                } else if (value == "latte")
                {
                    iLatte++;
                } else if (value == "decaf")
                {
                    iDecaf++;
                }

            }
            Console.WriteLine(iCoffee + " coffee were sold today");
            Console.WriteLine(iCappucino + " cappucino were sold today");
            Console.WriteLine(iLatte + " latte were sold today");
            Console.WriteLine(iDecaf + " decaf were sold today");
            Console.WriteLine("\r\nPress Any Key to Exit");
            Console.ReadKey();

        }   
    }
}
/* Test output for coffee run #1
 * This will determine how many coffee drinks were sold today:

3 coffee were sold today
4 cappucino were sold today
2 latte were sold today
1 decaf were sold today

Press Any Key to Exit
*/
/* Test Output for coffee run #2
 * This will determine how many coffee drinks were sold today:

2 coffee were sold today
3 cappucino were sold today
1 latte were sold today
3 decaf were sold today

Press Any Key to Exit
*/

