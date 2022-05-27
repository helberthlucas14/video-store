using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public MovieGenreRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovieGenreAsync(MovieGenre movieGenre)
        {
            await _dbContext.MovieGenre.AddAsync(movieGenre);
            await _dbContext.SaveChangesAsync();
        }

    }
}