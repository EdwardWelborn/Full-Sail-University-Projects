// Edward Welborn
// Methods Assignment
// SDI - MDV2330-O
//       C20181002
// 10/09/2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            int iMenu;
            string sUserChoice;
            decimal dCurrencyReturn;
            decimal dEuros;
            decimal dAstroWeight;
            decimal dWeight;
            int iPlanet;
            string sPlanet = null;
            string sPlanetChoice = null;
            string sEuros = null;
            string sWeight = null;
            // Array Used for First Test
            int[] aFirstArray = new int[] {4, 65, 32, 42, 12};
            int[] aSecondArray = new int[] { 1, 2, 5, 6, 9 };
            // Array used for second test
            // int[] aFirstArray = new int[] { 54, 125, 96, 72, 45, 67 };
            // int[] aSecondArray = new int[] { 87, 122, 145, 65, 3, 800 };
            // Array used for Third test
            // int[] aFirstArray = new int[] { 12, 18, 27, 39, 53, 72 };
            // int[] aSecondArray = new int[] { 87, 99, 163, 192, 210, 276 };
            int[] aTotalsArray = new int[aFirstArray.Length];
            do
            {
                // Main Menu
                Console.Clear();
                Console.WriteLine("Methods Assignment");
                Console.WriteLine("-----------------------\r\n");
                Console.WriteLine("1  Currency Convertor");
                Console.WriteLine("2  Astronomical Weight");
                Console.WriteLine("3  Subtraction");
                Console.WriteLine("4  Exit Program");
                Console.Write("\r\nPlease enter your choice: ");
                sUserChoice = Console.ReadLine();

                if ((!int.TryParse(sUserChoice, out iMenu)) && (iMenu <= 1) && (iMenu >= 4))
                {
                    Console.Write("\r\nPlease Enter your choice between 1 and 4: ");
                    sUserChoice = Console.ReadLine();
                    iMenu = Convert.ToInt32(sUserChoice);
                }
                // Console.Clear();

                if (iMenu == 1) // Currency Convertor Method
                {
                    Console.Clear();
                    Console.WriteLine("Currency Convertor:");
                    Console.WriteLine("-------------------");
                    Console.Write("\r\nPlease Enter the amount of Euros you would like converted to American Dollar: ");
                    sEuros = Console.ReadLine();
                    while ((!decimal.TryParse(sEuros, out dEuros)) || (dEuros < 1))
                    {
                        Console.Write("\r\nPlease Enter the amount of Euros you would like converted to American Dollar: ");
                        sEuros = Console.ReadLine();
                    }
                    dCurrencyReturn =  CurrencyConvertor(dEuros);
                    Console.WriteLine("After converion of " + dEuros.ToString("C2") + " Euro, You will have " + dCurrencyReturn.ToString("C2") + " American Dollars left.");
                    Console.WriteLine("\r\nPress any key to return to the main menu:");
                    Console.ReadKey();
                }
                if (iMenu == 2) // Astronomical Weight Calculator Method
                {
                    Console.Clear();
                    Console.WriteLine("Astronomical Weight Conversion:");
                    Console.WriteLine("------------------------------");
                    Console.Write("\r\nPlease Enter the your weight in pounds: ");
                    sWeight = Console.ReadLine();
                    while ((!decimal.TryParse(sWeight, out dWeight)) || (dWeight < 1))
                    {
                        Console.Write("\r\nPlease Enter the your weight in pounds greater than 0: ");
                        sWeight = Console.ReadLine();
                    }
                    
                    Console.WriteLine("\r\nPlease Choose the planet number below:(number only)" );
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("\r\n1.. Mercury:");
                    Console.WriteLine("2.. Venus");
                    Console.WriteLine("3.. Earth");
                    Console.WriteLine("4.. Mars");
                    Console.WriteLine("5.. Jupiter");
                    Console.WriteLine("6.. Saturn");
                    Console.WriteLine("7.. Uranus");
                    Console.WriteLine("8.. Neptune");
                    Console.Write("\r\n Please Enter the Planet: ");
                    sPlanetChoice = Console.ReadLine();
                   
                    while ((!int.TryParse(sPlanetChoice, out iPlanet)) || ((iPlanet < 1) || (iPlanet > 8)))
                    {
                        Console.Write("\r\nPlease Enter the Planet: (Choose a number Between 1 and 8) ");
                        sPlanetChoice = Console.ReadLine();
                    }
                    
                    if (iPlanet == 1)
                    {
                        sPlanet = "Mercury";
                    }
                    else if (iPlanet == 2)
                    {
                        sPlanet = "Venus";
                    }
                    else if (iPlanet == 3)
                    {
                        sPlanet = "Earth";
                    }
                    else if (iPlanet == 4)
                    {
                        sPlanet = "Mars";
                    }
                    else if (iPlanet == 5)
                    {
                        sPlanet = "Jupiter";
                    }
                    else if (iPlanet == 6)
                    {
                        sPlanet = "Saturn";
                    }
                    else if (iPlanet == 7)
                    {
                        sPlanet = "Neptune";
                    }
                    else if (iPlanet == 8)
                    {
                        sPlanet = "Uranus";
                    }
                    
                    dAstroWeight = AstronomicalWeight(dWeight, iPlanet);
                        
                    Console.WriteLine("\r\nOn Earth you would weigh " + dWeight + " pounds, but if you lived on " + sPlanet + " you would weigh: " + dAstroWeight + " pounds");
                    Console.WriteLine("\r\nPress any key to return to the main menu:");
                    Console.ReadKey();
                    
                }
                if (iMenu == 3) // Subtraction Method
                {
                    Console.Clear(); 

                    for (int iCounter = 0; iCounter < aFirstArray.Length; iCounter++)
                    { 
                        aTotalsArray[iCounter] = Subtraction(aFirstArray[iCounter], aSecondArray[iCounter]);
                        Console.WriteLine(aFirstArray[iCounter] + " - " + aSecondArray[iCounter] + " = " + aTotalsArray[iCounter]);
                    }
                    
                    Console.WriteLine("\r\nPress any key to return to main menu");
                    Console.ReadKey();
                }
                if (iMenu == 4) // Program Exit Method
                {
                    ProgramExit();
                    break;
                }
            }
            while (iMenu != 4);
        }
        public static decimal CurrencyConvertor(decimal dEuros)
        {
            // Variable Declaration
            decimal dCurrencyReturn;
           
            // Calculate euros to dollars 
            Console.WriteLine("\r\nConverting " + dEuros.ToString("C2") + " Euro To American Dollars:");
            dCurrencyReturn = (dEuros * 1.16M);
            return dCurrencyReturn;
        }
        public static decimal AstronomicalWeight(decimal dWeight, int iPlanet)
        {
            // Calculate weight on different planets
            if (iPlanet == 1)
            {
                dWeight = (dWeight * 38) / 100;
            } else if (iPlanet == 2)
            {
                dWeight = (dWeight * 91) / 100;
            } else if (iPlanet == 3)
            {
                dWeight = (dWeight * 1);
            } else if (iPlanet == 4)
            {
                dWeight = (dWeight * 38) / 100;
            } else if (iPlanet == 5)
            {
                dWeight = (dWeight * 234) / 100;
            } else if (iPlanet == 6)
            {
                dWeight = (dWeight * 93) / 100;
            } else if (iPlanet == 7)
            {
                dWeight = (dWeight * 92) / 100;
            } else if (iPlanet == 8)
            {
                dWeight = (dWeight * 112) / 100;
            }
            return dWeight;
        }
        public static int Subtraction(int aFirstArray, int aSecondArray)
        {
            // Calculate 1st array minus second array, return the third array number
            int aTotalsArray;
            
            aTotalsArray = aFirstArray - aSecondArray;

            return aTotalsArray;
        }
        private static void ProgramExit()
        {
            // Program Exit
        }
    }
}
/* Test Output 1 for Currency Convertor
 * Currency Convertor:
-------------------

Please Enter the amount of Euros you would like converted to American Dollar: 5.50

Converting $5.50 Euro To American Dollars:
After converion of $5.50 Euro, You will have $6.38 American Dollars left.

Press any key to return to the main menu:
*/
/* Test Output 2 for currencty convertor
 *
Currency Convertor:
-------------------

Please Enter the amount of Euros you would like converted to American Dollar: 15.32

Converting $15.32 Euro To American Dollars:
After converion of $15.32 Euro, You will have $17.77 American Dollars left.
*/
/* Test Output 3 currency convertor
 * Currency Convertor:
-------------------

Please Enter the amount of Euros you would like converted to American Dollar:

Please Enter the amount of Euros you would like converted to American Dollar:

Please Enter the amount of Euros you would like converted to American Dollar: 250.00

Converting $250.00 Euro To American Dollars:
After converion of $250.00 Euro, You will have $290.00 American Dollars left.

 */
/* Test Output 1 for Astronomical Weight Conversion
 * Astronomical Weight Conversion:
------------------------------

Please Enter the your weight in pounds: 160

Please Choose the planet number below:(number only)
--------------------------------------

1.. Mercury:
2.. Venus
3.. Earth
4.. Mars
5.. Jupiter
6.. Saturn
7.. Uranus
8.. Neptune

 Please Enter the Planet: 6

On Earth you would weigh 160 pounds, but if you lived on Saturn you would weigh: 148.8 pounds
 */
/* Test Output 2 for Astronomical Weight Conversion
 *Astronomical Weight Conversion:
------------------------------

Please Enter the your weight in pounds: 210

Please Choose the planet number below:(number only)
--------------------------------------

1.. Mercury:
2.. Venus
3.. Earth
4.. Mars
5.. Jupiter
6.. Saturn
7.. Uranus
8.. Neptune

Please Enter the Planet: 9

Please Enter the Planet: (Choose a number Between 1 and 8) 5

On Earth you would weigh 210 pounds, but if you lived on Jupiter you would weigh: 491.4 pounds

 */
/* Test Output 3 for Astronomical Weight Conversion
 * Astronomical Weight Conversion:
------------------------------

Please Enter the your weight in pounds: 200

Please Choose the planet number below:(number only)
--------------------------------------

1.. Mercury:
2.. Venus
3.. Earth
4.. Mars
5.. Jupiter
6.. Saturn
7.. Uranus
8.. Neptune

Please Enter the Planet:

Please Enter the Planet: (Choose a number Between 1 and 8) 8

On Earth you would weigh 200 pounds, but if you lived on Uranus you would weigh: 224 pounds
*/


/* Test Output 1 for Subtraction
 * 4 - 1 = 3
65 - 2 = 63
32 - 5 = 27
42 - 6 = 36
12 - 9 = 3
 * 
*/
/* Test Output 2 for Subtraction
54 - 87 = -33
125 - 122 = 3
96 - 145 = -49
72 - 65 = 7
45 - 3 = 42
67 - 800 = -733
 */

/* Test output 3 for subtraction
12 - 87 = -75
18 - 99 = -81
27 - 163 = -136
39 - 192 = -153
53 - 210 = -157
72 - 276 = -204
 */




