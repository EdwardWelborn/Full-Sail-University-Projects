using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervenecJustin_CodeExercise01
{
   public class MovieInfo
    {
       private string title;
       private string genre;
       private decimal releaseYear;
       private string leadActor;

        public string Title { get => title; set => title = value; }
        public string Genre { get => genre; set => genre = value; }
        public decimal ReleaseYear { get => releaseYear; set => releaseYear = value; }
        public string LeadActor { get => leadActor; set => leadActor = value; }

        public override string ToString()
        {
            return $"{title} {genre}";
        }
    }
}
