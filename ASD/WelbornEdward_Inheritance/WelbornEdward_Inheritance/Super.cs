using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Inheritance
{
    class Super : User
    {
        public Super(string name, string address, int age) : base(name, address, age)
        {

        }
        public override int SecurityLevel
        {
            get
            {
                return 10;
            }
        }
        public void DisplayStatus()
        {
            Console.WriteLine("User Status: Super User");
        }
    }
}
