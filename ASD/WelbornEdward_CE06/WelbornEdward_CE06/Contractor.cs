using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class Contractor : Hourly
    {
        private decimal _noBenefitsBonus = 0;

        public decimal NoBenefitBonus
        {
            get
            {
                return _noBenefitsBonus;
            }
            set
            {
                _noBenefitsBonus = NoBenefitBonus;
            }
        }

        public Contractor(string name, string address, decimal payPerHour, decimal hoursPerWeek, decimal NoBenefitBonus) : base (name, address, payPerHour, hoursPerWeek)
        {
            //name = Name;
            //address = Address;
            //payPerHour = PayPerHour;
            //hoursPerWeek = HoursPerWeek;
            _noBenefitsBonus = NoBenefitBonus;
        }
        public override string ToString()
        {
            string ContractEmployee = $"{this.Name, -30} {this.Address, -45}";
            return ContractEmployee;
        }
        public override decimal CalculatePay(Employee Employees)
        {
            decimal totalPay = 0;
            try
            {
                totalPay = (((this.payPerHour + (this.payPerHour * (this.NoBenefitBonus / 100))) * this.hoursPerWeek) * 52);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Total Pay is Much to high for this person.");
                totalPay = 0;
            }
            
            return totalPay;

        }
    }
}
