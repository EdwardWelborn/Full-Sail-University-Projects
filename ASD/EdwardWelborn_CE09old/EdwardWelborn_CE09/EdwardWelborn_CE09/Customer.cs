using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE09
{
    class Customer
    {
        string _name = string.Empty;

        public Customer()
        {

        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Customer CreateCustomer()
        {
            Customer currentCustomer = null;

            return currentCustomer;
        }
        public Customer SelectCustomer(List<Customer> currentCustomer)
        {
            Customer cCustomer = null;

            return cCustomer;
        }
    }
}
