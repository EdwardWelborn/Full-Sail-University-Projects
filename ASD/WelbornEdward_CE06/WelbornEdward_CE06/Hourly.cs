using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class Hourly : Employee
    {
        decimal _payPerHour = 0;
        decimal _hoursPerWeek = 0;

        public Hourly(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name, address)
        {
            //name = Name;
            //address = Address;
            _payPerHour = payPerHour;
            _hoursPerWeek = hoursPerWeek;
        }
        public decimal payPerHour
        {
            get
            {
                return _payPerHour;
            }
            set
            {
                _payPerHour = payPerHour;
            }
        }
        public decimal hoursPerWeek
        {
            get
            {
                return _hoursPerWeek; 
            }
            set
            {
                _hoursPerWeek = hoursPerWeek;
            }
        }
        public override decimal CalculatePay(Employee Employees)
        {
            decimal totalPay = 0;
            try
            {
                totalPay = checked((this.payPerHour * this.hoursPerWeek) * 52);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Total Pay is Much to high for this person.");
                totalPay = 0;
            }
            return totalPay;

        }
    }


}
