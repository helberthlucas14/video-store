using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class MovieDirector 
    {
        public int MovieId { get; private set; }
        public Movie Movie { get; private set; }

        public People People { get; private set; }
        public int PeopleId { get; private set; }

        public MovieDirector(int movieId, int peopleId)
        {
            MovieId = movieId;
            PeopleId = peopleId;
        }
    }
}
