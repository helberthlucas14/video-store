using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public class MovieGenre
    {
        public Movie Movie { get; private set; }
        public int MovieId { get; private set; }

        public Genre Genre { get; private set; }
        public int GenreId { get; private set; }

        public MovieGenre(int movieId, int genreId)
        {
            MovieId = movieId;
            GenreId = genreId;
        }
    }
}
