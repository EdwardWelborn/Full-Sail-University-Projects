/* Edward Welborn
 * MDV2330-O
 * C20181002
 * 10/03/2018
 * Conditionals Assignment
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Initialization
            int iMenu = 0;
            string sUserChoice = "";
            bool bFlag = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nConditionals Assignment");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{1}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Hit the Jackpot");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{2}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Lets Make a Deal");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{3}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Pumpkin Patch Pickers");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{4}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Loyalty Card");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\r\n{5}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Exit Program");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\r\nPlease enter your choice: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sUserChoice = Console.ReadLine();
                bFlag = int.TryParse(sUserChoice, out iMenu);

                if ((!bFlag) && (iMenu <= 1) && (iMenu >= 5))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\r\nPlease Enter your choice between 1 and 5: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    sUserChoice = Console.ReadLine();
                    iMenu = Convert.ToInt32(sUserChoice);
                }
                Console.Clear();
                
                if (iMenu == 1)
                {
                    Jackpot();
                }
                if (iMenu == 2)
                {
                    LetsMakeADeal();
                }
                if (iMenu == 3)
                {
                    PumpkinPatch();
                }
                if (iMenu == 4)
                {
                    LoyaltyCard();
                }
                if (iMenu == 5)
                {
                    ProgramStop();
                    break;
                }
            }
            while (iMenu != 5);

        }

        // Procedure for Problem 1, Hit The Jackpot!
        static void Jackpot()
        {
            //Variable Declaration
            string sWinningsAmount;
            string sWinningsOutput;
            string sPaymentType;
            decimal dWinnings;
            decimal dTakeHome;
            bool bflag = false;

            // Console.WriteLine("You chose to Hit The Jackpot!");
            // Calculations, user input, and description of the problem
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n\r\nCongratulations!! You have won the lottery!  We will now calculate how much your actual total");
            Console.WriteLine("winnings will be.  You have two option of collecting your winnings: the first option is a lump sum one-tine payment.");
            Console.WriteLine("If you do this, you will only recieve 85% of your winnings.  The second option is to take 20 annual");
            Console.WriteLine("paments, but you will take the full amound of your winnings.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\n\r\nPlease Enter the Amount of your Winnings: $");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sWinningsAmount = Console.ReadLine();
            sWinningsOutput = string.Format("{0:c2}", sWinningsAmount);
            bflag = decimal.TryParse(sWinningsAmount, out dWinnings);
            while (!bflag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\n\r\nPlease Enter the Amount of your Winnings greater than 0: $");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sWinningsAmount = Console.ReadLine();
                bflag = decimal.TryParse(sWinningsAmount, out dWinnings);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Choose a Dispiursement Type: L for Lunp Sun, or A for Annual payment over time: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sPaymentType = Console.ReadLine();
            sPaymentType = sPaymentType.ToUpper();
            bflag = true;
            do
            {
                if (sPaymentType == "L")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\r\nYou have Chosen a Lump Sum");
                    dTakeHome = ((dWinnings * 85) / 100);
                    Console.WriteLine("\r\nYour Lump Sum payment for your winnings of " + dWinnings.ToString("C2") + " will be: " + dTakeHome.ToString("C2"));
                    bflag = false;
                }
                else if (sPaymentType == "A")
                {
                    // Console.WriteLine("\r\nYou have chosen annual payment over time");
                    dTakeHome = (dWinnings / 20);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\r\nYour winnings of " + dWinnings.ToString("C2") + " over the next 2o years, will be: " + dTakeHome.ToString("C2") + " per year");
                    bflag = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\r\nPlease only choose L for lump sum or A for annual payment:");
                    sPaymentType = Console.ReadLine();
                    sPaymentType = sPaymentType.ToUpper();
                }
            }
            while (bflag);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n\r\nPress Any Key to Return to Main Menu");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        // Section for Problem 2 Let's Make a Deal
        static void LetsMakeADeal()
        {
            // Variable declaration
            double dCostOfSingleItem;
            double dItemsInBulkPack;
            double dCouponValue;
            double dCostOfBulk;
            double dTotalCostOfBulk;
            double dTotalCostOfSingle;
            string sCostOfSingleItem;
            string sItemsInBulkPack;
            string sCouponValue;
            string sCostOfBulk;
            bool bFlag;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\n\r\nLet's see which is cheaper, the cost of an item in bulk, or the cost of the single item with a coupon.");
            Console.Write("\r\nPlease Enter the Cost for the Bulk Item: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sCostOfBulk = (Console.ReadLine());
            bFlag = double.TryParse(sCostOfBulk, out dCostOfBulk);
            while (!bFlag)
            {
                Console.Write("\r\nPlease Enter the correct Cost for the Bulk Item: ");
                sCostOfBulk = (Console.ReadLine());
                bFlag = double.TryParse(sCostOfBulk, out dCostOfBulk);
            } 
            
            Console.Write("Please Enter how many items are in the bulk package: ");
            sItemsInBulkPack = Console.ReadLine();
            bFlag = double.TryParse(sItemsInBulkPack, out dItemsInBulkPack);
            while (!bFlag)
            {
                Console.Write("\r\nPlease Enter the correct items in the Bulk Pack: ");
                sItemsInBulkPack = Console.ReadLine();
                bFlag = double.TryParse(sItemsInBulkPack, out dItemsInBulkPack);
            }

            Console.Write("Please Enter price per each item: ");
            sCostOfSingleItem = Console.ReadLine();
            bFlag = double.TryParse(sCostOfSingleItem, out dCostOfSingleItem);
            while (!bFlag)
            {
                Console.Write("\r\nPlease Enter the correct Cost for the Single Item: ");
                sCostOfSingleItem = Console.ReadLine();
                bFlag = double.TryParse(sCostOfSingleItem, out dCostOfSingleItem);
            }

            Console.Write("Pkeaes Enter the coupon value: ");
            sCouponValue = Console.ReadLine();
            bFlag = double.TryParse(sCouponValue, out dCouponValue);
            while (!bFlag)
            {
                Console.Write("\r\nPlease Enter the correct Cost for the coupon: ");
                sCouponValue = Console.ReadLine();
                bFlag = double.TryParse(sCouponValue, out dCouponValue);
            }
            // Do The calculation and write out the results
            dTotalCostOfBulk = dCostOfBulk / dItemsInBulkPack;
            dTotalCostOfSingle = dCostOfSingleItem - dCouponValue;
            if (dTotalCostOfBulk < dTotalCostOfSingle)
            {
                Console.WriteLine("\r\nThe Cost to buy one item in the bulk pack is " + dTotalCostOfBulk.ToString("C2") + ", Which is cheaper than buying the single item with a coupon at " + dTotalCostOfSingle.ToString("C2") + " buy this in bulk.");
            } else
                Console.WriteLine("\r\nThe Cost to buy one item with a coupon is " + dTotalCostOfSingle.ToString("C2") + ", Which is cheaper than buying in bulk at " + dTotalCostOfBulk.ToString("C2") + " buy this in single items.");
                

                            Console.WriteLine("\r\n\r\nPress Any Key to Return to Main Menu");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        // Section for Problem 3 Pumpkin Path Pickers
        static void PumpkinPatch()
        {
            //  Variable Declaraton
            double dWeightOfPumpkin = 0;
            double dTotalCost = 0;
            string sWeightofPumpkin;
            bool bFlag = false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\nWelcome to Pumpkin Patch Pickers.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Choose the weight of your Pumpkin and we will calculate the cost for you: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sWeightofPumpkin = Console.ReadLine();
            bFlag = double.TryParse(sWeightofPumpkin, out dWeightOfPumpkin);

            // Statement to calculate price per pound if a certain weight
            do
            {
                if (dWeightOfPumpkin <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\r\nPlease Choose the weight of your Pumpkin and we will calculate the cost for you: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    sWeightofPumpkin = Console.ReadLine();
                    bFlag = double.TryParse(sWeightofPumpkin, out dWeightOfPumpkin);
                }
                else if (dWeightOfPumpkin < 5.5)
                {
                    dTotalCost = dWeightOfPumpkin * 1;
                }
                else if (dWeightOfPumpkin <= 10.75)
                {
                    dTotalCost = dWeightOfPumpkin * .90;
                }
                else if (dWeightOfPumpkin <= 25)
                {
                    dTotalCost = dWeightOfPumpkin * .80;
                }
                else if (dWeightOfPumpkin <= 50)
                {
                    dTotalCost = dWeightOfPumpkin * .70;
                }
                else if (dWeightOfPumpkin <= 100)
                {
                    dTotalCost = dWeightOfPumpkin * .60;
                }
                else if (dWeightOfPumpkin > 100)
                {
                    dTotalCost = dWeightOfPumpkin * .50;
                }
            } while (!bFlag);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\nThe total cost for your " + dWeightOfPumpkin + "lb pumpkin is: " + dTotalCost.ToString("C2"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nPress Any Key to Return to Main Menu");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        static void LoyaltyCard()
        {
            // Variable Declaration
            double dFirstItem = 0;
            double dSecondItem = 0;
            double dTotalCost = 0;
            double dDiscount = 0;
            string sMembership;
            string sFirstItem;
            string sSecondItem;
            bool bflag = true;

            // Section for Problem 4 Loyalty Card
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\n\r\nLoyalty Card Cost Calculator");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\n\r\nPlease Enter the Cost of your First item: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sFirstItem = Console.ReadLine();
            bflag = double.TryParse(sFirstItem, out dFirstItem);
            while (!bflag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\nPlease Enter the Cost of your First item: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sFirstItem = Console.ReadLine();
                bflag = double.TryParse(sFirstItem, out dFirstItem);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Enter the Cost of your Second Item: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sSecondItem = Console.ReadLine();
            bflag = double.TryParse(sSecondItem, out dSecondItem);
            while (!bflag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\n\r\nPlease Enter the Cost of your Second item: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sSecondItem = Console.ReadLine();
                bflag = double.TryParse(sSecondItem, out dSecondItem);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Are you a Preferred Member? (yes or no) ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sMembership = Console.ReadLine();
            sMembership = sMembership.ToLower();
            do
            {
                if (sMembership == "yes")
                {

                    dDiscount = ((dFirstItem + dSecondItem) * 15) / 100;
                    dTotalCost = (dFirstItem + dSecondItem);
                    dTotalCost = dTotalCost - dDiscount;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\r\nYour Total Cost for the 2 items with your 15% membership discout is: " + dTotalCost.ToString("C2"));
                    bflag = false;
                }
                else if (sMembership == "no")
                {
                    dTotalCost = (dFirstItem + dSecondItem);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\r\nYou Total Cost for the 2 items is: " + dTotalCost.ToString("C2"));
                    bflag = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Please Enter either yes, or no for your membership question: ");
                    sMembership = Console.ReadLine();
                    sMembership = sMembership.ToLower();
                }
            }
            while (bflag);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nPress Any Key to Return to Main Menu");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        static void ProgramStop()
        {
            // Section for Problem 5 Exit the Program
            
          
        }

    }
}
/* Test output 1 for Hit the Jackpot!
 * 
Congratulations!! You have won the lottery!  We will now calculate how much your actual total
winnings will be.  You have two option of collecting your winnings: the first option is a lump sum one-tine payment.
If you do this, you will only recieve 85% of your winnings.  The second option is to take 20 annual
paments, but you will take the full amound of your winnings.


Please Enter the Amount of your Winnings: $20000

Please Choose a Dispiursement Type: L for Lunp Sun, or A for Annual payment over time: A

Your winnings of $20,000.00 over the next 2o years, will be: $1,000.00 per year

*/
/* Test Output 2 for Hit The JackPot!
 * 
 Congratulations!! You have won the lottery!  We will now calculate how much your actual total
winnings will be.  You have two option of collecting your winnings: the first option is a lump sum one-tine payment.
If you do this, you will only recieve 85% of your winnings.  The second option is to take 20 annual
paments, but you will take the full amound of your winnings.


Please Enter the Amount of your Winnings: $100000.50

Please Choose a Dispiursement Type: L for Lunp Sun, or A for Annual payment over time: L

You have Chosen a Lump Sum

Your Lump Sum payment for your winnings of $100,000.50 will be: $85,000.43


 */
/* Test Output 3 for Hit The Jackpot!
 * Congratulations!! You have won the lottery!  We will now calculate how much your actual total
winnings will be.  You have two option of collecting your winnings: the first option is a lump sum one-tine payment.
If you do this, you will only recieve 85% of your winnings.  The second option is to take 20 annual
paments, but you will take the full amound of your winnings.


Please Enter the Amount of your Winnings: $65000000.99

Please Choose a Dispiursement Type: L for Lunp Sun, or A for Annual payment over time: a

Your winnings of $65,000,000.99 over the next 2o years, will be: $3,250,000.05 per year

 */
/* Test Output 1 for Let's make a deal
 * Let's see which is cheaper, the cost of an item in bulk, or the cost of the single item with a coupon.

Please Enter the Cost for the Bulk Item: 100
Please Enter how many items are in the bulk package: 50
Please Enter price per each item: 4.50
Pkeaes Enter the coupon value: 1.00

The Cost to buy one item in the bulk pack is $2.00, Which is cheaper than buying the single item with a coupon at $3.50 buy this in bulk.

 */
/* Test Output 2 for Let's make a deal
 * Let's see which is cheaper, the cost of an item in bulk, or the cost of the single item with a coupon.

Please Enter the Cost for the Bulk Item: 80.50
Please Enter how many items are in the bulk package: 20
Please Enter price per each item: 6.25
Pkeaes Enter the coupon value: 2.25

The Cost to buy one item with a coupon is $4.00, Which is cheaper than buying in bulk at $4.03 buy this in single items.
 */
/* Test Output 3 for Let's Make a Deal
 * Let's see which is cheaper, the cost of an item in bulk, or the cost of the single item with a coupon.

Please Enter the Cost for the Bulk Item:

Please Enter the correct Cost for the Bulk Item: 75.99
Please Enter how many items are in the bulk package: 14
Please Enter price per each item: 3.99
Pkeaes Enter the coupon value: 1.50

The Cost to buy one item with a coupon is $2.49, Which is cheaper than buying in bulk at $5.43 buy this in single items.
 */
/* Test Output for Pumpkin Patch Pickers:
 *

Welcome to Pumpkin Patch Pickers.

Please Choose the weight of your Pumpkin and we will calculate the cost for you: 4.5

The total cost for your 4.5lb pumpkin is: $4.50

Welcome to Pumpkin Patch Pickers.

Please Choose the weight of your Pumpkin and we will calculate the cost for you: 10

The total cost for your 10lb pumpkin is: $9.00

Welcome to Pumpkin Patch Pickers.

Please Choose the weight of your Pumpkin and we will calculate the cost for you: 20.75

The total cost for your 20.75lb pumpkin is: $16.60

Welcome to Pumpkin Patch Pickers.

Please Choose the weight of your Pumpkin and we will calculate the cost for you: 100

The total cost for your 100lb pumpkin is: $60.00

Welcome to Pumpkin Patch Pickers.

Please Choose the weight of your Pumpkin and we will calculate the cost for you: 150.30

The total cost for your 150.3lb pumpkin is: $75.15

Welcome to Pumpkin Patch Pickers.

Please Choose the weight of your Pumpkin and we will calculate the cost for you: 62

The total cost for your 62lb pumpkin is: $37.20
 */
/* Test OutPut 1 for Loyalty Card
 * Loyalty Card Cost Calculator
----------------------------


Please Enter the Cost of your First item: 45.5
Please Enter the Cost of your Second Item: 75
Are you a Preferred Member? (yes or no) yes

Your Total Cost for the 2 items with your 15% membership discout is: $102.43

 */
/* Test Output 2 for Loyalty Card
 
 Loyalty Card Cost Calculator
----------------------------


Please Enter the Cost of your First item: 23
Please Enter the Cost of your Second Item: 44.25
Are you a Preferred Member? (yes or no) no

You Total Cost for the 2 items is: $67.25

 */
/* Test Output 3 for Loyalty Card
 * Loyalty Card Cost Calculator
----------------------------


Please Enter the Cost of your First item: 37.50
Please Enter the Cost of your Second Item: 29.99
Are you a Preferred Member? (yes or no)
Please Enter either yes, or no for your membership question: yes

Your Total Cost for the 2 items with your 15% membership discout is: $57.37
 */



