using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public static class MovieDirectorSeed
    {
        public static List<MovieDirector> Seed()
        {
            var movieProductions = new List<MovieDirector>()
            {
               new MovieDirector(1,1),
               new MovieDirector(2,2),
               new MovieDirector(3,3),
               new MovieDirector(4,5),
               new MovieDirector(5,5),
               new MovieDirector(6,6),
               new MovieDirector(7,7),
               new MovieDirector(8,8),
               new MovieDirector(9,9),
            };
            return movieProductions;
        }
    }
}
