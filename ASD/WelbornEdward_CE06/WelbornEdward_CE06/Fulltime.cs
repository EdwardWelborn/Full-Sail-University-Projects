using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE06
{
    class Fulltime : Hourly
    {

        public Fulltime(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name, address, payPerHour, hoursPerWeek)
        {
            //name = Name;
            //address = Address;
            //payPerHour = PayPerHour;
            //hoursPerWeek = HoursPerWeek;
        }
        public override string ToString()
        {
            string Fulltimer = $"{this.Name, -30} {this.Address, -45}";
            return Fulltimer;
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
