using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    class SuperUser : User
    {

        private iLogin _ilogin;

        public SuperUser(string name, string password) : base(name, 10)
        {
            _ilogin = new FaceLogin(password);

        }
        public override bool Login()
        {
            return _ilogin.HandleLogin();
        }
    }
}
