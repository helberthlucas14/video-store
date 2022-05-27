using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetMovieById;
using VideoStore.Application.Repositories;
using VideoStore.Application.ViewModels;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetMovieByIdQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_OneMovieExists_ReturnMovieViewModel()
        {
            var fixture = new Fixture();
            var newMovie = fixture.Create<Task<Movie>>();

            var movieRepository = new Mock<IMovieRepository>();

            var getMovieByIdQuery = new GetMovieByIdQuery(newMovie.Id);

            var getMovieByIdQueryHandler = new GetMovieByIdQueryHandler(movieRepository.Object);
            movieRepository.Setup(pr => pr.GetByIdAsync(newMovie.Id))
                           .Returns(newMovie);

            var movieViewModel = await getMovieByIdQueryHandler.Handle(getMovieByIdQuery, new System.Threading.CancellationToken()); ;

            Assert.NotNull(movieViewModel);
            Assert.IsType<MovieViewModel>(movieViewModel);
        }
    }
}
