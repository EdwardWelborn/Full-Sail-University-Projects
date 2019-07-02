/* Edward Welborn
 * 10/5/2018
 * Logic Loops
 * SDI
 * MDV2330-O
 * C20181002
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_LogicLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            string sUserChoice;
            int iMenu = 0;
            bool bflag = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nLogic Loops Assignment");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<1>  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Making the Grade");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<2>  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Operation Brunch Bunch");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<3>  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Add Them Up");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<4>  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Cha-Ching");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\r\n<5>  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Exit Program");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\r\nPlease enter your choice: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                sUserChoice = Console.ReadLine();
                bflag = Int32.TryParse(sUserChoice, out iMenu);
                if ((bflag) && (iMenu <= 1) && (iMenu >= 5))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\r\nPlease Enter your choice between 1 and 5: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    sUserChoice = Console.ReadLine();
                    iMenu = Convert.ToInt32(sUserChoice);
                }
                Console.Clear();

                if (iMenu == 1)
                {
                    MakingTheGrade();
                }
                if (iMenu == 2)
                {
                   OperationBrunchBunch();
                }
                if (iMenu == 3)
                {
                    AddThemUp();
                }
                if (iMenu == 4)
                {
                    ChaChing();
                }
                if (iMenu == 5)
                {
                    ProgramStop();
                    break;
                }
            }
            while (iMenu != 5);
        }
       
        // Problem	#1 – Logical	Operators:	Making	The	Grade
        static void MakingTheGrade()
        {
            // Variable Declaration
            int[] aGradeCheck = new int[2];
            string sGradeCheck;
            bool bFlag = false;
            bool bGradeCheckA;
            bool bGradeCheckB;

            // Input first grade and validation
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease enter the first grade to evaluate in numbers: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sGradeCheck = Console.ReadLine();
            bFlag = int.TryParse(sGradeCheck, out aGradeCheck[0]);
            while ((!bFlag) || ((aGradeCheck[0] < 0) && (aGradeCheck[0] > 100)))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\nPlease enter a vaid number for your First grade to evaluate greater than 0: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sGradeCheck = Console.ReadLine();
                bFlag = int.TryParse(sGradeCheck, out aGradeCheck[0]);
            }

            //Input second grade and validation
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter the second grade to evaluate in numbers: ");
            Console.ForegroundColor = ConsoleColor.Cyan; 
            sGradeCheck = Console.ReadLine();
            bFlag = int.TryParse(sGradeCheck, out aGradeCheck[1]);
            while ((!bFlag) || ((aGradeCheck[1] < 0) && (aGradeCheck[1] > 100)))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\nPlease enter a vaid number for your Second grade to evaluate greater than 0: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sGradeCheck = Console.ReadLine();
                bFlag = int.TryParse(sGradeCheck, out aGradeCheck[1]);
            }
            
            // Find out if the grades are passing or not
            if (aGradeCheck[0] < 70)
            {
                bGradeCheckA = false;
            } else
                bGradeCheckA = true;
            if (aGradeCheck[1] < 70)
                {
                    bGradeCheckB = false;
                }
                else
                    bGradeCheckB = true;

            // Output the pass or fail message
            if (bGradeCheckA && bGradeCheckB)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n\r\nCongradulations! Both Grades are passing with scores of " + aGradeCheck[0] + " and " + aGradeCheck[1]);
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\n\r\nI am sorry but one grade is not passing with the scores of " + aGradeCheck[0] + " and " + aGradeCheck[1]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\nPress Any Key to Continue to the menu");
            Console.ReadKey();
            return;
        }
 
        // Problem	#2 – Logical	Operators:	Brunch	Bunch
        static void OperationBrunchBunch()
        {
            // Variable Declaration
            int iAgeCheck;
            string sAgeCheck;
            bool bFlag = false;

            // Input and validation for age of diner
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease enter the age of the diner: ");
            sAgeCheck = Console.ReadLine();
            bFlag = int.TryParse(sAgeCheck, out iAgeCheck);
            while (!bFlag)
            {
                Console.Write("Please enter a valid age of the diner: ");
                sAgeCheck = Console.ReadLine();
                bFlag = int.TryParse(sAgeCheck, out iAgeCheck);
            }
            if (iAgeCheck < 10)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\r\nYour cost for brunch today is: $10.00");
            }
            else if (iAgeCheck > 55)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\nYour cost for brunch today is: $10.00");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\r\nYour cost for brunch today is: $15.00");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\nPress any key to return to the menu");
            Console.ReadKey(); 
        }

        // Problem	#3 – For	Loop:	Add	Them	Up
        static void AddThemUp()
        {
            // Variable Declaration
            int[] iMoviesOwned = new int[3];
            int iTotalCount;
            string sMovieType;
            bool bFlag = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Enter the number of DVDs you own: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sMovieType = Console.ReadLine();
            bFlag = int.TryParse(sMovieType, out iMoviesOwned[0]);
            while ((!bFlag) || (iMoviesOwned[0] <= 0))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please Enter the number of DVDs you own greater than 0: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sMovieType = Console.ReadLine();
                bFlag = int.TryParse(sMovieType, out iMoviesOwned[0]);
            }
            bFlag = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Enter the number of BlueRay you own: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sMovieType = Console.ReadLine();
            bFlag = int.TryParse(sMovieType, out iMoviesOwned[1]);
            while ((!bFlag) || (iMoviesOwned[1] <= 0))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please Enter the number of BlueRay you own greater than 0: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                sMovieType = Console.ReadLine();
                bFlag = int.TryParse(sMovieType, out iMoviesOwned[1]);
            }
            bFlag = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease Enter the number of UltraViolet you own: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            sMovieType = Console.ReadLine();
            bFlag = int.TryParse(sMovieType, out iMoviesOwned[2]);
            while ((!bFlag) || (iMoviesOwned[2] <= 0))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please Enter the number of UltraViolet you own greater than 0: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                sMovieType = Console.ReadLine();
                bFlag = int.TryParse(sMovieType, out iMoviesOwned[2]);
            }
            iTotalCount = (iMoviesOwned[0] + iMoviesOwned[1] + iMoviesOwned[2]);
            if (iTotalCount <= 100)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\r\nYou have total of " + iTotalCount + " Movies in your Collection.");

            } else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\r\nWhat an Impressive collection! You have total of " + iTotalCount + " Movies.");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nPress any Key to Return to the Menu");
            Console.ReadKey();
            return;
        }
 
        // Problem	#4 – While	Loop:	Cha-Ching!
        static void ChaChing()
        {
            // Variable Declaration
            bool bFlag = false;
            decimal dCardAmount;
            decimal dPurchaseAmount;
            string sCardAmount;
            string sPurchaseAmount;
            int iPurchaseCounter = 0;

            // Input card value and validate
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r\nPlease enter the amount of the gift card: $");
            Console.ForegroundColor = ConsoleColor.Cyan;
            sCardAmount = Console.ReadLine();
            bFlag = decimal.TryParse(sCardAmount, out dCardAmount);
            while (!bFlag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the amount of the gift card greater than 0: $");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sCardAmount = Console.ReadLine();
                bFlag = decimal.TryParse(sCardAmount, out dCardAmount);
            }
    
            // Keep running total of purchases until card is < 0, then output total due
            do
            {
                iPurchaseCounter++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the amount of purchase: " + iPurchaseCounter + ": $");
                Console.ForegroundColor = ConsoleColor.Cyan;
                sPurchaseAmount = Console.ReadLine();
                bFlag = decimal.TryParse(sPurchaseAmount, out dPurchaseAmount);
                while ((!bFlag) || (dPurchaseAmount <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Please enter the amount of item purchase greater than 0: $");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    sPurchaseAmount = Console.ReadLine();
                    bFlag = decimal.TryParse(sPurchaseAmount, out dPurchaseAmount);
                }
                
                dCardAmount = dCardAmount - dPurchaseAmount;
                if (dCardAmount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\r\nPurchase " + iPurchaseCounter + " is $" + dPurchaseAmount + ". You have $" + dCardAmount + " left");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\r\nPurchase " + iPurchaseCounter + " is $" + dPurchaseAmount + ". You have nothing left on the card.");
                    Console.WriteLine("\r\nYou have a remainder of $" + (dCardAmount * -1) + " to finish this last purchase.");
                }
            }
            while (dCardAmount >= 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\nPress any key to return to the menu:");
            Console.ReadKey();
            return;
        }
        static void ProgramStop()
        {
           // exit program 
        }
    }
}
/* Output for Problem 1
 * 
Please enter the first grade to evaluate in numbers: 95
Please enter the second grade to evaluate in numbers: 85


Congradulations! Both Grades are passing with scores of 95 and 85

Please enter the first grade to evaluate in numbers: 82
Please enter the second grade to evaluate in numbers: 68


I am sorry but one grade is not passing with the scores of 82 and 68


Please enter the first grade to evaluate in numbers: eighty

Please enter a vaid number for your First grade to evaluate greater than 0: 80
Please enter the second grade to evaluate in numbers: 91


Congradulations! Both Grades are passing with scores of 80 and 91

Please enter the first grade to evaluate in numbers: ten

Please enter a vaid number for your First grade to evaluate greater than 0: 75
Please enter the second grade to evaluate in numbers: nine

Please enter a vaid number for your Second grade to evaluate greater than 0: 85


Congradulations! Both Grades are passing with scores of 75 and 85

*/

/* Output for Problem 2
 * Pleae enter the age of the diner: 57

Your cost for brunch today is: $10.00

Pleae enter the age of the diner: 39

Your cost for brunch today is: $15.00

Pleae enter the age of the diner: 8

Your cost for brunch today is: $10.00

Pleae enter the age of the diner: 10

Your cost for brunch today is: $15.00

Pleae enter the age of the diner:
Pleae enter a valid age of the diner: a
Pleae enter a valid age of the diner: 65

Your cost for brunch today is: $10.00
*/
/* Output for Problem 3
 * Please Enter the number of DVDs you own: 45

Please Enter the number of BlueRay you own: 15

Please Enter the number of UltraViolet you own: 2

You have total of 62 Movies in your Collection.

Please Enter the number of DVDs you own: 60

Please Enter the number of BlueRay you own: 75

Please Enter the number of UltraViolet you own: 45

What an Impressive collection! You have total of 180 Movies.

Please Enter the number of DVDs you own:
Please Enter the number of DVDs you own greater than 0: 27

Please Enter the number of BlueRay you own:
Please Enter the number of BlueRay you own greater than 0: 39

Please Enter the number of UltraViolet you own:
Please Enter the number of UltraViolet you own greater than 0: 55

What an Impressive collection! You have total of 121 Movies.
*/
/* Output for Problem 4
 * Please enter the amount of the gift card: $30
Please enter the amount of purchase: 1: $5

Purchase 1 is $5. You have $25 left
Please enter the amount of purchase: 2: $10.50

Purchase 2 is $10.50. You have $14.50 left
Please enter the amount of purchase: 3: $16

Purchase 3 is $16. You have nothing left on the card.

You have a remainder of $1.50 to finish this last purchase.

Please enter the amount of the gift card: $
Please enter the amount of the gift card greater than 0: $100
Please enter the amount of purchase: 1: $
Please enter the amount of item purchase greater than 0: $22.50

Purchase 1 is $22.50. You have $77.50 left
Please enter the amount of purchase: 2: $15.75

Purchase 2 is $15.75. You have $61.75 left
Please enter the amount of purchase: 3: $22.99

Purchase 3 is $22.99. You have $38.76 left
Please enter the amount of purchase: 4: $20

Purchase 4 is $20. You have $18.76 left
Please enter the amount of purchase: 5: $20

Purchase 5 is $20. You have nothing left on the card.

You have a remainder of $1.24 to finish this last purchase.

*/


