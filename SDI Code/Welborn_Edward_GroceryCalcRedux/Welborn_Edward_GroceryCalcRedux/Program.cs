/* 
 * Welborn_Edward_GroceryCalculator
 * Scalable Data Infrastructure
 * MDV2330-O
 * C20181002
 * This was the first programming assignment in SDI
*/

using System;

namespace Welborn_Edward_GroceryCalc
{
    class Program
    {
        static void Main(string[] args)
        {

            // Variable Declaration
            int[] iFoodCount = new int[3];
            double[] dFoodCost = new double[3];
            double[] dTotalCost = new double[3];
            double dTotalTax;
            float fSalesTax = 0;
            double dTotalBeforeTax;
            double dTotalSale;
            string sFoodCount;
            string sFoodCost;
            string sSalesTax;
            string[] sFoodItem = new string[] { "Apple", "Steak", "Ice Cream" };

            // Header
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\nHandy Dandy Grocery Calculator");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            // Get number of apples purchased and cost per Apple.
            Console.Write("\r\nHow manny Apples were purchased? ");
            Console.ForegroundColor = ConsoleColor.Green;
            sFoodCount = Console.ReadLine();

            // Check to make sure there is a value above 0 for apples
            while (string.IsNullOrEmpty(sFoodCount) || Convert.ToInt32(sFoodCount) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What is the how many apples purchased greater than 0? ");
                Console.ForegroundColor = ConsoleColor.Green;   
                sFoodCount = Console.ReadLine();
            }
            iFoodCount[0] = Convert.ToInt32(sFoodCount);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What is the Price per Apple? ");
            Console.ForegroundColor = ConsoleColor.Green;   
            sFoodCost = Console.ReadLine();
            while (string.IsNullOrEmpty(sFoodCost) || Convert.ToDouble(sFoodCost) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What is the price per apples must be greater than 0? ");
                Console.ForegroundColor = ConsoleColor.Green;
                sFoodCost = Console.ReadLine();
            }
            dFoodCost[0] = Convert.ToDouble(sFoodCost);

            // Get number os steaks purchased and cost per Steak
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nHow many Steaks were purchased? ");
            Console.ForegroundColor = ConsoleColor.Green;
            sFoodCount = Console.ReadLine();
            while (string.IsNullOrEmpty(sFoodCount) || Convert.ToInt32(sFoodCount) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\nWhat is the how many Steaks purchased greater than 0? ");
                Console.ForegroundColor = ConsoleColor.Green;
                sFoodCount = Console.ReadLine();
            }

            iFoodCount[1] = Convert.ToInt32(sFoodCount);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What is the Price per Steak? ");
            Console.ForegroundColor = ConsoleColor.Green;   
            sFoodCost = Console.ReadLine();
            while (string.IsNullOrEmpty(sFoodCost) || Convert.ToDouble(sFoodCost) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What is the price per steaks must be greater than 0? ");
                Console.ForegroundColor = ConsoleColor.Green;
                sFoodCost = Console.ReadLine();
            }
            dFoodCost[1] = Convert.ToDouble(sFoodCost);
            // Get number of Ice Cream purchased and cost per ice cream
            Console.ForegroundColor = ConsoleColor.White;   
            Console.Write("\r\nHow many Ice Creams containers were purchased? ");
            Console.ForegroundColor = ConsoleColor.Green;   
            sFoodCount = Console.ReadLine();
            while (string.IsNullOrEmpty(sFoodCount) || Convert.ToInt32(sFoodCount) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;   
                Console.Write("\r\nWhat is the how much Ice Cream purchased greater than 0? ");
                Console.ForegroundColor = ConsoleColor.Green;
                sFoodCount = Console.ReadLine();
            }
            iFoodCount[2] = Convert.ToInt32(sFoodCount);
            Console.ForegroundColor = ConsoleColor.White;   
            Console.Write("What is the price per Ice Cream container? ");
            Console.ForegroundColor = ConsoleColor.Green;   
            sFoodCost = Console.ReadLine();
            while (string.IsNullOrEmpty(sFoodCost) || Convert.ToDouble(sFoodCost) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;   
                Console.Write("What is the price of Ice Cream must be greater than 0? ");
                Console.ForegroundColor = ConsoleColor.Green;   
                sFoodCost = Console.ReadLine();
            }
            dFoodCost[2] = Convert.ToDouble(sFoodCost);
            // Calculate Total Food Cost
            dTotalCost[0] = iFoodCount[0] * dFoodCost[0];
            dTotalCost[1] = iFoodCount[1] * dFoodCost[1];
            dTotalCost[2] = iFoodCount[2] * dFoodCost[2];
            // Calculate Tax
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n----------------------------------");
            Console.ForegroundColor = ConsoleColor.White;   
            Console.Write("\r\nWhat is the Sales Tax in your Area?: ");
            Console.ForegroundColor = ConsoleColor.Green;   
            sSalesTax = Console.ReadLine();
            fSalesTax = Convert.ToSingle(sSalesTax);
            fSalesTax = fSalesTax / 100;
            dTotalSale = dTotalCost[0] + dTotalCost[1] + dTotalCost[2];
            dTotalTax = dTotalSale * Convert.ToDouble(fSalesTax);
            dTotalSale = dTotalSale + dTotalTax;
            // Final Output and Totals
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nThe Total Cost for your ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(iFoodCount[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Apples is: $");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dTotalCost[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The Total Cost for your ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(iFoodCount[1]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Steaks is: $");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dTotalCost[1]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The Total Cost for your ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(iFoodCount[2]);
            Console.ForegroundColor = ConsoleColor.White;   
            Console.Write(" Ice Cream is: $");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dTotalCost[2]);
            
            dTotalBeforeTax = dTotalCost[0] + dTotalCost[1] + dTotalCost[2];
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nThe Total Cost Before Tax is: $");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dTotalBeforeTax);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nTotal Tax: $");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dTotalTax);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("The total Sales for this trip is: $");
            Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine(dTotalSale);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n");
            Console.WriteLine("Press any key to continue.. ");
            Console.ReadKey();
        }
    }
}
/* Test 1
 * Handy Dandy Grocery Calculator
-------------------------------

How manny Apples were purchased? 4
What is the Price per Apple? .50
How many Steaks were purchased? 2
What is the Price per Steak? 15.25
How many Ice Creams containers were purchased? 1
What is the price per Ice Cream container? 5.75


----------------------------------


What is the Sales Tax in your Area?: 7


The Total Cost for your 4 Apples is: $2.00
The Total Cost for your 2 Steaks is: $30.50
The Total Cost for your 1 Ice Cream is: $5.75

The Total Cost Before Tax is: $38.25


Total Tax: $2.68
The total Sales for this trip is: $40.93

Press any key to continue..
*/
/* Handy Dandy Grocery Calculator
-------------------------------

How manny Apples were purchased? 5
What is the Price per Apple? .89
How many Steaks were purchased? 6
What is the Price per Steak? 13.57
How many Ice Creams containers were purchased? 4
What is the price per Ice Cream container? 2.98


----------------------------------


What is the Sales Tax in your Area?: 7.235


The Total Cost for your 5 Apples is: $4.45
The Total Cost for your 6 Steaks is: $81.42
The Total Cost for your 4 Ice Cream is: $11.92

The Total Cost Before Tax is: $97.79


Total Tax: $7.08
The total Sales for this trip is: $104.87


Press any key to continue..
 */

