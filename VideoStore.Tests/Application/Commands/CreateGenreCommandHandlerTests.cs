using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateGenre;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class CreateGenreCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsok_Executed_ReturnGenreId()
        {
            var fixture = new Fixture();
            var genreRepository = new Mock<IGenreRepository>();

            var createGenreCommand = fixture.Create<CreateGenreCommand>();

            var createMovieCommandHandler = new CreateGenreCommandHandler(genreRepository.Object);

            var id = await createMovieCommandHandler.Handle(createGenreCommand, new System.Threading.CancellationToken());

            Assert.True(id >= 0);

            genreRepository.Verify(g => g.AddGenreAsync(It.IsAny<Genre>()), Times.Once);
        }
    }
}
