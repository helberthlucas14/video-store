using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Infrastructure.Persistence;
using VideoStore.Infrastructure.Persistence.Seeds;

namespace VideoStore.Tests.Infrastruture
{
    public static class DbMockMovieTets
    {
        public static readonly VideoStoreDbContext context;

        static DbMockMovieTets()
        {
            var options = new DbContextOptionsBuilder<VideoStoreDbContext>()
                                 .UseInMemoryDatabase("VideoStore")
                                 .Options;

            context = new VideoStoreDbContext(options);
            Seed(context);

        }


        private static void Seed(VideoStoreDbContext context)
        {
            context.Genres.AddRange(GenreSeed.Seed());
            context.Person.AddRange(PeopleSeed.Seed());
            context.ProductionCompanies.AddRange(ProductionCompanySeed.Seed());
            context.Movies.AddRange(MovieSeed.Seed());
            context.MovieGenre.AddRange(MovieGenreSeed.Seed());
            context.MovieActor.AddRange(MovieActorSeed.Seed());
            context.MovieDirector.AddRange(MovieDirectorSeed.Seed());
            context.MovieProductionCompany.AddRange(MovieProductionCompanySeed.Seed());
            context.SaveChanges();
        }
    }
}