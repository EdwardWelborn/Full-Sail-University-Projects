using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteroJoshua_CE02
{
    class Series
    {
        public string Title;

        public string ReleaseDate;

        public string Publisher;

        public string Author;

        public string Director;

        public string Genre;

        public int Icon;

        public override string ToString()
        {
            if (Title.Length > 10)
            {
                return $"{Title.Substring(0, 10)}...";
            }
            else
            {
                return $"{Title}";
            }
        }
    }
}
