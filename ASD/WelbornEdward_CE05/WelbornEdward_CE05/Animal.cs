using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE05
{
    abstract class Animal
    {
        private string _species = string.Empty;
        private int _foodConsumed = 0;
        private string _treat = string.Empty;

        public string Eat(string Species, string Treat)
        {
            string sEating = string.Empty;
            _species = Species;
            _treat = Treat;
            sEating = $"The {Species} ate a {Treat}";
            Console.WriteLine(sEating);
            return sEating;
        }
        virtual public string MakeNoise(string Species, string Treat)
        {
            string noise = $"The {Species} crunches away on the {Treat}";
            return noise;
        }
        private Animal()
        {

        }
        public Animal(string Species, int FoodConsumed, string Treat)
        {
            _species = Species;
            _foodConsumed = FoodConsumed;
            _treat = Treat;
        }
    }
 
}
/* Base Abstract Class:

Create a base abstract class named Animal which contains the following properties and fields:

A property named Species. This will hold the animal’s name (i.e. dolphin)
A field named _foodConsumed to keep track of how much food the animal has consumed.
A field named _treat used to store the name of the food this animal likes to eat as a treat. 
(like fish for dolphins, rats for snakes). This will need to be set to protected access since it will be used in subclasses to set the value unique to each animal.

*/
