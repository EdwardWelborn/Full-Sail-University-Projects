// Edward Welborn
// FixErrorClass Assignment
// 10/15/2018
// SDI: MDV2330-O
//      C20181002

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindErrorsClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //In this program we will create a class of a movie and utillize the methods and member variables

            //Create four instances of the movie class
            Movie theGoonies = new Movie("The Goonies", 19000000m, 61500000m, 1985);
            Movie originalGhostbusters = new Movie("Ghostbusters", 30000000m, 295200000m, 1984);
            Movie ghostbusters = new Movie("Ghostbusters", 144000000m, 229100000m, 2016);
            Movie theAvengers = new Movie("The Avengers", 220000000m, 519000000m, 2012);


            //Use the Getters
            Console.WriteLine("\r\nWhen I was a kid, one of my favorite movies growing up was {0} which came out in {1}.", theGoonies.GetMovieTitle(), theGoonies.GetYearMade());

            Console.WriteLine("When it originally came out it cost {0} to make, which was a lot back then!", theGoonies.GetCostToMake().ToString("c"));

            //Update the Box Office Total for The Avenegers movie using a setter
            theAvengers.SetMoneyMade(1519000000m);
            decimal avengersDifference = theAvengers.GetMoneyMade() - theAvengers.GetCostToMake();
            Console.WriteLine("\r\nNow a days movies cost so much more to make!");
            Console.WriteLine("Take {0} for example.\r\nIt cost {1} to make, however it also brought in {2} at the box office!!", theAvengers.GetMovieTitle(), theAvengers.GetCostToMake().ToString("c"), theAvengers.GetMoneyMade().ToString("c"));
            Console.WriteLine("Marvel and Disney made {0:C2} from that movie alone!", avengersDifference);

            Console.WriteLine("\r\nLet's take a look at the same movie, but made in different years.");

            //Fix Ghostbusters original year it came out using a setter
            originalGhostbusters.SetYearMade(1984);

            Console.WriteLine("{0} came out in both {1} and in {2}!", originalGhostbusters.GetMovieTitle(), originalGhostbusters.GetYearMade(), ghostbusters.GetYearMade());

            //Calculate the difference between each ghostbuster film
            decimal differenceBudget = ghostbusters.GetCostToMake() - originalGhostbusters.GetCostToMake();
            decimal differneceBoxOffice = originalGhostbusters.GetMoneyMade() - ghostbusters.GetMoneyMade();


            Console.WriteLine("If we take a look at how each film did in the box office, you might think they were basically the same.");
            Console.WriteLine("The original making {0}, while the new one made {1}.", originalGhostbusters.GetMoneyMade().ToString("c"), ghostbusters.GetMoneyMade().ToString("c"));
            Console.WriteLine("That is only a difference of {0}.", differneceBoxOffice.ToString("C"));

            Console.WriteLine("\r\nHowever when you look at the costs to make the two films, it gets more interesting!");
            Console.WriteLine("The original cost {0} to make.\r\nThe new cost {1}.\r\nThat is a difference of {2}!", originalGhostbusters.GetCostToMake().ToString("c"), ghostbusters.GetCostToMake().ToString("c"), differenceBudget.ToString("c"));

            //Conditional to test which has the higher profit

            if (originalGhostbusters.ProfitMade() > ghostbusters.ProfitMade())
            {
                //Calculate the difference in profit    
                decimal differenceProfits = originalGhostbusters.ProfitMade() - ghostbusters.ProfitMade();
                Console.WriteLine("\r\nThis mean s there is a difference in profit between the two films of {0}!", differenceProfits.ToString("c"));
                Console.WriteLine("Which makes the original much more profitable!");

            }
            else
            {
                decimal differenceProfits = ghostbusters.ProfitMade() - originalGhostbusters.ProfitMade();
                Console.WriteLine("\r\nThis means there is a difference in profit between the two films of {0}!", differenceProfits.ToString("c"));
                Console.WriteLine("Which makes the remake much more profitable!");
            }

            Console.WriteLine("\r\nIn the end though, they were both great films in their own way!");
            Console.WriteLine("\r\nPress Any Key to Continue...");
            Console.ReadKey();
        }
    }
}
/* Test output for ErrorClass

When I was a kid, one of my favorite movies growing up was The Goonies which came out in 1985.
When it originally came out it cost $19,000,000.00 to make, which was a lot back then!

Now a days movies cost so much more to make!
Take The Avengers for example.
It cost $220,000,000.00 to make, however it also brought in $1,519,000,000.00 at the box office!!
Marvel and Disney made $1,299,000,000.00 from that movie alone!

Let's take a look at the same movie, but made in different years.
Ghostbusters came out in both 1984 and in 2016!
If we take a look at how each film did in the box office, you might think they were basically the same.
The original making $295,200,000.00, while the new one made $229,100,000.00.
That is only a difference of $66,100,000.00.

However when you look at the costs to make the two films, it gets more interesting!
The original cost $30,000,000.00 to make.
The new cost $144,000,000.00.
That is a difference of $114,000,000.00!

This mean s there is a difference in profit between the two films of $180,100,000.00!
Which makes the original much more profitable!

In the end though, they were both great films in their own way!

Press Any Key to Continue...
*/

