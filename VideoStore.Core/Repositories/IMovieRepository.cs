using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Repositories
{
    public interface IMovieRepository
    {
        Task AddMovieAsync(Movie movie);
        Task<Movie> GetByIdAsync(int id);
        PagedList<Movie> GetAllAsync(MovieParameters parameters);
        Task SaveChangesAsync();
    }
}
