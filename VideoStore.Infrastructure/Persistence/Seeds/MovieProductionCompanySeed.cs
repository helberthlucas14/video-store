using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public static class MovieProductionCompanySeed
    {
        public static List<MovieProductionCompany> Seed()
        {
            var movieProductions = new List<MovieProductionCompany>()
            {
               new MovieProductionCompany(1,1),
               new MovieProductionCompany(2,2),
               new MovieProductionCompany(3,3),
               new MovieProductionCompany(4,5),
               new MovieProductionCompany(5,5),
               new MovieProductionCompany(6,6),
               new MovieProductionCompany(7,7),
               new MovieProductionCompany(8,8),
               new MovieProductionCompany(9,9),
            };
            return movieProductions;
        }
    }
}
