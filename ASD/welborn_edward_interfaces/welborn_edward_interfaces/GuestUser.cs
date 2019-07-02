using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    class GuestUser : User
    {
        public GuestUser() : base ("Guest", 0)
        {
    
        }
        public override bool Login()
        {
            return true;
        }
    }
}
