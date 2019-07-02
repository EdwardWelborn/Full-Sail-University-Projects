using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_classbasics
{
    class User
    {
        string _name;
        string _address;
        int _age;

        Preferences _prefs;


        public string GetName()
        {
            return _name;
        }
        public string SetName(string name)
        {
            _name = name;
            return _name;
        }
        public string GetAddress()
        {
            return _address;
        }
        public string SetAddress(string address)
        {
            _address = address;

            return _address;

        }

        public int GetAge()
        {
            return _age;
        }

        public int SetAge(int age)
        {
            _age = age;

            return _age;
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

        public Preferences GetPreferences()
        {
            return _prefs;
        }

        public Preferences SetPreference(Preferences prefs)
        {
            _prefs = prefs;
            return prefs;
        }
    }
}
