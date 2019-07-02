// ​Name:​ Edward Welborn
// ​Date:​ 1812
// ​Course:​ Project & Portfolio 1
// ​Synopsis:​ This coding project is a series of challenges that the user can choose, and test
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVP1.CE1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sUserChoice = "";
            int iMenu;
            // Opening Menu, user will choose challenge to run
            do
            {
                Console.Clear();
                Console.WriteLine("                  Project and Portfolio 1");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("\r\n               Code Challenges Menu:");
                Console.WriteLine("Please enter the number for the challenge you want to run..");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\r\n");
                Console.WriteLine("1  Swap Name");
                Console.WriteLine("2  Backwords");
                Console.WriteLine("3  Age Convert");
                Console.WriteLine("4  Tempurature Convert");
                Console.WriteLine("5  Big Blue Fish");
                Console.WriteLine("\r\n6  Exit Program");
                Console.Write("\r\nPlease enter your choice: ");
                sUserChoice = Console.ReadLine();
                iMenu = Convert.ToInt32(sUserChoice);
                if (string.IsNullOrWhiteSpace(sUserChoice) && (iMenu <= 1) && (iMenu >= 6))
                {
                    Console.Write("\r\nPlease Enter your choice between 1 and 6: ");
                    sUserChoice = Console.ReadLine();
                    iMenu = Convert.ToInt32(sUserChoice);
                }

                if (iMenu == 1)
                {
                    string sFirstName = "";
                    string sLastName = "";
                    string sNewName = "";
                    // Swapname Challenge, user will input firsname, and last name, program will swap to
                    // to lastname then firstname
                    SwapName nameswap = new SwapName();
                    sNewName = NameSwap(sFirstName, sLastName);
                    Console.WriteLine("Your Swapped Name is now: " + sNewName);
                    break;
                }
                if (iMenu == 2)
                {

                    break;
                }
                if (iMenu == 3)
                {

                    break;
                }
                if (iMenu == 6)
                {
                    ProgramStop();
                    break;
                }
            }
            while (iMenu != 6);
        }
    }
    public static void ProgramStop();
        {
            Console.WriteLine("Press Any Key to Exit");
            console.readkey();
        }
}
