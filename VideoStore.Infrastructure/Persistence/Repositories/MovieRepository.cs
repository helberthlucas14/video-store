using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Core.Pagination;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly VideoStoreDbContext _dbContext;

        public MovieRepository(VideoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Movie>> FindAllMovies(MovieParameters parameters)
        {
            return await _dbContext.Movies
                                .Include(m => m.Genres.OrderBy(g => g.Genre.Name)).ThenInclude(p => p.Genre)
                                .Include(m => m.Actors.OrderBy(a => a.People.Name)).ThenInclude(p => p.People)
                                .Include(m => m.Directors.OrderBy(d => d.People.Name)).ThenInclude(p => p.People)
                                .Include(m => m.ProductionComapanies.OrderBy(p => p.ProductionCompany.Name)).ThenInclude(p => p.ProductionCompany)
                                .Where(m => string.IsNullOrWhiteSpace(parameters.GenreFilter) ? true : m.Genres.Any(g => g.Genre.Name.Contains(parameters.GenreFilter)))
                                .Where(m => string.IsNullOrWhiteSpace(parameters.ActorFilter) ? true : m.Actors.Any(g => g.People.Name.Contains(parameters.ActorFilter)))
                                .Where(m => string.IsNullOrWhiteSpace(parameters.DirectorFilter) ? true : m.Directors.Any(g => g.People.Name.Contains(parameters.DirectorFilter)))
                                .Where(m => string.IsNullOrWhiteSpace(parameters.ProductionCompanyFilter) ? true : m.ProductionComapanies.Any(g => g.ProductionCompany.Name.Contains(parameters.ProductionCompanyFilter)))
                                .OrderBy(m => m.VoteAvarage)
                                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                                .Take(parameters.PageSize)
                                .ToListAsync();
        }


        public PagedList<Movie> GetAllAsync(MovieParameters parameters)
        {
            return PagedList<Movie>.ToPagedList(FindAllMovies(parameters).Result, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext
                                .Movies
                                .Include(p => p.Genres).ThenInclude(p => p.Genre)
                                .Include(p => p.Actors).ThenInclude(p => p.People)
                                .Include(p => p.Directors).ThenInclude(p => p.People)
                                .Include(p => p.ProductionComapanies).ThenInclude(p => p.ProductionCompany)
                                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
