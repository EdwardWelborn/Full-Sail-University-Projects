using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class Salaried : Employee
    {
        private decimal _salary = 0;

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = Salary;
            }

        }
        public Salaried(string name, string address, decimal Salary) : base(name, address)
        {
            //name = Name;
            //address = Address;
            _salary = Salary;
        }
        public override string ToString()
        {
            string SalaryEmployee = $"{this.Name, -30} {this.Address, -45}";
            return SalaryEmployee;
        }
        public override decimal CalculatePay(Employee Employees)
        {
            decimal totalPay = 0;
            totalPay = this.Salary;
            return totalPay;

        }

    }
}
