using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class MovieActor
    {
        public int MovieId { get; private set; }
        public Movie Movie { get; private set; }

        public People People { get; private set; }
        public int PeopleId { get; private set; }

        public MovieActor(int movieId, int peopleId)
        {
            MovieId = movieId;
            PeopleId = peopleId;
        }
    }
}
