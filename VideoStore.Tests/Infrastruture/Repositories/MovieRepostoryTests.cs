using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Core.Pagination;
using VideoStore.Infrastructure.Persistence.Repositories;
using Xunit;

namespace VideoStore.Tests.Infrastruture.Repositories
{
    public class MovieRepostoryTests
    {
        MovieRepository movieRepository;

        public MovieRepostoryTests()
        {
            movieRepository = new MovieRepository(DbMockMovieTets.context);
        }

        [Fact]
        public void ShoulbeReturnAllMoviesWithoutFilter()
        {
            MovieParameters movieParameters = new MovieParameters();
            var movies = movieRepository.GetAllAsync(movieParameters);

            var espectedValue = 9;
            Assert.NotNull(movies);
            Assert.Equal(espectedValue, movies.Count());
        }

        [Fact]
        public void ShoulbeReturnListMovieOrderByGenreFilter()
        {
            MovieParameters movieParameters = new MovieParameters() { GenreFilter = "Terror" };
            var movies = movieRepository.GetAllAsync(movieParameters);
            var espectedValue = 5;

            Assert.NotNull(movies);
            Assert.Equal(espectedValue, movies.Count());
        }

        [Fact]
        public void ShoulbeReturnListMovieOrderByActorFilter()
        {
            MovieParameters movieParameters = new MovieParameters() { ActorFilter = "Tom Wall" };
            var movies = movieRepository.GetAllAsync(movieParameters);


            var espectedValue = 4;
            Assert.NotNull(movies);
            Assert.Equal(espectedValue, movies.Count());
        }

        [Fact]
        public void ShoulbeReturnListMovieOrderByDirectorFilter()
        {
            MovieParameters movieParameters = new MovieParameters() { DirectorFilter = "James" };
            var movies = movieRepository.GetAllAsync(movieParameters);

            var espectedValue = 1;
            
            Assert.NotNull(movies);
            Assert.Equal(espectedValue, movies.Count());
        }

        [Fact]
        public void ShoulbeReturnListMovieOrderByProductionCompanyFilter()
        {
            MovieParameters movieParameters = new MovieParameters() { ProductionCompanyFilter = "Netflix" };
            var movies = movieRepository.GetAllAsync(movieParameters);

            var espectedValue = 1;
            Assert.NotNull(movies);
            Assert.Equal(espectedValue, movies.Count());
        }
    }
}
