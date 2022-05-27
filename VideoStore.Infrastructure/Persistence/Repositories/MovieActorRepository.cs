using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public MovieActorRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovieActorAsync(MovieActor movieActor)
        {
            await _dbContext.MovieActor.AddAsync(movieActor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
