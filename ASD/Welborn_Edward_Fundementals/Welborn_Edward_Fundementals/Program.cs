using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_Fundementals
{
    class Program
    {
        static void Main(string[] args)
        {
            /*-------------------Terms to never use. -------------------------
            * Goto - Can lead to spaghetti code, and confusing linear coding
            * var - use specific data types such as int, bool, string
            * ----------------------------------------------------------------
            */
            //  Variable
            //  This of data types like a box, a box needs a name of what is in it.
            //  syntax for variable
            //  type (name);
                bool programRunning;
            //  name = value;
                programRunning = true;
            //  type name = value;
                bool programIsRunning = true;

            // Basic Operations
            // () do this first
            // Math Operations:
            // Multiplication and Divison
            // Subtraction and Addition
            // Modulus %
            // Integer Division
            /*
            int v1 = 2;
            int v2 = 4;
            int v3 = 10;

            int result = v1 + v2;
            // display the result
            Console.WriteLine($"The result of {v1} + {v2} = {result}");
            result = v2 - v1;
            Console.WriteLine($"The result of {v2} + {v1} = {result}");
            result = v1 * v2;
            Console.WriteLine($"The result of {v1} * {v2} = {result}");
            result = v3 / v1;
            Console.WriteLine($"The result of {v3} / {v1} = {result}");
            result = v1 + v2 * v3;
            Console.WriteLine($"The result of {v1} + {v2} * {v3}= {result}");
            result = (v1 + v2) * v3;
            Console.WriteLine($"The result of ({v1} + {v2}) * {v3} = {result}");
            result = v3 % v2;
            Console.WriteLine($"The result of {v3} % {v2} = {result}");
            result = v3 / v2;
            Console.WriteLine($"The result of {v3} / {v2} = {result}");

            // Compound operations;
            // *=
            // /=
            // +=
            // -=
            // variable = varialbe = 2;
            // variable += 2;
            float currentValue = 0;
            Console.WriteLine($"\r\nResult of {currentValue} += {2} is {currentValue += 2}");
            Console.WriteLine($"Result of {currentValue} -= {1} is {currentValue -= 1}");
            Console.WriteLine($"Result of {currentValue} *= {10} is {currentValue *= 10}");
            Console.WriteLine($"Result of {currentValue} /= {4} is {currentValue /= 4}");

            
            // Increment and decrement
            // variable ++; (pre-increment)
            // ++variable; (post-increment)
            // --variable; (pre-increment)
            // variable--; (post-increment)
            Console.WriteLine($"\r\nPre Increment ++variable of {currentValue} in a statement gives us the value of {++currentValue}");
            Console.WriteLine($"Post Increment variable++ of {currentValue} in a statement gives us the value of {currentValue++}");
            Console.WriteLine($"Pre Increment --variable of {currentValue} in a statement gives us the value of {--currentValue}");
            Console.WriteLine($"Post Increment variable-- of {currentValue} in a statement gives us the value of {currentValue--}");


            // Relational Operators
            // <,>, ==. >=, <=. !
            // This is cool I didn't know you couldn't do this.!!

            int leftValue = 10;
            int rightValue = 5;
            int anotherValue = 10;
            bool bTrue = true;
            Console.WriteLine($"{leftValue} > {rightValue} is {leftValue > rightValue}");
            Console.WriteLine($"{leftValue} < {rightValue} is {leftValue < rightValue}");
            Console.WriteLine($"{leftValue} >= {rightValue} is {leftValue >= rightValue}");
            Console.WriteLine($"{leftValue} <= {rightValue} is {leftValue <= rightValue}");
            Console.WriteLine($"{leftValue} == {anotherValue} is {leftValue == anotherValue}");
            Console.WriteLine($"!{bTrue} is {!bTrue}");

            // Input and Output
            // output -- Console.writeline, console.write, 
            // input - console.readkey, console.readline

            Console.WriteLine("This is a simple line of text to output.\n");
            Console.Write("Please enter your name: ");
            string inputUserName = Console.ReadLine();
            Console.WriteLine($"Hello, {inputUserName}\n");
            Console.Write("Please tell me how old you are (in years): ");
            string inputAge = Console.ReadLine();
            int age = Convert.ToInt32(inputAge);
            Console.WriteLine($"\r\n{inputUserName} is {age} years old!");

            // Arrays
            // int[] arrayOfInt;
            // arrayOfInt = new int{size};
            // arrayofInt = {1,2,3,4,5,6,7,8};
            //
            // Multidimensional Array
            // int[,] multiArrayOfInt = new int{size_1, size_2};
            //
            // accessing
            // index, value placed inside of [] starts with 0
            // arrayOfInt.Length returns amount of items -1
            // arrayOfInt[2] == 3;
            string[] names;
            names = new string[3];
            Console.WriteLine("Please Enter 3 Items:\n");
            Console.Write("Enter name 1: ");
            names[0] = Console.ReadLine();
            Console.Write("Enter name 2: ");
            names[1] = Console.ReadLine();
            Console.Write("Enter name 3: ");
            names[2] = Console.ReadLine();

            Console.WriteLine($"\r\nName 1 is {names[0]}");
            Console.WriteLine($"Name 2 is {names[1]}");
            Console.WriteLine($"Name 3 is {names[2]}");

            names[1] = "Fred";

            Console.WriteLine($"Name 2 is now {names[1]}\r\n");
            
            // Conditionals
            //
            // If (Statement) this runs if true
            //
            // if (statement)
            // {
            // 
            // }
            //
            // if (statement)
            //{
            // this runs if true
            //}
            // else this runs if false
            //
            // if (statement)
            // {
            // 
            // } else if (statement)
            // {
            // } else
            //
            // switch (case)
            // {
            //   case 1:
            //     {
            //      place code here;
            //      break;
            //  case 2:
            //      break;
            //  default
            //  {
            //    Place code here;
            //    break;
            //  }
            // }

            Console.Write("Enter a number between 1 and 100: ");
            string inputNumber = Console.ReadLine();
            int userChoice = Convert.ToInt32(inputNumber);
            if (userChoice == 42)
            {
                Console.WriteLine("The answer to life the universe and everything!\n\n");
            }
            else if (userChoice == 7)
            {
                Console.WriteLine("This seems like a pretty good number:\n\n ");
            }
            else
            {
                Console.WriteLine("You feel like there are other number that are more important!");
            }
            
            // Logical Operators
            //
            // and - &&
            // or - ||
            // not - !
            // grouping - ()

            // Hide everything before...
            Console.Clear();

            Console.Write("Enter a number between 1 and 100: ");
            string userInput = Console.ReadLine();
            int userChoice = Convert.ToInt32(userInput);
            if ((userChoice > 0) && (userChoice < 101))
            {
                Console.WriteLine("\r\nYou have selected a value in the desired range: ");
            }
            else Console.WriteLine("\r\nYour choice was out of bounds:");
            */

            // Loops
            // int i;
            /* for (int i = 0; i > 10; ++i)
             {

             }
             programRunning = true;

             while(programRunning)
             {

                 programRunning = false;
             }

             do
             {

             } while (programRunning);

             int[] newArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
             foreach (int currentValue in newArray)
             {
                 Console.WriteLine($"The current value of the newArray is {currentValue}");
             }
            

            string[] userFirstNames = new string[5];
            string[] userLastNames = new string[5];

            Console.WriteLine("Please Enter firstname for user 1: ");
            userFirstNames[0] = Console.ReadLine();
            Console.WriteLine("Please Enter lastname for user 1: ");
            userLastNames[0] = Console.ReadLine();
            Console.WriteLine("Please Enter firstname for user 2: ");
            userFirstNames[1] = Console.ReadLine();
            Console.WriteLine("Please Enter lastname for user 2: ");
            userLastNames[1] = Console.ReadLine();
            Console.WriteLine("Please Enter firstname for user 3: ");
            userFirstNames[2] = Console.ReadLine();
            Console.WriteLine("Please Enter lastname for user 3: ");
            userLastNames[2] = Console.ReadLine();
            Console.WriteLine("Please Enter firstname for user 4: ");
            userFirstNames[3] = Console.ReadLine();
            Console.WriteLine("Please Enter lastname for user 4: ");
            userLastNames[3] = Console.ReadLine();
            Console.WriteLine("Please Enter firstname for user 5: ");
            userFirstNames[4] = Console.ReadLine();
            Console.WriteLine("Please Enter lastname for user 5: ");
            userLastNames[4] = Console.ReadLine();

            Console.WriteLine("\r\nList of Users\r\n");
            for (int userIndex = 0; userIndex < userFirstNames.Length; ++userIndex)
            {
                Console.WriteLine($"{userIndex}: {userFirstNames[userIndex]} {userLastNames[userIndex]}");
            }
            */

            //// Methods and fuctions
            DisplayMessage("Hello World");

            int userChoice = GetInt();
            Console.WriteLine($"The User Entered a Valid Integer: {userChoice}");
            
            
            // adding press any key to continue
            Console.WriteLine("\r\nPress any key to continue");
            Console.ReadKey();


        }
        // new method
        // return type: void
        // MethodName: DisplayMessage
        // parameters: string

        static void DisplayMessage(string sMessage)
        {
            Console.WriteLine(sMessage);
        }

        // new method
        // return type: int
        // MethodName: GetInt
        // parameters: int
        static int GetInt()
        {
            int iValidateInt;
            string sInput = null;
            do
            {
                Console.Write("Please Enter and Integer: ");
                sInput = Console.ReadLine();

            } while (Int32.TryParse(sInput, out iValidateInt) == false);
            return iValidateInt;
        }
    }
}
