using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE05
{
    class Eagle : Animal
    {
        bool _trainable = false;

        public override string MakeNoise(string Species, string Treat)
        {
            string noise = $"The {Species} make a loud screach after eating the {Treat}";

            return noise;
        }
        public Eagle(string Species, int FoodConsumed, string Treat, bool Trainable) : base(Species, FoodConsumed, Treat)
        {
            _trainable = Trainable;
        }
    }
}
