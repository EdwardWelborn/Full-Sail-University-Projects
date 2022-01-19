using System;
using System.IO;
using System.Text;
using System.Threading;
using FSPG1;

namespace Tester
{
    public class Utility
    {
        public static string BuildFileName(int testNumber)
        {
            return "Lab" + testNumber + "Data.txt";
        }
        public static string BuildFileName(int testNumber, char version)
        {
            return "Lab" + testNumber + version + "Data.txt";
        }
        public static string BuildFileName(string path, int testNumber)
        {
            string retPath = path + "Lab" + testNumber + "Data-Evaluation.txt";
            return retPath;
        }

        public static StreamReader OpenFile(string fName) // throws FileNotFoundException { }
        {
            StreamReader retFile = null;
            try
            {
                retFile = new StreamReader(fName);
            }
            catch (FileNotFoundException nfe)
            {
                Console.WriteLine(nfe.Message);
                throw nfe;
            }
            return retFile;
        }

        public static string AlignOutput(int width, string str)
        {
            string result = str;
            for (int cntr = str.Length; cntr < width; cntr++)
            {
                result += " ";
            }
            return result;
        }

        public static char GetGrade(double x)
        {
            char g = '?';
            if (x >= 90 && x <= 100)
            {
                g = 'A';
            }
            else if (x >= 80 && x < 90)
            {
                g = 'B';
            }
            else if (x >= 73 && x < 80)
            {
                g = 'C';
            }
            else if (x >= 70 && x < 73)
            {
                g = 'D';
            }
            else if (x >= 0 && x < 70)
            {
                g = 'F';
            }

            return g;
        }

        public static double DoubleOp(double d1, double d2)
        {
            return d1 + d2;
        }

        public static int GetAction(int speed)
        {
            int action = 0;

            if (speed > 5 && speed <= 10)
            {
                action = 1;
            }
            else if (speed > 10 && speed <= 25)
            {
                action = 2;
            }
            else if (speed > 25)
            {
                action = 3;
            }
            return action;
        }

        public static Secret[] secrets =
        {
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret(),
            new Secret()
        };
        public static string[] acronyms = 
        {  
            "Greatest Of All Time",
            "As soon as possible",
            "Central Intelligence Agency",
            "laugh out loud",
            "shake my head",
            "Garbage in, Garbage out",
            "Fouled up beyond all recognition",
            "North American Free Trade Agreement",
            "United Nations",
            "North Atlantic Treaty Organization",
            "South East Asian Treaty Organization",
            "European Union",
            "Special Weapons And Tactics",
            "Date of Birth",
            "Unidentified Flying Object",
            "Frequently Asked Questions",
            "Doing Business As",
            "Keep Me Advised",
            "Professional Golfer's Association",
            "Major League Baseball",
            "National Basketball Association",
            "Professional Disk Golf Assocation",
            "American Psychological Assocation",
            "Sport Utility Vehicle",
            "Yet Another Hierarchical Officious Oracle",
            "Thomas A. Swift's Electric Rifle",
            "Self Contained Underwater Breathing Apparatus",
            "Sun Protection Factor",
            "Rocket Propelled Grenade",
            "Modus Operandi"
        };
        public static Pairs[] pairs =
        {
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs(),
            new Pairs()
        };
        public static Pt[] points = 
        {
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt(),
            new Pt()
        };
    }

    public class MyCir
    {
        float x,
              y,
              radius;

        public MyCir(float a, float b, float c)
        {
            x = a;
            y = b;
            radius = c;
        }

        public float GetX()
        {
            return x;
        }

        public float GetY()
        {
            return y;
        }

        public float GetRadius()
        {
            return radius;
        }

        public float GetArea()
        {
            return (float)Math.PI * radius * radius;
        }

        public float GetCircumference()
        {
            return (float)Math.PI * 2 * radius;
        }

        public bool Contains(float x2, float y2)
        {
            return radius > (float)Math.Sqrt(((x2 - x) * (x2 - x)) + ((y2 - y) * (y2 - y)));
        }
    }

    public class TC
    {
        private sbyte offset = 0;

        public TC(sbyte os)
        {
            offset = os;
        }

        public string Encode(string msg)
        {
            StringBuilder sb = new StringBuilder(msg);
            for (int i = 0; i < msg.Length; i++)
            {
                sb[i] = (char)(sb[i] + offset);
            }
            return sb.ToString();
        }

        public string Decode(string msg)
        {
            StringBuilder sb = new StringBuilder(msg);
            for (int i = 0; i < msg.Length; i++)
            {
                sb[i] = (char)(sb[i] - offset);
            }
            return sb.ToString();
        }
    }

    public class Pairs
    {
        private string[] s1 =
        {
            "Audacity",
            "Kitchen",
            "Denmark",
            "Agency",
            "Landmark",
            "Bibliography",
            "ICON",
            "Automobile",
            "Universe",
            "Kryptonite",
            "Cove",
            "Emotion",
            "Sidewalk",
            "Direction",
            "Region",
            "Tabernacle",
            "RPG",
            "Somber",
            "Denizen",
            "Clutch",
            "Illuminate",
            "Transpire",
            "Decadent",
            "Trapeze",
            "Menagerie",
            "Pontoon",
            "Admiral",
            "Schooner",
            "Frontier"
        };

        private string[] s2 =
        {
            "audacity",
            "KITCHEN",
            "denmark",
            "agency",
            "LANDMARK",
            "bibliography",
            "icon",
            "car",
            "space",
            "kryptonite",
            "bay",
            "emotion",
            "path",
            "Instruction",
            "area",
            "tabernacle",
            "rpg",
            "somber",
            "denizen",
            "clutch",
            "illuminate",
            "happen",
            "decadent",
            "trapeze",
            "zoo",
            "pontoon",
            "ADMIRAL",
            "schooner",
            "frontier"
        };
        public bool IgnoreIt { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        static Random rng = new Random();

        public Pairs()
        {
            IgnoreIt = rng.Next() % 2 == 0;
            int target = rng.Next(s1.Length);
            First = s1[target];
            Second = s2[target];
        }
    }

    public class Pt
    {
        public float x { get; set; }
        public float y { get; set; }
        public float r { get; set; }
        static Random rng = new Random();

        public Pt()
        {
            int multiplier = rng.Next(10,50);
            x = (float)Math.Round((rng.NextDouble() * multiplier),2);
            y = (float)Math.Round((rng.NextDouble() * multiplier),2);
            r = (float)Math.Round((rng.NextDouble() * multiplier),2);
        }
    }

    public class Secret
    {
        public string[] phrases =
        {
            "Tomorrow is another day",
            "Come what may",
            "A victim of circumstance",
            "John, Paul, George, Ringo",
            "Save it for a rainy day",
            "I like chocolate",
            "Wanna know a secret?",
            "It's all the same to me",
            "Full Sail rocks!",
            "Like a rolling stone",
            "Another brick in the all",
            "Carry on wayward son",
            "Heart of gold",
            "Dust in the wind",
            "Beast of burden",
            "The road not taken",
            "She walks in beauty",
            "Sailing to Byzantium",
            "Death Be Not Proud",
            "Singin' in The Rain",
            "Through the Looking Glass",
            "Some Like It Hot",
            "The Wizard of Oz",
            "Be calm and carry on"
        };

        public string Phrase { get; set; }
        public sbyte Shift { get; set; }
        public static Random rng = new Random();

        public Secret()
        {
            Phrase = phrases[rng.Next(phrases.Length)];
            if (rng.Next() % 2 == 0)
                Shift = (sbyte)(rng.Next(-5, 0));
            else
                Shift = (sbyte)(rng.Next(1, 6));
        }

    }
}
