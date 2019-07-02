using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Polymorphism
{
    class User
    {
       private string _name;
       private string _address;
       private int _age;

        private Preferences _prefs;


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
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
           
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
            
        }
        public User()
        {

        }
        public User(string name, string address, int age)
        {
            _name = name;
            _address = address;
            _age = age;

        }

        public virtual int SecurityLevel
        {
            get
            {
                return 1;
            }
        }

        public Preferences Prefs
        {
            get
            {
                return _prefs;
            }
            set
            {
                _prefs = value;
            }
            
        }
        
    }
}
