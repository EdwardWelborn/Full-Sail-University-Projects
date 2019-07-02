using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE05
{
    class Otter : Animal, ITrainable
    {
        bool _trainable = false;
        public Dictionary<string, string> Behaviors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string MakeNoise(string Species, string Treat)
        {
            string noise = $"The {Species} makes a playful squeek as it nibbles the {Treat}";

            return noise;
        }

        public string Perform(string signal)
        {
            throw new NotImplementedException();
        }

        public string Train(string signal, string behavior)
        {
            throw new NotImplementedException();
        }

        public Otter(string Species, int FoodConsumed, string Treat, bool Trainable) : base(Species, FoodConsumed, Treat)
        {
            string Perform = string.Empty;
            Dictionary<string, string> behavior = new Dictionary<string, string>();
            _trainable = Trainable;
        }
    }
}
