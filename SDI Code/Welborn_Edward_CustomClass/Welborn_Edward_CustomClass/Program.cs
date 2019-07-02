// Edward Welborn
// 10/17/2018
// Custom Class Assignment
// SDI: MDV2330-O
//      C20181002
// Program.cs  file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_CustomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            Product sWidget = new Product("Widget", 76.99M, 25.00M);
            Product sFlidget = new Product("Flidget", 35.99M, 10.00M);
            Product sKlidget = new Product("Klidget", 45.98M , 15.00M);
            string sUserChoice = null;
            int iMenu = 0;
            string sProductName = null;
            string sItemCount = null;
            decimal dItemCost;
            decimal dCostToMake;
            decimal dProfitMargin;
            decimal dItemCount;
            decimal dTotalPrice;
            decimal dTotalCost;
            decimal dTotalProfit;
            
            do
            {
                // Zero out variables on each run
                dItemCost = 0;
                dCostToMake = 0;
                dProfitMargin = 0;
                dItemCount = 0;
                dTotalPrice = 0;
                dTotalCost = 0;
                dTotalProfit = 0;
                sItemCount = null;

                Console.Clear();
                Console.WriteLine("Welcome to Home Shopping");
                Console.WriteLine("------------------------\r\n");
                Console.WriteLine("1  Widget");
                Console.WriteLine("2  Flidget");
                Console.WriteLine("3  Klidget");
                Console.WriteLine("4  Exit Program");
                Console.Write("\r\nPlease enter your choice: ");
                sUserChoice = Console.ReadLine();
                iMenu = Convert.ToInt32(sUserChoice);
                if (string.IsNullOrWhiteSpace(sUserChoice) && (iMenu <= 1) && (iMenu >= 4))
                {
                    Console.Write("\r\nPlease Enter your choice between 1 and 4: ");
                    sUserChoice = Console.ReadLine();
                    iMenu = Convert.ToInt32(sUserChoice);
                }

                if (iMenu == 1)
                {
                    sProductName = sWidget.GetItemName();
                    Console.WriteLine("\r\nYou have selected to purchase our wonderful line of " + sProductName);
                   //  Console.Write("How many " + sProductName + " would you like to purchase? ");
                    while ((!decimal.TryParse(sItemCount, out dItemCount)) || (dItemCount < 1))
                    {
                        Console.Write("\r\nHow many " + sProductName + " would you like to purchase ? ");
                        sItemCount = Console.ReadLine();
                    }
                    dItemCost = sWidget.GetItemPrice();
                    dCostToMake = sWidget.GetCostToMake();
                    dProfitMargin = sWidget.ProfitMargin(dCostToMake, dItemCost);
                    break;
                }
                if (iMenu == 2)
                {
                    sProductName = sFlidget.GetItemName();
                    Console.WriteLine("\r\nYou have selected to purchase our wonderful line of " + sProductName);
                    while ((!decimal.TryParse(sItemCount, out dItemCount)) || (dItemCount < 1))
                    {
                        Console.Write("\r\nHow many " + sProductName + " would you like to purchase ? ");
                        sItemCount = Console.ReadLine();
                    }
                    dItemCost = sFlidget.GetItemPrice();
                    dCostToMake = sFlidget.GetCostToMake();
                    dProfitMargin = sFlidget.ProfitMargin(dCostToMake, dItemCost);
                    break;
                }
                if (iMenu == 3)
                {
                    sProductName = sKlidget.GetItemName();
                    Console.WriteLine("\r\nYou have selected to purchase our wonderful line of " + sProductName);
                    while ((!decimal.TryParse(sItemCount, out dItemCount)) || (dItemCount < 1))
                    {
                        Console.Write("\r\nHow many " + sProductName + " would you like to purchase ? ");
                        sItemCount = Console.ReadLine();
                    }
                    dItemCost = sKlidget.GetItemPrice();
                    dCostToMake = sKlidget.GetCostToMake();
                    dProfitMargin = sKlidget.ProfitMargin(dCostToMake, dItemCost);
                    break;
                }
                if (iMenu == 4)
                {
                    ProgramStop();
                    break;
                }
            }
            while (iMenu != 4);

            dTotalPrice = dItemCost * decimal.Parse(sItemCount);
            dTotalCost = dCostToMake * decimal.Parse(sItemCount);
            dTotalProfit = dProfitMargin * decimal.Parse(sItemCount);
            Console.WriteLine("\r\nThe Cost per " + sProductName + " is: " + dItemCost.ToString("C") + ", with the cost to make of  " + dCostToMake.ToString("C") + ", with a profit of " + dProfitMargin.ToString("C") + " each.");
            Console.WriteLine("\r\nYou have ordered " + sItemCount + ", the total cost or your order is " + dTotalPrice.ToString("C") + ", the total cost to make this order is " + dTotalCost.ToString("C") + ", and the total profit of " + dTotalProfit.ToString("C"));
            Console.WriteLine("\r\nPress any key to continue");
            Console.ReadKey();
        }
        static void ProgramStop()
        {
            // program exit method
            
        } 
    }
}
/* Custom Class Test Output 1
 * Welcome to Home Shopping
------------------------

1  Widget
2  Flidget
3  Klidget
4  Exit Program

Please enter your choice: 1

You have selected to purchase our wonderful line of Widget

How many Widget would you like to purchase ? 13

The Cost per Widget is: $25.00, with the cost to make of  $76.99, with a profit of $51.99 each.

You have ordered 13, the total cost or your order is $325.00, the total cost to make this order is $1,000.87, and the total profit of $675.87

Press any key to continue
*/
/* Test output 2 for Custom Class
 * Welcome to Home Shopping
------------------------

1  Widget
2  Flidget
3  Klidget
4  Exit Program

Please enter your choice: 2

You have selected to purchase our wonderful line of Flidget

How many Flidget would you like to purchase ? 14

The Cost per Flidget is: $10.00, with the cost to make of  $35.99, with a profit of $25.99 each.

You have ordered 14, the total cost or your order is $140.00, the total cost to make this order is $503.86, and the total profit of $363.86

Press any key to continue
*/
/* Test Output 3 for Custom Class
 * Welcome to Home Shopping
------------------------

1  Widget
2  Flidget
3  Klidget
4  Exit Program

Please enter your choice: 3

You have selected to purchase our wonderful line of Klidget

How many Klidget would you like to purchase ? 19

The Cost per Klidget is: $15.00, with the cost to make of  $45.98, with a profit of $30.98 each.

You have ordered 19, the total cost or your order is $285.00, the total cost to make this order is $873.62, and the total profit of $588.62

Press any key to continue
*/

