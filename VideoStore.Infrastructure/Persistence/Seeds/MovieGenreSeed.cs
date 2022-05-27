using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public static class MovieGenreSeed
    {
        public static List<MovieGenre> Seed()
        {
            var movieGenre = new List<MovieGenre>()
            {
               new MovieGenre(1,1),
               new MovieGenre(1,2),

               new MovieGenre(2,2),
               new MovieGenre(2,3),
               
                new MovieGenre(3,6),
               
                new MovieGenre(4,5),
                new MovieGenre(4,1),
               
                new MovieGenre(5,2),
                new MovieGenre(5,5),
               
                new MovieGenre(6,7),
                new MovieGenre(6,2),
                new MovieGenre(6,1),
               
                new MovieGenre(7,6),
                new MovieGenre(7,4),
               
                new MovieGenre(8,4),
                new MovieGenre(8,3),
               
                new MovieGenre(9,2),
                new MovieGenre(9,5),
                new MovieGenre(9,7),
            };
            return movieGenre;
        }
    }
}
