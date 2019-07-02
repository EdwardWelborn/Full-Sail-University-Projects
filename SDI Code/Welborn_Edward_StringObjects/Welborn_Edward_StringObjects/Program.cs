// Edward Welborn
// String Objects Assignment
// SDI - MDV2330-O
//       C20181002
// 10/12/2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_StringObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            string sUserChoice = null;
            int iMenu = 0;
            string sNewList = null;
            char[] aMoneyArray = new char[] { };
            string[] aRedactionLine = new string[] { };
            string sMoneyInput = null;
            bool bMoneyCheck = false;
            string sRedactString = null;
            char[] cRedactedList = new char[] { };
 
            do
            {
                // Main Menu
                Console.Clear();
                Console.WriteLine("StringObjects Assignment");
                Console.WriteLine("------------------------\r\n");
                Console.WriteLine("1  Money Troubles");
                Console.WriteLine("2  Redacted");
                Console.WriteLine("3  Exit Program");
                Console.Write("\r\nPlease enter your choice: ");
                sUserChoice = Console.ReadLine();

                if ((!int.TryParse(sUserChoice, out iMenu)) && (iMenu < 1) && (iMenu > 3))
                {
                    Console.Write("\r\nPlease Enter your choice between 1 and 4: ");
                    sUserChoice = Console.ReadLine();
                    iMenu = Convert.ToInt32(sUserChoice);
                }
                // Console.Clear(); 

                if (iMenu == 1) // Money Troubles
                {
                    sMoneyInput = null;
                    bMoneyCheck = false;
                    Console.Clear();
                    Console.Write("Please input a proper dollar amount WITH $ and ., between 1 and 1000: ");
                    sMoneyInput = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(sMoneyInput))
                    {
                        Console.Write("\r\nPlease input a proper dollar amount WITH $ and ., between 1 and 1000:   ");
                        sMoneyInput = Console.ReadLine();
                        
                    }
                    bMoneyCheck = MoneyTroubles(sMoneyInput);
                    if (bMoneyCheck)
                    {
                        Console.WriteLine("\r\n" + sMoneyInput + " is Valid American Currency.");
                    }
                    else
                    {
                        Console.WriteLine("\r\n" + sMoneyInput + " is not Valid American Currency");
                    }
                    Console.WriteLine("\r\nPress any key to return to the main menu:");
                    Console.ReadKey();
                }
                if (iMenu == 2) // Redacted
                {
                    Console.Clear();
                    Console.Write("\r\n\r\nPlease Enter a Text statement to be redacted: ");
                    sRedactString = Console.ReadLine();
                    
                    while (string.IsNullOrWhiteSpace(sRedactString))
                    {
                        Console.Write("\r\nPlease Enter a Text statement to be redacted: ");
                        sRedactString = Console.ReadLine();
                    }
                    Console.WriteLine(" ");
                    sNewList = Redacted(sRedactString);
                    Console.WriteLine("The original string is: " + sRedactString + "\r\nThe Redacted Text is: " + sNewList);
                    Console.WriteLine("\r\nPress any key to return to the main menu:");
                    Console.ReadKey();
                }

                if (iMenu == 3) // Program Exit Method
                {
                    ProgramExit();
                    break;
                }
            } while (iMenu != 4);
        }
        public static bool MoneyTroubles(string sMoneyInput)  
        {
            // Variable Declaration
            
            bool bValidMoney = false;
            bool bCharCheck = false;
            bool bMoneyCheck = false;
            decimal dMoneyCheck = 0;
            int iMoneyIndexDollar = 0;
            int iMoneyIndexDot = 0;
            char cDollarChar = '$';
            char cDotChar = '.';
            string sMoneyCheck = null;

            bCharCheck = (sMoneyInput.Contains(cDollarChar) && sMoneyInput.Contains(cDotChar));

            if (bCharCheck)
            {
                iMoneyIndexDollar = sMoneyInput.IndexOf(cDollarChar);
                iMoneyIndexDot = sMoneyInput.IndexOf(cDotChar);
                if ((iMoneyIndexDollar == 0) && (iMoneyIndexDot == (sMoneyInput.Length - 3)))
                {
                    bValidMoney = true;
                }
            }
            sMoneyCheck = sMoneyInput.Substring(1, sMoneyInput.Length - 4);
            bMoneyCheck = decimal.TryParse(sMoneyCheck, out dMoneyCheck);
            if (!(bMoneyCheck) && (dMoneyCheck < 1) || (dMoneyCheck > 1000))
            {
                bValidMoney = false;
            }
            
           //  Console.WriteLine(bValidMoney);
            
            return bValidMoney;
        }
        public static string Redacted(string sRedactString)
        {
            // Variable Declaration
            string sNewList = null;
            char[] cRedactedList = new char[] { };
            // Loop through array.
            cRedactedList = (sRedactString.ToCharArray());
            for (int iCounter = 0; iCounter < cRedactedList.Length; iCounter++)
            {
                // Get character from array.
                char cletter = char.ToLower(cRedactedList[iCounter]);
                
                if (cRedactedList[iCounter] == 'a')
                {
                    cRedactedList[iCounter] = '-';
                } else if (cRedactedList[iCounter] == 'e')
                {
                    cRedactedList[iCounter] = '-';
                } else if (cRedactedList[iCounter] == 'i')
                {
                    cRedactedList[iCounter] = '-';
                } else if (cRedactedList[iCounter] == 'o')
                {
                    cRedactedList[iCounter] = '-';
                } else if (cRedactedList[iCounter] == 'u')
                {
                    cRedactedList[iCounter] = '-';
                } else if (cRedactedList[iCounter] == 'y')
                {
                    cRedactedList[iCounter] = '-';
                }
            }
            // Redacted Method

            return sNewList = new string(cRedactedList);

        }
        public static void ProgramExit()
        {
            // Exit program
        }
    }
}
/* Test output 1 for Money Troubles
 Please input a proper dollar amount WITH $ and ., between 1 and 1000: $5.25

$5.25 is Valid American Currency.

*/
/* Test output 2 for Money Troubles
 Please input a proper dollar amount WITH $ and ., between 1 and 1000: 27.00

27.00 is not Valid American Currency

Press any key to return to the main menu:

 */
/* Test Output 3 for Money Troubles
 Please input a proper dollar amount WITH $ and ., between 1 and 1000: $36799

$36799 is not Valid American Currency

Press any key to return to the main menu:
*/
/* Test Output 4 for Money Trouble
 Please input a proper dollar amount WITH $ and ., between 1 and 1000: $G3.75

$G3.75 is not Valid American Currency

*/
/* Test outut 5 for Money Troubles
 Please input a proper dollar amount WITH $ and ., between 1 and 1000: $1234.67

$1234.67 is not Valid American Currency

*/
/* Test Output 1 for Redacted 
 
Please Enter a Text statement to be redacted: Strings are fun

The original string is: Strings are fun
The Redacted Text is: Str-ngs -r- f-n

*/
/* Test output 2 for Redacted
 Please Enter a Text statement to be redacted: Can you read this? 
 The original string is: Can you read this? 
 The Redacted Text is: C-n --- r--d th-s?                                                                                                                          
*/

/* Test output 3 for Redacted
 Please Enter a Text statement to be redacted: This is a sentence that needs to be redacted, hopefully it will work

The original string is: This is a sentence that needs to be redacted, hopefully it will work
The Redacted Text is: Th-s -s - s-nt-nc- th-t n--ds t- b- r-d-ct-d, h-p-f-ll- -t w-ll w-rk

*/


