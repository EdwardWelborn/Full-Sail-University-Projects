using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    abstract class User
    {
        private string _name;
        private int _securityLevel;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int SecurityLevel
        {
            get
            {
                return _securityLevel;
            }
            set
            {
                _securityLevel = value;
            }
        }
        public User(string name, int securityLevel)
        {
            _name = name;
            _securityLevel = securityLevel;
        }
        abstract public bool Login();


    }
}
