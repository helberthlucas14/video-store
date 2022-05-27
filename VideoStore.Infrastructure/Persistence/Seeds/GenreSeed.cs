using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public static class GenreSeed
    {
        public static List<Genre> Seed()
        {
            var genres = new List<Genre>()
            {
               new Genre(1,"Romance"),
               new Genre(2,"Terror"),
               new Genre(3,"Comedia"),
               new Genre(4,"Action"),
               new Genre(5,"Fiction"),
               new Genre(6,"Adventure"),
               new Genre(7,"Documentary"),
            };
            return genres;
        }
    }
}
