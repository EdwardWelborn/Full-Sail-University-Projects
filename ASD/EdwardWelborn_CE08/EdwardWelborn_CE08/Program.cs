using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace EdwardWelborn_CE08
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
            string sConnection = string.Empty;
            List<DVD> Inventory = new List<DVD>();
            List<DVD> ShoppingCart = new List<DVD>();
            DVD newInventory = null;
            DVD newCart = null;
            StreamReader Config = new StreamReader(@"c:/vfw/connection.txt");
            sConnection = Config.ReadLine();
            // MySQL Database Connection String
            string cs = $"server={sConnection};userid=dbremoteuser;password=password;database=example0219;port=8889";
            Config.Close();
            // Declare a MySQL Connection
            MySqlConnection conn = new MySqlConnection(cs);
            conn.Open();
            Inventory = GetInventory(conn);

            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "      CE08 Assignment\n" +
                        "---------------------------\n" +
                        "[1]..  View Inventory\n" +
                        "[2]..  View Shopping Cart\n" +
                        "[3]..  Add DVD to cart\n" +
                        "[4]..  Remove DVD from Cart\n" +
                        "[5]..  Exit Program\n" +
                        "---------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Choose a number, or type the phrase: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "view inventory":
                        {
                            Console.Clear();
                            Console.SetWindowSize(110, 30);
                            xpos = 650;
                            ypos = 200;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            DisplayInventory(Inventory);
                        }
                        break;
                    case "2":
                    case "view shopping cart":
                        {
                            Console.Clear();
                            Console.SetWindowSize(110, 30);
                            xpos = 650;
                            ypos = 200;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            DisplayCart(ShoppingCart);
                        }
                        break;
                    case "3":
                    case "add dvd to cart":
                        {
                            Console.Clear();
                            Console.SetWindowSize(110, 30);
                            xpos = 650;
                            ypos = 200;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            newCart = AddToCart(Inventory);
                            if (newCart != null)
                            {
                                Console.WriteLine(newCart.Title, newCart.Price, newCart.Rating);
                                ShoppingCart.Add(newCart);
                            }
                            else
                            {
                                Console.WriteLine("Nothing Added to Shopping Cart");
                            }
                        }
                        break;
                    case "4":
                    case "remove dvd from cart":
                        {
                            Console.Clear();
                            Console.SetWindowSize(110, 30);
                            xpos = 650;
                            ypos = 200;
                            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                            newInventory = AddToInventory(ShoppingCart);
                            if (newCart != null)
                            {
                                Console.WriteLine(newCart.Title, newCart.Price, newCart.Rating);
                                Inventory.Add(newInventory);
                            }
                            else
                            {
                                Console.WriteLine("Nothing Removed to Shopping Cart");
                            }
                        }
                        break;
                    case "5":
                    case "e":
                    case "exit":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\r\nPlease choose a valid number between 1 and 5");
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

        public static void DisplayInventory(List<DVD> Inventory)
        {
            // This method will display the inventory loaded into the inventory list from the database.
            if (Inventory.Count > 0)
            {
                Console.WriteLine("\r\nTitle                                                                  Price           Public Rating");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                foreach (DVD item in Inventory)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("\r\nNo items are in inventory");
            }
        }
        public static void DisplayCart(List<DVD> ShoppingCart)
        {
            // This method will display the cart if found, if not found then will display the message
            if (ShoppingCart.Count > 0)
            {
                Console.WriteLine("\r\nTitle                                                                  Price           Public Rating");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                foreach (DVD item in ShoppingCart)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("\r\nNo items are in the shopping cart");
            }
        }
        public static DVD AddToInventory(List<DVD> ShoppingCart)
        {
            // This method moves an item from the shopping cart back to inventory
            int i = 0;
            int iInput = 0;
            DVD inventory = null;
            if (ShoppingCart.Count > 0)
            {
                Console.WriteLine("\r\nTitle                                                                  Price           Public Rating");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                foreach (DVD obj in ShoppingCart)
                {
                    ++i;
                    Console.WriteLine("[" + i + "] " + obj.ToString());
                }
                Console.Write("\nPlease Choose an dvd to add to cart: ");
                string strDVDInput = Console.ReadLine();
                iInput = Validation.ValidateIntRange(1, i, strDVDInput);
                Console.Write($"Move DVD at record: #{iInput} to shopping cart: (y or n)");
                string sInput = Console.ReadLine();
                if (string.IsNullOrEmpty(sInput))
                {
                    Console.WriteLine("\r\nNo Valid number was chosen: ");
                }
                else
                    switch (sInput.ToLower())
                    {
                        case "y":
                            {
                                inventory = ShoppingCart[iInput - 1];
                                ShoppingCart.RemoveAt(iInput - 1);
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
                                Console.WriteLine("Keeping DVD in the Shopping Cart");
                            }
                            break;
                    }
            }
            else
            {
                Console.WriteLine("\nNo records were found in Inventory");
            }
            return inventory;
        }

        public static DVD AddToCart(List<DVD> Inventory)
        {
            // this method moves a dvd from inventory to the shopping cart.
            int i = 0;
            int iInput = 0;
            DVD newCart = null;
            if (Inventory.Count > 0)
            {
                Console.WriteLine("\r\nTitle                                                                  Price           Public Rating");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                foreach (DVD obj in Inventory)
                {
                    ++i;
                    Console.WriteLine("[" + i + "] " + obj.ToString());
                }
                Console.Write("\nPlease Choose an dvd to add to cart: ");
                string strInput = Console.ReadLine();
                iInput = Validation.ValidateIntRange(1, i, strInput);
                Console.Write($"Move DVD at record: #{iInput} to shopping cart: (y or n)");
                string sInput = Console.ReadLine();
                if (string.IsNullOrEmpty(sInput))
                {
                    Console.WriteLine("\r\nNo Valid number was chosen: ");
                }
                else
                    switch (sInput.ToLower())
                    {
                        case "y":
                            {
                                newCart = Inventory[iInput - 1];
                                Inventory.RemoveAt(iInput - 1);
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
                                Console.WriteLine("Keeping DVD in Inventory");
                            }
                            break;
                    }
            }
            else
            {
                Console.WriteLine("\nNo records were found in the Shopping Cart");
            }
            return newCart;
        }

        public static List<DVD> GetInventory(MySqlConnection conn)
        {
            // Method to get 20 records starting at record 1100. Adding that to the inventory list.
            decimal Price = 0;
            float publicRating = 0;
            Console.WriteLine("Populating Inventory from record 1100, limiting to 20\n");
            List<DVD> inventory = new List<DVD>();
            try
            {

                // Form SQL Statement

                string stm = "select DVD_Title, Price, publicRating from DVD Limit 1100,20;";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    // Strings
                    string Title = rdr["DVD_Title"].ToString();
                    decimal.TryParse(rdr["Price"].ToString(), out Price);
                    float.TryParse(rdr["publicRating"].ToString(), out publicRating);

                    DVD newInventory = new DVD(Title, Price, publicRating);
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

