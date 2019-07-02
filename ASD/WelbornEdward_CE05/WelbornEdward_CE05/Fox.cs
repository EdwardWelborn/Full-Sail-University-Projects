using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE05
{
    class Fox : Animal, ITrainable
    {
        bool _trainable = true;
        public Dictionary<string, string> Behaviors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string MakeNoise(string Species, string Treat)
        {
            string noise = $"Nobody knows what the {Species} says as it nibbles on the {Treat}";

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

        public Fox(string Species, int FoodConsumed, string Treat, bool Trainable) : base(Species, FoodConsumed, Treat)
        {
            string Perform = string.Empty;
            Dictionary<string, string> behavior = new Dictionary<string, string>();
            _trainable = Trainable;
        }
    }
}
