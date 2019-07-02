using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class Manager : Salaried
    {
        private decimal _bonus;

        public decimal Bonus
        {
            get
            {
                return _bonus;
            }
            set
            {
                _bonus = Bonus;
            }
        }
        public Manager(string name, string address, decimal salary, decimal bonus) : base(name, address, salary)
        {
            //name = Name;
            //address = Address;
            //salary = Salary;
            _bonus = bonus;
        }
        public override string ToString()
        {
            string Management = $"{this.Name, -30} {this.Address, -45}";
            return Management;
        }
        public override decimal CalculatePay(Employee Employees)
        {
            decimal totalPay = 0;
            totalPay = (this.Salary + this.Bonus);
            return totalPay;

        }


    }
}
