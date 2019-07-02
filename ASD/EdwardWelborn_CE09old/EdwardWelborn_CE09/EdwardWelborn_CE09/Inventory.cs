using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EdwardWelborn_CE09
{
    class Inventory
    {
        string _title = string.Empty;
        decimal _retailPrice = 0;

        public Inventory()
        {

        }
        public Inventory(string Title, decimal Price)
        {
            _title = Title;
            _retailPrice = Price;
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public decimal Price
        {
            get
            {
                return _retailPrice;
            }
            set
            {
                _retailPrice = value;
            }
        }
        public static void DisplayInventory(List<Inventory> Inventory)
        {
            // This method will display the inventory loaded into the inventory list from the database.
            if (Inventory.Count > 0)
            {
                Console.WriteLine("\r\nTitle                                                                  Price ");
                Console.WriteLine("---------------------------------------------------------------------------------");
                foreach (Inventory item in Inventory)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("\r\nNo items are in inventory");
            }
        }
        public static Inventory AddToInventory(List<ShoppingCart> ShoppingCart)
        {
            // This method moves an item from the shopping cart back to inventory
            int i = 0;
            int iInput = 0;
            Inventory inventory = null;
            if (ShoppingCart.Count > 0)
            {

                foreach (ShoppingCart obj in ShoppingCart)
                {
                    ++i;
                    Console.WriteLine("[" + i + "] " + obj.ToString());
                }
                iInput = Validation.GetInt("Please Choose an dvd to add to cart: ");
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
        public static List<Inventory> GetInventory(MySqlConnection conn)
        {
            // Method to get 20 records starting at record 1100. Adding that to the inventory list.
            decimal Price = 0;
            Console.WriteLine("Populating Inventory from record 1100, limiting to 100\n");
            List<Inventory> inventory = new List<Inventory>();
            try
            {

                // Form SQL Statement

                string stm = "select title, retailPrice from item limit 1100,100;";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    // Strings
                    string Title = rdr["Title"].ToString();
                    decimal.TryParse(rdr["retailPrice"].ToString(), out Price);

                    Inventory newInventory = new Inventory(Title, Price);
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
