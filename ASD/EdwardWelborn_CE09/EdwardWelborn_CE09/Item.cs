using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EdwardWelborn_CE09
{
    public class Item
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public decimal GetRetailPrice()
        {
            return this.Price;
        }

        public override string ToString()
        {
            string InvToString = $"{this.Title,-95} ${this.Price,-15}";
            return InvToString;
        }
    }
    //    class Items
    //    {
    //        public List<Item> lstInventory { get; set; }
    //        public Dictionary<Customer, List<Item>> dCustomer { get; set; }
    //        public Items()
    //        {
    //            lstInventory = new List<Item>();
    //            dCustomer = new Dictionary<Customer, List<Item>>();
    //        }
    //    }
}
