using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE01
{
    class Customer
    {
        private string _name;
        CheckingAccount cAccount;

        public Customer()
        {

        }
        public Customer(string name, CheckingAccount checkingAccount)
        {
            _name = name;
            cAccount = checkingAccount;
        }
        public override string ToString()
        {
            string Fulltimer = $"Name: {this._name} Account Number: {cAccount.AccountNumber} Account Balance: {cAccount.AccountBalance.ToString("$#.00")}";
            return Fulltimer;
        }
    }
}

/*
Changed the name of the variable as the instructor feedback suggested
*/

