using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class PartTime : Hourly
    {
        public PartTime(string name, string address, decimal payPerHour, decimal hourPerWeek) : base(name, address, payPerHour, hourPerWeek)
        {
            //name = Name;
            //address = Address;
            //payPerHour = PayPerHour;
            //hoursPerWeek = hoursPerWeek;
        }
        public override string ToString()
        {
            string Parttimer = $"{this.Name, -30} {this.Address, -45}";
            return Parttimer;
        }
//        public override decimal CalculatePay(Employee Employees)
//        {
//            decimal totalPay = 0;
//            try
//            {
//                totalPay = checked((this.payPerHour * this.hoursPerWeek) * 52);
//            }
//            catch (OverflowException)
//            {
//                Console.WriteLine("Total Pay is Much to high for this person.");
//                totalPay = 0;
//            }
//            
//            return totalPay;
//
//        }
    }
}
