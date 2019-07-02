using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE05
{
    interface ITrainable
    {
        Dictionary<string, string> Behaviors { get; set; }
        string Perform(String signal);
        string Train(String signal, string behavior);
    
    }
}
/* Interface:

Create an interface called ITrainable which contains the following:

Dictionary<string, string> Behaviors{ get; set; }
string Perform(String signal);
string Train(String signal, string behavior);
Here is an explanation of each of the signatures above; 
(Note: The implementations are described below but should be in the class that implements the interface, not the interface itself):

Dictionary<string, string> Behaviors{ get; set; }
A dictionary property named Behaviors to be implemented in classes that implement ITrainable
The key (a string) is the signal the trainer/user will use to ask the animal to perform a behavior.
The value (a string) is the behavior the animal will perform when it sees the signal.
string Perform(String signal);    
A method named Perform to be implemented in classes that implement ITrainable.
Needs a string parameter
Fetch the behavior from the Behaviors dictionary based on the signal.
Should return a string describing how the animal performed the behavior in response to the signal.
string Train(String signal, string behavior);    
A method named Train to be implemented in classes that implement ITrainable.
Needs a string parameter that holds the signal sent by the user.
Will add the behavior to the Behaviors dictionary using the signal as the key
Should return a string describing how the animal has been trained and will respond to the specified signal.

The following methods:

An Eat method
Tracks how much food has been consumed.
If the animal eats over 4 times it should trigger the Poop() method and reset the _foodConsumed field.
It should return a string describing how the animal ate the food that looks like this: "The dolphin ate a herring”
A MakeNoise method
This will be overridden later and should be virtual.
This should return a string. This will be overriding later but should return a default string. (If your code is correctly created you should not see the default in your working application.)
A Poop method
This should not return anything.
This should write out to the console that the animal has pooped. For ex: "The dolphin pooped!”

*/
