using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    class NormalLogin : iLogin
    {
        private string _password;

        public NormalLogin()
        {

        }
        public NormalLogin(string password)
        {
            _password = password;
        }
        
        public void SetPassword(string password)
        {
            _password = password;

        }
        public bool HandleLogin()
        {
            bool LoginSuccessful = false;

            Console.Write($"Please enter your Password: ");
            string input = Console.ReadLine();

            if (_password.Equals(input))
            {
                LoginSuccessful = true;
            }

            return LoginSuccessful;

        }
    }
}
