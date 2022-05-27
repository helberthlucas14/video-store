using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetAllGenre;
using VideoStore.Application.Queries.GetAllMovie;
using VideoStore.Application.Queries.GetGenreById;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetAllGenreQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_ThreeGenresExists_ReturnListGenre()
        {
            var fixture = new Fixture();
            var genres = fixture.Create<List<Genre>>();
            var tgenres = fixture.Create<Task<List<Genre>>>();

            var genreRepository = new Mock<IGenreRepository>();

            var getAllMovieQueryHandler = new GetAllGenreQueryHandler(genreRepository.Object);
            genreRepository.Setup(pr => pr.GetAllAsync())
                           .Returns(tgenres);

            var genreResult = await getAllMovieQueryHandler.Handle(new GetAllGenreQuery(), new System.Threading.CancellationToken()); ;

            Assert.NotNull(genreResult);
            Assert.NotEmpty(genreResult);
            Assert.IsType<List<Genre>>(genreResult);
            Assert.Equal(3, genreResult.Count);
            genreRepository.Verify(mr => mr.GetAllAsync(), Times.Once);
        }
    }
}
