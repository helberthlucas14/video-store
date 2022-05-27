using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public static class MovieSeed
    {
        public static List<Movie> Seed()
        {
            var movies = new List<Movie>()
            {
               new Movie(1,"Movie Best 1","",0,0,3),
               new Movie(2,"Movie Best 2","",0,0,4),
               new Movie(3,"Movie Best 3","",0,0,1),
               new Movie(4,"Movie Best 4","",0,0,2),
               new Movie(5,"Movie Best 5","",0,0,8),
               new Movie(6,"Movie Best 6","",0,0,2),
               new Movie(7,"Movie Best 7","",0,0,5),
               new Movie(8,"Movie Best 8","",0,0,2),
               new Movie(9,"Movie Best 9","",0,0,1),
            };
            return movies;
        }
    }
}
