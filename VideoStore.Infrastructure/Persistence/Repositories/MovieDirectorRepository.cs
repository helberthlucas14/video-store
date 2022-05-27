using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class MovieDirectorRepository : IMovieDirectorRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public MovieDirectorRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovieDirectorAsync(MovieDirector movieDirector)
        {
            await _dbContext.MovieDirector.AddAsync(movieDirector);
            await _dbContext.SaveChangesAsync();
        }

    }
}
