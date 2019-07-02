using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE09
{
    class ShoppingCart : Inventory
    {
        public ShoppingCart()
        {

        }
        public static void DisplayCart(List<ShoppingCart> ShoppingCart)
        {
            // This method will display the cart if found, if not found then will display the message
            if (ShoppingCart.Count > 0)
            {
                Console.WriteLine("\r\nTitle                                                                  Price           Public Rating");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                foreach (ShoppingCart item in ShoppingCart)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("\r\nNo items are in the shopping cart");
            }
        }
        public static ShoppingCart AddToCart(List<Inventory> Inventory)
        {
            // this method moves a dvd from inventory to the shopping cart.
            int i = 0;
            int iInput = 0;
            ShoppingCart newCart = null;
            if (Inventory.Count > 0)
            {

                foreach (Inventory obj in Inventory)
                {
                    ++i;
                    Console.WriteLine("[" + i + "] " + obj.ToString());
                }
                iInput = Validation.GetInt("Please Choose an dvd to add to cart: ");
                Console.Write($"Move DVD at record: #{iInput - 1} to shopping cart: (y or n)");
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
    }
}
