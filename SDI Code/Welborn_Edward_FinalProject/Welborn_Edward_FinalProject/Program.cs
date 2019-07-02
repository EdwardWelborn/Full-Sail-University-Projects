// Edward Welborn
// Final Project
// SDI: MDV2330-O
//      C20181002
// 10/18/2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            string[] aPriceArray = new string[] { };
            string sPriceArray = null;
            decimal dShippingCost = 0;
            string sBoxLength = null;
            string sBoxWidth = null;
            string sBoxHeight = null;
            decimal dBoxLength = 0;
            decimal dBoxWidth = 0;
            decimal dBoxHeight = 0;
            int iTierLevel = 0;

            Console.Clear();
            Console.WriteLine("Welcome to Handy Dandy Shippers:");
            Console.WriteLine("-------------------------------");

            while ((!decimal.TryParse(sBoxLength, out dBoxLength)) || (dBoxLength < 1))
            {
                Console.Write("\r\nPlease Enter your package lenght in inches greater than 0: ");
                sBoxLength = Console.ReadLine();
            }
            while ((!decimal.TryParse(sBoxWidth, out dBoxWidth)) || (dBoxWidth < 1))
            {
                Console.Write("Please Enter your package width in inches greater than 0: ");
                sBoxWidth = Console.ReadLine();
            }
            while ((!decimal.TryParse(sBoxHeight, out dBoxHeight)) || (dBoxHeight < 1))
            {
                Console.Write("Please Enter your package height in inches greater than 0: ");
                sBoxHeight = Console.ReadLine();
            }
            iTierLevel = SortByDimensions(dBoxHeight, dBoxLength, dBoxWidth);
            Console.WriteLine("\r\nBased on the dimensions given, your Package will be priced in the " + iTierLevel + " Category:");

            Console.Write("\r\nPlease Enter prices for the package contents, seperated with a comma, no dollar sign needed: ");
            sPriceArray = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(sPriceArray))   
            {
                Console.Write("\r\nPlease Enter prices for the package contents, seperated with a comma, no dollar sign needed: ");
                sPriceArray = Console.ReadLine();
            }
            // Strip $ out of string if they put it in by mistake.
            sPriceArray = sPriceArray.Replace("$", string.Empty);
            // Convert price array string to a character array string, split out the comma
            string[] aCostArray = sPriceArray.Split(',');
            decimal dInsuranceCost = CalcInsurance(aCostArray);
            dShippingCost = TotalCostOfShipping(dInsuranceCost, iTierLevel);
            Console.WriteLine("\r\nYour Total Cost of shipping this package is: " + dShippingCost.ToString("C") + ", with a cost of insurance of " + dInsuranceCost.ToString("C"));

            Console.WriteLine("\r\nPress Any Key to Continue:");
            Console.ReadKey();
        }
        // Calculate Tier Level
        static int SortByDimensions(decimal dHeight, decimal dLength, decimal dWidth)
        {
            // Variable Declaration
            int iTierLevel = 0;
 
            if ((dHeight < 10) || (dLength < 10) || (dWidth < 10))
            {
                // Tier 1
                iTierLevel = 1;

            }
            if ((dHeight >= 10 || dHeight <= 48) || (dLength > 10 || dLength <= 48) || (dWidth > 10 || dWidth <= 48))
            {
                // Tier 2
                iTierLevel = 2;

            }

            if ((dHeight > 48) || (dLength > 48) || (dWidth > 48))
            {
                // Tier 3
                iTierLevel = 3;

            }
            return iTierLevel;

        }
        
        
        // Calculate insurance cost by total contents cost, user input
        static decimal CalcInsurance(string[] aPriceArray)
        {
            // variable Declaration
            decimal dCost = 0;
            decimal dInsuranceCost = 0;

            // Bring in Price Array, and calculate insurance Cost 
            foreach (string sCost in aPriceArray)
            {
                dCost += decimal.Parse(sCost);
            }
            
            if (dCost <= 10)
            {
                dInsuranceCost = 1.00M;
            }
            if ((dCost > 10) && (dCost <= 249))
            {
                dInsuranceCost = 5.00M;
            }
            if ((dCost > 250) && (dCost <= 499))
            {
                dInsuranceCost = 10.00M;
            }
            if (dCost >= 500)
            {
                dInsuranceCost = 25.00M;
            }

            Console.WriteLine("\r\nThe Total Cost of the Package Contents is: " + dCost.ToString("C"));

            return dInsuranceCost;
        }
        // Calculate Total Cost by adding Insurance Cost with The shipping cost by Tier Level
        static decimal TotalCostOfShipping(decimal dCost, int iTierLevel)
        {
            // Variable Declaration
            decimal dTotalShippingCost = 0;
            decimal dShippingCost = 0;

            if (iTierLevel == 1)
            {
                dShippingCost = 6.25M;
            }
            if (iTierLevel == 2)
            {
                dShippingCost = 15.50M;
            }
            if (iTierLevel == 3)
            {
                dShippingCost = 30.00M;
            }

            dTotalShippingCost = dCost + dShippingCost;
            return dTotalShippingCost;
        }
    }
}
/* Test out put for final project
 * Welcome to Handy Dandy Shippers:
-------------------------------

Please Enter your package lenght in inches greater than 0: 5
Please Enter your package width in inches greater than 0: 12
Please Enter your package height in inches greater than 0: 2

Based on the dimensions given, your Package will be priced in the 2 Category:

Please Enter prices for the package contents, seperated with a comma, no dollar sign needed: 50.50, $25.00, 6.00, 150.00

The Total Cost of the Package Contents is: $231.50

Your Total Cost of shipping this package is: $20.50, with a cost of insurance of $5.00

Press Any Key to Continue:
*/
