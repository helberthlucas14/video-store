using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateMovie;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class CreateMovieCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsok_Executed_ReturnMovieId()
        {
            var fixture = new Fixture();
            var movieRepository = new Mock<IMovieRepository>();
            var movieGenreRepository = new Mock<IMovieGenreRepository>();
            var movieProductionRepository = new Mock<IMovieProductionCompanyRepository>();
            var movieActorRepository = new Mock<IMovieActorRepository>();
            var movieDirectorRepository = new Mock<IMovieDirectorRepository>();

            var createMovieCommand = fixture.Create<CreateMovieCommand>();

            var createMovieCommandHandler = new 
                CreateMovieCommandHandler(movieRepository.Object,
                movieGenreRepository.Object,movieProductionRepository.Object,
                movieActorRepository.Object, movieDirectorRepository.Object);

            var id = await createMovieCommandHandler.Handle(createMovieCommand, new System.Threading.CancellationToken());

            Assert.True(id >= 0);
            Assert.True(createMovieCommand.Genres.Count > 0);

            movieRepository.Verify(m => m.AddMovieAsync(It.IsAny<Movie>()), Times.Once);
        }

    }
}
