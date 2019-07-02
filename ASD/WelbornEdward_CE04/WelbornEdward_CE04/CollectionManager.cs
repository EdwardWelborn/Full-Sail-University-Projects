using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE04
{
    class CollectionManager
    {
        public List<Card> Cards { get; set; }
        public Dictionary<string, List<Card>> Collections { get; set; }
        public CollectionManager()
        {
            Cards = new List<Card>();
            Collections = new Dictionary<string, List<Card>>();
        }
    }
}
/*

*/

