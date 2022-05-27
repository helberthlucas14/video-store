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
    public class GenreRepository : IGenreRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public GenreRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _dbContext.Genres.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
