using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    interface iLogin
    {
        bool HandleLogin();
        void SetPassword(string password);
    }
}
