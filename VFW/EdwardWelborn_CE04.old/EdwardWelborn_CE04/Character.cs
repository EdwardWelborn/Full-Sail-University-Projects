using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE04
{
    public class Character
    {
        public string Name { get; set; }
        public string Gender{ get; set; }
        public string Level { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public string Role { get; set; }
        public bool Mentor { get; set; }

        public override string ToString()
        {
            string returnString = $"{Class}: {Name}";
            return returnString;
        }
    }
}
