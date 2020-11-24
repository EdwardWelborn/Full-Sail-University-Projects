using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervenecJustin_CodeExercise01
{
   public class NotWatched
    {
        private string titleNW;
        private string genreNW;
        private decimal releaseYearNW;
        private string leadActorNW;

        public string TitleNW { get => titleNW; set => titleNW = value; }
        public string GenreNW { get => genreNW; set => genreNW = value; }
        public decimal ReleaseYearNW { get => releaseYearNW; set => releaseYearNW = value; }
        public string LeadActorNW { get => leadActorNW; set => leadActorNW = value; }

        public override string ToString()
        {
            return $"{TitleNW} {GenreNW} {ReleaseYearNW} {LeadActorNW}";
        }
    }
}
