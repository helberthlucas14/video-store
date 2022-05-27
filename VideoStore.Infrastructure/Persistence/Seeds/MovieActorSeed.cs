using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public class MovieActorSeed
    {
        public static List<MovieActor> Seed()
        {
            var moviesActors = new List<MovieActor>()
            {
               new MovieActor(1,1),
               new MovieActor(1,2),
               new MovieActor(1,3),
               new MovieActor(1,5),

               new MovieActor(2,14),
               new MovieActor(2,13),
               new MovieActor(2,12),
               new MovieActor(2,11),
               new MovieActor(2,10),

               new MovieActor(3,8),
               new MovieActor(3,9),
               new MovieActor(3,1),

               new MovieActor(4,4),
               new MovieActor(4,5),
               new MovieActor(4,8),
               new MovieActor(4,9),

               new MovieActor(5,6),
               new MovieActor(5,1),
               new MovieActor(5,3),

               new MovieActor(6,2),
               new MovieActor(6,1),

               new MovieActor(7,3),
               new MovieActor(7,6),

                new MovieActor(8,13),
               new MovieActor(8,11),

               new MovieActor(9,14),
               new MovieActor(9,12),
            };
            return moviesActors;
        }
    }
}
