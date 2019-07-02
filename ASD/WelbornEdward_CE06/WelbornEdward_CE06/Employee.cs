using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class Employee
    {
        private string _name;
        private string _address;
        public Employee()
        {

        }
        public Employee(string name, string address)
        {
            _name = name;
            _address = address;

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
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }

        }
        public virtual decimal CalculatePay(Employee Employees)
        {
            decimal totalPay = 0;
            return totalPay;
        }
        public static void Sort(List<Employee> list)
        {
            list.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, true));
        }
    }
}
