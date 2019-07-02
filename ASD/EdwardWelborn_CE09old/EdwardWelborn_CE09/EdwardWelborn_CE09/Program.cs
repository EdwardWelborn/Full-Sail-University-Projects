using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace EdwardWelborn_CE09
{
    class Program
    {
        string sConnect = null;
        List<Inventory> inenvtory = new List<Inventory>();
        List<ShoppingCart> sCart = new List<ShoppingCart>();
        Dictionary<Customer, List<ShoppingCart>> dCustomer = new Dictionary<Customer, List<ShoppingCart>>();
        string file = null;
        sConnect = file;
        void Main(string[] args)
        {
            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "       CE09 Assignment\n" +
                        "-----------------------------\n" +
                        "[1]..  Select Current Shopper\n" +
                        "[2]..  View Store Inventory\n" +
                        "[3]..  View Shopping Cart\n" +
                        "[4]..  Add Item to Cart\n" +
                        "[5]..  Remove Item from Cart\n" +
                        "[6]..  Complete Purchase\n" +
                        "[7]..  Exit Program\n" +
                        "---------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Choose a number, or type the phrase: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select current shopper":
                        {
                            // if no shopper, create a shopper, if we have a shopper, list and the user casn choose
                        }
                        break;
                    case "2":
                    case "view store inventory":
                        {
                            // load inventory from database, put to inventory list.
                        }
                        break;
                    case "3":
                    case "view shopping cart":
                        {
                            // view cart if count > 0 otherwise give error
                        }
                        break;
                    case "4":
                    case "add item to cart":
                        {
                            // add item to cart, remove from inventory
                            // write to logger customerName added item to cart
                        }
                        break;
                    case "5":
                    case "remove item from cart":
                        {
                            // add item to inventory, remove from cart
                            // write to logger customerName added item to cart
                        }
                        break;
                    case "6":
                    case "complete purchase":
                        {
                            // remove items from  the cart, remove customer
                            // write to logger customerName added item to cart
                            // write to logger items removed from inventory
                        }
                        break;
                    case "7":
                    case "e":
                    case "exit":
                        {
                            // exit program
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\r\nPlease choose a valid number between 1 and 7");
                        }
                        break;
                }
                if (bProgramRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Continue");
                }
            }
            Utility.PressAnyKeyToContinue("Press Any Key to Exit");
        }
    }
}
