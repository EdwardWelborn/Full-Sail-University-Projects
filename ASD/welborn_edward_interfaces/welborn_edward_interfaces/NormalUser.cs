using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    class NormalUser : User
    {
        private iLogin _ilogin;

        public NormalUser(string name, string password) : base(name, 1)
        {
            _ilogin = new NormalLogin(password);
        }

        public override bool Login()
        {
            return _ilogin.HandleLogin();
        }
    }
}
