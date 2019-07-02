using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;


namespace EdwardWelborn_CE09
{

    class Program
    {
        const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);


        static void Main(string[] args)
        {

            //initialize a Dictionary object to hold customers and their shopping carts.
            Dictionary<Customer, List<Item>> dictCustomer = new Dictionary<Customer, List<Item>>();
          
             //List to hold inventory
             List <Item> inventory = new List<Item>();
            
            Item newInventory = new Item();
            Item newCart = new Item();
            Customer cCustomer = null;

            string sConnection = string.Empty;
            string sCustomer = string.Empty;
            StreamReader Config = new StreamReader(@"c:/vfw/connection.txt");
            sConnection = Config.ReadLine();
            // MySQL Database Connection String
            string cs = $"server={sConnection};userid=dbremoteuser;password=password;database=example0219;port=8889";
            Config.Close();
            // Declare a MySQL Connection
            MySqlConnection conn = new MySqlConnection(cs);
            conn.Open();
            inventory = GetInventory(conn, inventory);

            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.SetWindowSize(80, 25);
                int xpos = 500;
                int ypos = 250;

                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                
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
                if (dictCustomer.Count > 0)
                {
                    Console.WriteLine($"\nCurrent Customer: {cCustomer}");
                }
                else
                {
                    Console.WriteLine($"\nCurrent Customer: None: ");
                }
                Console.Write("\nPlease Choose a number, or type the phrase: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select current shopper":
                        {
                            // if no shopper, create a shopper, if we have a shopper, then display menu
                            if (dictCustomer.Count > 0)
                            {
                                bool bSelection = true;
                                while(bSelection)
                                {
                                    Console.WriteLine("\r\n[1] (C)reate new Customer");
                                    Console.WriteLine("[2] (S)elect Customer");
                                    Console.WriteLine("[3] (Q)uit to Menu");
                                    Console.Write("Please choose a selection: (Number or phrase) ");
                                    string sSelection = Console.ReadLine().ToLower();
                                    switch(sSelection)
                                    {
                                        case "1":
                                        case "create new customer":
                                        case "c":
                                            {
                                                bSelection = false;
                                                sCustomer = CreateCustomer();
                                                cCustomer = new Customer(sCustomer);
                                                dictCustomer.Add(cCustomer, new List<Item>());
                                            }
                                            break;
                                        case "2":
                                        case "select customer":
                                        case "s":
                                            {
                                                bSelection = false;
                                                cCustomer = SelectCustomer(dictCustomer);
                                            }
                                            break;
                                        case "3":
                                        case "q":
                                        case "quite to menu":
                                            {
                                                bSelection = false;
                                            }
                                            break;
                                        default:
                                            {
                                                Console.WriteLine("Please Select a number or enter the phrase");
                                            }
                                             break;
                                    }
                                }
                            }
                            else
                            {
                                // Sicnce customer is empty create one.
                                 sCustomer = CreateCustomer();
                                 cCustomer = new Customer(sCustomer);
                                 dictCustomer.Add(cCustomer, new List<Item>());
                            }
                        }
                        break;
                    case "2":
                    case "view store inventory":
                        {
                            // View Inventory list, inventory was imported from the database in method (CreateInventory)
                            Console.Clear();
                            Console.SetWindowSize(150, 60);
                            xpos = 400;
                            ypos = 20;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            if (inventory.Count > 0)
                            {
                                Console.WriteLine("\r\nTitle                                                                                           Price ");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                                foreach (Item item in inventory)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("\r\nNo items are in inventory");
                            }

                        }
                        break;
                    case "3":
                    case "view shopping cart":
                        {
                            // ********** needs revising
                                                        int j = 0;
                                                       Console.SetWindowSize(150, 60);
                                                        xpos = 500;
                                                        ypos = 10;
                                                        SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                                                        Console.Clear();

                            if (!dictCustomer.Any() || cCustomer == null)
                            {
                                Console.WriteLine("Select or Create a customer to view the cart.");
                            }
                            else if (!cCustomer.ShoppingCart.Any())
                            {
                                Console.WriteLine("The cart is empty.");
                            }
                            else
                            {
                                Console.WriteLine($"\nCustomer: {cCustomer} is purchasing:\n");
                                int counter = 1;
                                for (int i = 0; i < cCustomer.ShoppingCart.Count; i++)
                                {
                                    Console.WriteLine((counter++) + ". " + cCustomer.ShoppingCart[i].ToString());
                                }
                            }
                        }
                        break;
                    case "4":
                    case "add item to cart":
                        {
                            // add item to cart, remove from inventory
                            // write to logger customerName added item to cart
                           

                            Console.SetWindowSize(150, 60);
                            xpos = 500;
                            ypos = 10;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            int i = 0;
                            Console.Clear();
                            if (dictCustomer.Count > 0)
                            {
                                Console.WriteLine("\r\nTitle                                                                                           Price ");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                                if (!dictCustomer.Any())
                                {
                                    Console.WriteLine("No Items available.");
                                }
                                else
                                {
                                    foreach (var coll in inventory)
                                    {
                                        i++;
                                        Console.WriteLine($"[{i}]: {coll}");
                                    }
                                }

                                Console.Write("\nPlease Choose an item to add to cart: ");
                                string strChooseItem = Console.ReadLine();
                                int iInput = Validation.ValidateIntRange(1, i, strChooseItem);
                                Console.Write($"Move item at record: #{iInput} to shopping cart: (y or n): ");
                                string sInput = Console.ReadLine().ToLower();
                                Item val = inventory[iInput - 1];
                                switch (sInput)
                                {
                                    case "y":
                                        {
                                            foreach (KeyValuePair<Customer, List<Item>> storeCustomer in dictCustomer)
                                            {
                                                if (cCustomer == storeCustomer.Key)
                                                {
                                                    Console.WriteLine($"{inventory[iInput - 1].Title.ToString()} added to shopping cart");
                                                    storeCustomer.Value.Add(inventory[iInput - 1]);
                                                    cCustomer.ShoppingCart.Add(inventory[iInput - 1]);
                                                    inventory.Remove(inventory[iInput - 1]);
                                                }
                                            }
                                        }
                                        break;
                                    case "n":
                                    case null:
                                    case "":
                                        {
                                            Console.WriteLine("\r\nNo Valid number was chosen: ");
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("No Valid Number Chosen: ");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Customer Information, Please Create a Customer: ");
                            }
                        }
                        break;
                    case "5":
                    case "remove item from cart":
                        {
                            // This method moves an item from the shopping cart back to inventory
                            int j = 0;
                            Console.Clear();
                            Console.SetWindowSize(150, 60);
                            xpos = 500;
                            ypos = 200;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            if (!dictCustomer.Any() || cCustomer == null)
                            {
                                Console.WriteLine("Select or Create a customer to view the cart.");
                            }
                            else if (!cCustomer.ShoppingCart.Any())
                            {
                                Console.WriteLine("The cart is empty.");
                            }
                            else
                            {
                                Console.WriteLine($"\nCustomer: {cCustomer} is purchasing:\n");
                                int counter = 1;
                                for (int i = 0; i < cCustomer.ShoppingCart.Count; i++)
                                {
                                    Console.WriteLine((counter++) + ". " + cCustomer.ShoppingCart[i].ToString());
                                }
                                Console.Write("\nPlease Choose a item to remove: ");
                                string strChooseItem = Console.ReadLine();
                                int iInput = Validation.ValidateIntRange(1, dictCustomer.Values.Count, strChooseItem);
                                inventory.Add(cCustomer.ShoppingCart[iInput - 1]);
                                cCustomer.ShoppingCart.Remove(cCustomer.ShoppingCart[iInput - 1]);
                                Console.WriteLine("The item has been removed from the cart.");
                            }
                        }
                        break;
                    case "6":
                    case "complete purchase":
                        {
                            Console.SetWindowSize(120, 30);
                            xpos = 500;
                            ypos = 250;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            // remove items from  the cart, remove customer
                            // write to logger customerName added item to cart
                            // write to logger items removed from inventory
                            // Logger.LoggerIt(cCustomer, newCart, 3);
                            if (dictCustomer.Count > 0)
                            {
                                Console.Write($"Complete Transaction for {sCustomer.ToString()}: (y or n)");
                                string sInput = Console.ReadLine().ToLower();
                                switch (sInput)
                                {
                                    case "y":
                                        {
                                            Console.WriteLine($"Removing {sCustomer.ToString()}");
                                            dictCustomer.Remove(cCustomer);
                                        }
                                        break;
                                    case "n":
                                    case null:
                                    case "":
                                        {
                                            Console.WriteLine($"\r\nThe Customer, {sCustomer.ToString()}, will not be removed:: ");
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("No valid input was chosen");
                                        }
                                        break;
                                }
                                
                                
                            }
                            else
                            {
                                Console.WriteLine("\nNo Customer Information, Please Create a Customer: ");
                            }
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
 
        public static string CreateCustomer()
        {
            string currentCustomer = null;
            Console.WriteLine("\nCreating New Customer");
            Console.Write("\nPlease Enter the Customer Name: ");
            string strCustomerName = Console.ReadLine();
            currentCustomer = Validation.ValidateText(strCustomerName);
            return currentCustomer;
        }
        public static Customer SelectCustomer(Dictionary<Customer, List<Item>> dictCustomer)
        {
            int iCounter = 0;
            int iInput = 0;
            Console.Clear();
            // Needs an option to either choose a customer, or create a new one
            Console.WriteLine("\r\nReading Current Customer List");
            Console.WriteLine("Name");
            Console.WriteLine("--------------------");
            foreach (var Name in dictCustomer)
            {
                iCounter++;
                // do something with entry.Value or entry.Key
                Console.WriteLine($"[{iCounter}] {Name.Key.ToString()}");
            }

            Console.Write("\nPlease Choose a Customer: ");
            string strChooseCustomer = Console.ReadLine();
            iInput = Validation.ValidateInt(strChooseCustomer);
            Customer cCustomer = dictCustomer.Keys.ElementAt(iInput - 1);
            return cCustomer;
        }
        public static List<Item> GetInventory(MySqlConnection conn, List<Item> inventory)
        {
            // Method to get 20 records starting at record 1100. Adding that to the inventory list.
            decimal RetailPrice = 0;
            Console.WriteLine("Populating Inventory from record 1500, limiting to 50\n");
            try
            {
                // Form SQL Statement

                string stm = "select title, retailPrice from item limit 1500,50;";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    string Title = rdr["Title"].ToString();
                    decimal.TryParse(rdr["retailPrice"].ToString(), out RetailPrice);

                    Item newInventory = new Item() { Title = Title, Price = RetailPrice };
                    inventory.Add(newInventory);
                    // Console.WriteLine("Title {0}, Price: {1}, Public Rating: {2}", Title, Price, publicRating);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return inventory;
        }

    }
}
/* TO DO
 * Select / Create Customer ** DONE
 * View Store Inventory ****** DONE
 * View Shopping Cart ******** DONE
 * Add Item to Cart ********** DONE
 * Remove Item from Cart ***** DONE
 * Log user interactions -- Not complete -- not even started
 * Complete Purchase ********* DONE
 */
