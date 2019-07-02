using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE04
{
    class Card
    {
        public string CardName { get; set; }
        public string CardDescription { get; set; }
        public decimal CardValue { get; set; }

        public override string ToString()
        {
            string sCardString = $"{CardName,-30} {CardDescription,-45} {CardValue}";
            return sCardString;
        }
    }
}
/*
 
*/

