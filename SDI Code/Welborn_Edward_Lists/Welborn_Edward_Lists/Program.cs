// Edward Welborn
// 10/12/2018
// Lists Assignment
// SDI - MDV2330-O
//       C20181002

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_Lists
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // Variable Declaration
            List<decimal> lPriceList = new List<Decimal> (new decimal[] { });
            decimal dSum = 0;
            // Add items to the list
            lPriceList.Add(27.99M);
            lPriceList.Add(75.00M);
            lPriceList.Add(12.95M);
            lPriceList.Add(38.98M);
            lPriceList.Add(1.75M);
            lPriceList.Add(99.63M);
            lPriceList.Add(85.25M);
            lPriceList.Add(47.65M);
            // Call Method and add up the pricelist
            dSum = AddUpCosts(lPriceList);
            //output returned from method
            Console.WriteLine("The sum of this pricelist is: {0:C2}", dSum);
            // Make changes to the list, remove 2 items and add on to the beginning of the list
            Console.WriteLine("\r\nWe need to add a price and remove a couple from the list, one moment:");
            // removing 2 items and insterting 1 into the beginning of the list
            lPriceList.Remove(85.25M);
            lPriceList.Remove(1.75M);
            lPriceList.Insert(0, 36.86M);
            // sum up the new list and get returned value
            dSum = AddUpCosts(lPriceList);
            // write output from the changes to the console.
            Console.WriteLine("\r\nThe sum of the new pricelist is: {0:C2}", dSum);
            Console.WriteLine("\r\nPress Any Key to Continue");
            Console.ReadKey();
        }
        public static decimal AddUpCosts(List<decimal> lPriceList)
        {
            decimal dSum = 0;
            // grab the elements of the list and add them up.
            foreach (decimal dElement in lPriceList)
            {
                dSum += dElement;
            }
            // return the value to the main method
            return dSum;


        }
    }
}

/* Test out put from the list program
 * The sum of this pricelist is: $389.20

We need to add a price and remove a couple from the list, one moment:

The sum of the new pricelist is: $339.06

Press Any Key to Continue
*/

