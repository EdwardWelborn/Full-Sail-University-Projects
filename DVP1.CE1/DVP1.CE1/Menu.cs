// ​Name:​ Edward Welborn
// ​Date:​ 1812
// ​Course:​ Project & Portfolio 1
// ​Synopsis:​ This coding project is a series of challenges that the user can choose, and test
// This is the main menu for the Challenges programs.  Depending on user input will execute the
// coresponding class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVP1.CE1
{
    class Menu
    {
        public Menu()
        {
            // Main Menu for the Challenges program
        }
        public static void MainMenu()
        {
            string sUserChoice = "";
            int iMenu;
            bool bValidMenu;
            // Opening Menu, user will choose challenge to run
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\n\r\n                  Project and Portfolio 1");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                   Code Challenges Menu:");
                Console.WriteLine("Please enter the number for the challenge you want to run..");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\r\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<1>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Swap Name");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<2>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Backwords");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<3>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Age Convert");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<4>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Tempurature Convert");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<5>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Big Blue Fish");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\r\n<6>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Exit Program");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\r\nPlease enter your choice between ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1 ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("and ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("6: ");
                Console.ForegroundColor = ConsoleColor.White;
                sUserChoice = Console.ReadLine();
                bValidMenu = int.TryParse(sUserChoice, out iMenu);
                if (bValidMenu && (iMenu <= 1) && (iMenu >= 6))
                {
                    Console.Write("\r\nPlease enter your choice between ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1 ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("and ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("6: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    sUserChoice = Console.ReadLine();
                    bValidMenu = int.TryParse(sUserChoice, out iMenu);
                }

                if (iMenu == 1)
                {
                    // Swapname Challenge, user will input firsname, and last name, program will swap to
                    // to lastname then firstname
                    SwapName nameswap = new SwapName();
                    SwapName.NameSwap();

                    
                }
                if (iMenu == 2)
                {
                    // Backwords, input a string and reverse it.
                    Backwords reverseString = new Backwords();
                    Backwords.ReverseInput();
 
                }
                if (iMenu == 3)
                {
                    // Age Convert, Convert age from years, to days, hours, minutes and seconds.
                    AgeConvert ageConvert = new AgeConvert();
                    AgeConvert.HowOldAmI();

                }
                if (iMenu == 4)
                {
                    // Tempurature Conversion
                    TempConvert tempConvert = new TempConvert();
                    TempConvert.TempuratureConvert();
                    
                }
                if (iMenu == 5)
                {
                    // Big Blue Fish
                    BigBlueFish bigBlueFish = new BigBlueFish();
                    BigBlueFish.FishyFish();
                }
                if (iMenu == 6)
                {
                    ProgramStop();
                    break;                   
                }
            }
            while (iMenu != 6);
        }
        public static void ProgramStop()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n                                              =-=-=-=-=-=-=-=-=-=-=");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                              Thank you for Playing");
            Console.WriteLine("\r\n                                              Press Any Key to Exit");
            Console.Write("\r\n                                                    GOODBYE!!");
            Console.ReadKey();
        }
    }
}
