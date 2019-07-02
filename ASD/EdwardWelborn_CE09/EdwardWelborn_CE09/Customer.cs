using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE09
{
    class Customer
    {
        string Name;
        public List<Item> ShoppingCart { get; set; }


        public Customer(string Name)
        {
            this.Name = Name;
            ShoppingCart = new List<Item>();
        }
        public string GetName()
        {
            return this.Name;
        }

        public override string ToString()
        {
            string InvToString = $"{this.Name}";
            return InvToString;
        }
    }
}
