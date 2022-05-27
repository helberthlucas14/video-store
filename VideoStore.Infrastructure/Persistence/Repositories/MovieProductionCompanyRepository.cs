using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class MovieProductionCompanyRepository : IMovieProductionCompanyRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public MovieProductionCompanyRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovieProductionCompanyAsync(MovieProductionCompany movieGenre)
        {
            await _dbContext.MovieProductionCompany.AddAsync(movieGenre);
            await _dbContext.SaveChangesAsync();
        }
    }
}
