using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE01
{
    class CheckingAccount : Customer
    {
        // Change to private per feedback
        private uint _iAccountNumber = 0;
        private decimal _decAccountBalance = 0;
        public CheckingAccount()
        {

        }
        public uint AccountNumber
        {
            get
            {
                return _iAccountNumber;
            }
            set
            {
                if(_iAccountNumber < 0)
                {
                    _iAccountNumber = 0;
                }
                else
                {
                    _iAccountNumber = value;
                }
                
            }
        }
        public decimal AccountBalance
        {
            get
            {
                return _decAccountBalance;
            }
            set
            {
                if (_decAccountBalance < 0)
                {
                    _decAccountBalance = 0;
                }
                else
                {
                    _decAccountBalance = value;
                }
            }
        }
        public CheckingAccount(uint AccountNumber, decimal AccountBalance)
        {
            _decAccountBalance = AccountBalance;
            _iAccountNumber = AccountNumber;
        }
        /*      Removed per feedback
                public void GetAccountInformation(uint iAccountNumber, decimal decAccountBalance)
                {
                    _iAccountNumber = iAccountNumber;
                    _decAccountBalance = decAccountBalance;
                }
        */
    public override string ToString()
    {
        string Fulltimer = $"{this.AccountNumber} {this.AccountBalance}";
        return Fulltimer;
    }
    }

}

/*
 * Constructors

CheckingAccount needs a constructor that takes an int parameter and a decimal parameter
These parameters should be assigned to the appropriate fields.

 */
