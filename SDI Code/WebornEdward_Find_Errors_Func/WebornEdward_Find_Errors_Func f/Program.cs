using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindErrorsFunctions
{
    class Program
    {
        static void Main(string[] args)
        {

            /* INSTRUCTIONS
              *  1. Find the Logical Errors
              *     - Logical errors will give you the wrong output.
              *     - These are a bit harder to find.  Keep checking the correct output given!
              *     - Follow any additional instructions given in the comments.
              *  2. Once you think you are done, check your output line by line against the 
              *     given correct output.
              *  3. If it matches perfectly, zip your whole project file and submit it to FSO.
              * */

            //In this program we will calculate the amount of money each slice will cost in a pizza.

            //Welcome the user
            Console.WriteLine("Hello and welcome to the Pizza Party Planner!");
            Console.WriteLine("We will try to figure out the cheapest way to get enough pizza for all the guests at a party.");
            Console.WriteLine("In order to do this, we will need a few pieces of information from you!\r\n");

            //Prompt the user for the number of guests that will be at the party
            Console.Write("How many people will be at your party? ");

            //Catch the users response
            string partyPeopleString = Console.ReadLine();

            //Create a variable to hold the converted value
            decimal partyPeople;

            //Validate and convert 
            while (!(decimal.TryParse(partyPeopleString, out partyPeople)))
            {
                //Tell the user the issue and re-ask the question
                Console.WriteLine("\r\nPlease only type in whole numbers.");
                Console.Write("\r\nHow many people will be at the party? ");

                //Re-catch the answer
                partyPeople = Convert.ToDecimal(Console.ReadLine());

            }

            //Confirm with the number of people
            Console.WriteLine("Got it! You are having {0} guests at your party\r\n", partyPeople);

            //Start gathering the pizza information
            Console.WriteLine("I now need some information about the pizza options.");
            Console.WriteLine("There are 2 sizes of pizzas that the store offers and each one has a different number of slices and a different price.");

            //Prompt for small pizza price
            Console.Write("\r\nWhat is the cost of a small pizza? ");
            //Catch the users response
            string smallPriceString = Console.ReadLine();

            //Create a variable to hold the converted value
            decimal smallPrice;

            //Validate and convert 
            while (!(decimal.TryParse(smallPriceString, out smallPrice)))
            {
                //Tell the user the issue and re-ask the question
                Console.WriteLine("\r\nPlease only type in numbers.");
                Console.Write("\r\nHow much is a small pizza? ");

                //Re-catch the answer
                smallPriceString = Console.ReadLine();

            }

            //Confirm and ask for the number of slices
            Console.Write("\r\nGot it, a small pizza costs {0}.\r\nHow many slices are in the small pizza? ", smallPrice.ToString("c"));

            //Catch the users response
            string smallSliceNumString = Console.ReadLine();

            //Create a variable to hold the converted value
            int smallSliceNum;

            //Validate and convert 
            while (!(int.TryParse(smallSliceNumString, out smallSliceNum)))
            {
                //Tell the user the issue and re-ask the question
                Console.WriteLine("\r\nPlease only type in whole numbers.");
                Console.Write("\r\nHow many slices are in a small pizza? ");

                //Re-catch the answer
                smallSliceNumString = Console.ReadLine();

            }


            //Function Call to figure out the cost per slice for a small pizza
            decimal costOfSliceSmall = CostPerSlice(smallPrice, smallSliceNum);

            //Confirm with the user
            Console.WriteLine("\r\nA small pizza costs {1} and contains {2} slices!\r\nSo one slice costs {2}!", smallPrice.ToString("c"), smallSliceNum, costOfSliceSmall.ToString("c"));

            //Now ask about the large pizza
            Console.Write("\r\nWhat is the cost of a large pizza? ");

            //Catch the users response
            string largePriceString = Console.ReadLine();

            //Create a variable to hold the converted value
            decimal largePrice;

            //Validate and convert 
            while (!(decimal.TryParse(largePriceString, out largePrice)))
            {
                //Tell the user the issue and re-ask the question
                Console.WriteLine("\r\nPlease only type in numbers.");
                Console.Write("\r\nHow much is a large pizza? ");

                //Re-catch the answer
                largePriceString = Console.ReadLine();

            }

            //Confirm and ask for the number of slices
            Console.Write("\r\nGot it, a large pizza costs {0}.\r\nHow many slices are in the large pizza? ", largePrice.ToString("c"));

            //Catch the users response
            string largeSliceNumString = Console.ReadLine();

            //Create a variable to hold the converted value
            decimal largeSliceNum;

            //Validate and convert 
            while (!(decimal.TryParse(largeSliceNumString, out largeSliceNum)))
            {
                //Tell the user the issue and re-ask the question
                Console.WriteLine("\r\nPlease only type in whole numbers.");
                Console.Write("\r\nHow many slices are in a large pizza? ");

                //Re-catch the answer
                largeSliceNumString = Console.ReadLine();

            }


            //Function Call to figure out the cost per slice for a large pizza
            decimal costOfSliceLarge = CostPerSlice(largePrice, largeSliceNum);

            //Confirm with the user
            Console.WriteLine("\r\nA large pizza costs {0} and contains {1} slices!\r\nSo one slice costs {2}!", largePrice.ToString("c"), largeSliceNum, costOfSliceLarge.ToString("c"));

            //Alert the user to the next step
            Console.WriteLine("\r\nWe will now figure out how many pizzas of each size you would need assuming each guest gets one slice of pizza.");

            //Function Call To Pizzas Needed
            decimal numSmallPizzas = NumPizzasNeeded(partyPeople, smallSliceNum, costOfSliceSmall);
            decimal numLargePizzas = NumPizzasNeeded(partyPeople, largeSliceNum, costOfSliceLarge);

            //Report to the user
            Console.WriteLine("\r\nYou would need to order {0} small pizzas or {1} large pizzas to feed {2} guests.", numSmallPizzas, numLargePizzas, partyPeople);

            //Function Call To figure out total price
            decimal costOfAllSmalls = TotalCost(smallPrice, numSmallPizzas);
            decimal costOfAllLarges = TotalCost(largePrice, numLargePizzas);
            
            //Condtional to figure out which is cheaper
            if (costOfAllLarges == costOfAllSmalls)
            {
                //Prices are the same.  User can get either
                Console.WriteLine("\r\nYou can buy either {0} small pizzas or {1} large pizzas.\r\nBoth will cost you {2}.", numSmallPizzas, numLargePizzas, costOfAllSmalls.ToString("c"));

            }
            else if (costOfAllSmalls < costOfAllLarges)
            {
                //Smalls are cheaper
                //Calculate difference
                decimal difference =  costOfAllLarges - costOfAllSmalls;
                //Final Results 
                Console.WriteLine("\r\nYou should buy {0} small pizzas for {1}.\r\nIf you bought large pizzas you would have spent {2} more.", numSmallPizzas, costOfAllSmalls.ToString("c"), difference.ToString("c"));


            }
            else if (costOfAllLarges < costOfAllSmalls)
            { 
                //Larges are cheaper
                //Calculate difference
                decimal difference = costOfAllSmalls - costOfAllLarges;
                //Final Results 
                Console.WriteLine("\r\nYou should buy {0} large pizzas for {1}.\r\nIf you bought small pizzas you would have spent {2} more.", numLargePizzas, costOfAllLarges.ToString("c"), difference.ToString("c"));


            } else
            {
                Console.WriteLine("Something bad happened");
            }
            Console.WriteLine("\r\nPress Any Key to Continue");
            Console.ReadKey();

        }


        public static decimal CostPerSlice(decimal costOfPizza, decimal numOfSlices)
        {
            //Using the parameters calculate the cost per slice
            decimal costOfSlice = costOfPizza / numOfSlices;

            //return the cost back to the main
            return costOfSlice;

        }

        public static int NumPizzasNeeded(decimal numGuest, decimal numSlices, decimal costOfPizza)
        {
            //Do the math 
            //Make sure to cast the ints as doubles or the math will be wrong
            double pizzasNeeded = (double)numGuest / (double)numSlices;

            //We can not order a fraction of a pizza, so round up
            int totalPizzas = ((int)Math.Ceiling(pizzasNeeded));

            //return to the main
            return totalPizzas;

        }

        public static decimal TotalCost(decimal costOfPizza, decimal numPizzasNeeded)
        {
            //Do the math
            decimal totalOfPizzas = costOfPizza * numPizzasNeeded;

            //return it to main
            return totalOfPizzas;
        }
        

    }
}
/* Test Run 1
 * Hello and welcome to the Pizza Party Planner!
We will try to figure out the cheapest way to get enough pizza for all the guests at a party.
In order to do this, we will need a few pieces of information from you!

How many people will be at your party? 87
Got it! You are having 87 guests at your party

I now need some information about the pizza options.
There are 2 sizes of pizzas that the store offers and each one has a different number of slices and a different price.

What is the cost of a small pizza? 8.25

Got it, a small pizza costs $8.25.
How many slices are in the small pizza? 9

A small pizza costs 9 and contains $0.92 slices!
So one slice costs $0.92!

What is the cost of a large pizza? 15.25

Got it, a large pizza costs $15.25.
How many slices are in the large pizza? 24

A large pizza costs $15.25 and contains 24 slices!
So one slice costs $0.64!

We will now figure out how many pizzas of each size you would need assuming each guest gets one slice of pizza.

You would need to order 10 small pizzas or 4 large pizzas to feed 87 guests.

You should buy 4 large pizzas for $61.00.
If you bought small pizzas you would have spent $21.50 more.

Press Any Key to Continue
*/
/* Test output 2
 * Hello and welcome to the Pizza Party Planner!
We will try to figure out the cheapest way to get enough pizza for all the guests at a party.
In order to do this, we will need a few pieces of information from you!

How many people will be at your party? 70
Got it! You are having 70 guests at your party

I now need some information about the pizza options.
There are 2 sizes of pizzas that the store offers and each one has a different number of slices and a different price.

What is the cost of a small pizza? 5

Got it, a small pizza costs $5.00.
How many slices are in the small pizza? 10

A small pizza costs 10 and contains $0.50 slices!
So one slice costs $0.50!

What is the cost of a large pizza? 20

Got it, a large pizza costs $20.00.
How many slices are in the large pizza? 15

A large pizza costs $20.00 and contains 15 slices!
So one slice costs $1.33!

We will now figure out how many pizzas of each size you would need assuming each guest gets one slice of pizza.

You would need to order 7 small pizzas or 5 large pizzas to feed 70 guests.

You should buy 7 small pizzas for $35.00.
If you bought large pizzas you would have spent $65.00 more.

Press Any Key to Continue
*/
/* Test output 3
 * Hello and welcome to the Pizza Party Planner!
We will try to figure out the cheapest way to get enough pizza for all the guests at a party.
In order to do this, we will need a few pieces of information from you!

How many people will be at your party? 50
Got it! You are having 50 guests at your party

I now need some information about the pizza options.
There are 2 sizes of pizzas that the store offers and each one has a different number of slices and a different price.

What is the cost of a small pizza? 7.50

Got it, a small pizza costs $7.50.
How many slices are in the small pizza? 10

A small pizza costs 10 and contains $0.75 slices!
So one slice costs $0.75!

What is the cost of a large pizza? 12.50

Got it, a large pizza costs $12.50.
How many slices are in the large pizza? 18

A large pizza costs $12.50 and contains 18 slices!
So one slice costs $0.69!

We will now figure out how many pizzas of each size you would need assuming each guest gets one slice of pizza.

You would need to order 5 small pizzas or 3 large pizzas to feed 50 guests.

You can buy either 5 small pizzas or 3 large pizzas.
Both will cost you $37.50.

Press Any Key to Continue
*/


