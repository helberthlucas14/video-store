using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetAllMovie;
using VideoStore.Application.Repositories;
using VideoStore.Application.ViewModels;
using VideoStore.Core.Pagination;
using VideoStore.Tests.Infrastruture;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetAllMovieQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_ThreeMoviesExists_ReturnPagedListMovieViewModel()
        {
            var fixture = new Fixture();
            var movies = fixture.Create<List<Movie>>();

            var movieParameters = new MovieParameters();
            var pagedListMovie = new PagedList<Movie>(movies, movies.Count, 0, 0);

            var movieRepository = new Mock<IMovieRepository>();

            var getAllMoviesQuery = new GetAllMovieQuery(movieParameters);

            var getAllMovieQueryHandler = new GetAllMovieQueryHandler(movieRepository.Object);
            movieRepository.Setup(pr => pr.GetAllAsync(movieParameters))
                           .Returns(pagedListMovie);

            var moviesPagedList = await getAllMovieQueryHandler.Handle(getAllMoviesQuery, new System.Threading.CancellationToken()); ;

            Assert.NotNull(moviesPagedList);
            Assert.NotEmpty(moviesPagedList);
            Assert.Equal(3, moviesPagedList.TotalRecords);
            Assert.Equal(1, moviesPagedList.TotalPages);
            Assert.Equal(50, moviesPagedList.PageSize);
            Assert.IsType<PagedList<MovieViewModel>>(moviesPagedList);
            movieRepository.Verify(mr => mr.GetAllAsync(movieParameters), Times.Once);
        }
    }
}
