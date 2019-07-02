//  NAME:  Edward Welborn
//  DATE:  10/01/2018
//  SDI    MDV2330-O
//         C20181002
//  Find and fix the errors assignment
//  Fourth Program For SDI / Week 2 
//  The things below need fixed since I have learned alot since that class. 

// TO DO
// Change colors

using System;

namespace FindErrorsCondLoops
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Create a number variable to hold the converted value
            int userGuess;
            bool bFlag = false;

            //Name the program
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\nHello and welcome to the number guessing game!");
            Console.ForegroundColor = ConsoleColor.Yellow;  
            Console.WriteLine("----------------------------------------------\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            //Explain directions
            Console.WriteLine("The first player will type in a whole number from 1 to 100.");
            Console.WriteLine("Afterwords, the second player will get 10 rounds to try to guess the number correctly.");
            Console.WriteLine("Each round the player will guess a number and then the computer will tell them if the secret number is higher or lower than that guess.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\nLet's go ahead and get started!\r\n");
            Console.ForegroundColor = ConsoleColor.White;   
            //Player 1 picks the number
            Console.Write("Player 1, please type in a whole number from 1 to 100 and press enter: ");

            //Catch the respnse
            Console.ForegroundColor = ConsoleColor.Cyan;
            string secretNumberString = Console.ReadLine();

            //Create a number variable to hold the whole number
            int secretNumber;
            bFlag = int.TryParse(secretNumberString, out secretNumber);
            //Validate that the number is a whole number AND between 1 and 100
            while (!(bFlag) || (secretNumber <= 1) && (secretNumber >= 100))
            {

                //Tell the user the problem
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nSorry, please only type in whole numbers and it must be between 1 and 100!");

                //Re-ask the question
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What is your secret number ? ");

                //Re-catch the response in the same variable
                Console.ForegroundColor = ConsoleColor.Cyan;
                secretNumberString = Console.ReadLine();
                bFlag = int.TryParse(secretNumberString, out secretNumber);
            }

            //Confirm the secret number
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\nGot it!\r\nThe secret number is " + secretNumber + ".");
            //Directions
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nWe will now clear the screen and then the second player can start guessing.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\nPress any key to start the game!");

            //This code will pause the console and wait for any key press
            Console.ReadKey();

            //This code will clear the console
            Console.Clear();

            //Greet player 2
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nGreetings Player 2!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\n\r\nPlayer 1 picked a secret number between 1 and 100 that you will have to guess in a maximum of 10 rounds!");
            Console.WriteLine("Each round I will tell you if the secret number is higher or lower than your guess.");
            Console.WriteLine("\r\nLet's get started!\r\n");

            //Create variable to hold round number
            int roundNumber = 1;

            //Create a while loop
            //This loop will run for 10 rounds or until the number is guessed.
            while (roundNumber <= 10)
            {

                //Prompt user for guess
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What is your guess for Round #" + roundNumber + "? ");

                //Catch the response
                Console.ForegroundColor = ConsoleColor.Cyan;
                string userGuessString = Console.ReadLine();
                bFlag = Int32.TryParse(userGuessString, out userGuess);

                //Validation Loop
                while (!(bFlag) || (userGuess <= 1) && (userGuess >= 100))
                {
                    //Tell the user the problem
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, please only type in whole numbers and it must be between 1 and 100!");

                    //Re-ask the question
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("What is your guess? ");

                    //Re-catch the response in the same variable
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    userGuessString = Console.ReadLine();
                    bFlag = Int32.TryParse(userGuessString, out userGuess);
                }

                //Conditional block to see if the users guess is too high, too low or correct!
                if (userGuess == secretNumber)
                {
                    //They got it right!  Stop the loop
                    //Break out of the while loop
                    break;

                }
                else if (userGuess < secretNumber)
                {
                    //Tell the user that their guess it too low
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\r\nYour guess is too LOW!");
                }
                else
                {
                    //Tell the user that their guess is too high
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\r\nYour guess is too HIGH!");
                }
                //Increase the round number variable
                roundNumber++;
            }

            //Test to see what round they ended on
            if (roundNumber > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nSorry you are out of turns!\r\nThe secret number was " + secretNumber);
            }
            else
            {
                //Congratulae the user
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\r\nCongratulations!  You guessed the secret number on Round #" + roundNumber + "!\r\n\r\nYou Win!");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\nPress any Key to continue");
            Console.ReadKey();
        }
    }
}

/*  Output test data
 *  Hello and welcome to the number guessing game!
    ----------------------------------------------

    The first player will type in a whole number from 1 to 100.
    Then the second player will get 10 rounds to try to guess the number correctly.
    Each round the player will guess a number and then the computer will tell them if the secret number is higher or lower than that guess.

    Let's go ahead and get started!

    Player 1, please type in a whole number from 1 to 100 and press enter: 80


    Got it!
    The secret number is 80.

    We will now clear the screen and then the second player can start guessing.

    Press any key to start the game!

    Greetings Player 2!

    Player 1 picked a secret number between 1 and 100 that you will have to guess in a maximum of 10 rounds!
    Each round I will tell you if the secret number is higher or lower than your guess.

    Let's get started!

    What is your guess for Round #1? 40

    Your guess is too LOW!
    What is your guess for Round #2? 50

    Your guess is too LOW!
    What is your guess for Round #3? 60

    Your guess is too LOW!
    What is your guess for Round #4? 70

    Your guess is too LOW!
    What is your guess for Round #5? 90

    Your guess is too HIGH!
    What is your guess for Round #6? 80

    Congratulations!  You guessed the secret number on Round #6!

    You Win!

    Press any Key to continue

*/

/* Hello and welcome to the number guessing game!
----------------------------------------------

The first player will type in a whole number from 1 to 100.
Then the second player will get 10 rounds to try to guess the number correctly.
Each round the player will guess a number and then the computer will tell them if the secret number is higher or lower than that guess.

Let's go ahead and get started!

Player 1, please type in a whole number from 1 to 100 and press enter: 90

Got it!
The secret number is 90.

We will now clear the screen and then the second player can start guessing.

Press any key to start the game!

Greetings Player 2!

Player 1 picked a secret number between 1 and 100 that you will have to guess in a maximum of 10 rounds!
Each round I will tell you if the secret number is higher or lower than your guess.

Let's get started!

What is your guess for Round #1? 10

Your guess is too LOW!
What is your guess for Round #2? 20

Your guess is too LOW!
What is your guess for Round #3? 30

Your guess is too LOW!
What is your guess for Round #4? 40

Your guess is too LOW!
What is your guess for Round #5? 50

Your guess is too LOW!
What is your guess for Round #6? 60

Your guess is too LOW!
What is your guess for Round #7? 70

Your guess is too LOW!
What is your guess for Round #8? 80

Your guess is too LOW!
What is your guess for Round #9? 10

Your guess is too LOW!
What is your guess for Round #10? 20

Your guess is too LOW!

Sorry you are out of turns!
The secret number was 90

Press any Key to continue
*/
