using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.VoteMovie;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using VideoStore.Application.ViewModels;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class VoteMovieCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnMovieViewModel()
        {
            var fixture = new Fixture();
            var movieRepository = new Mock<IMovieRepository>();

            var movie = fixture.Create<Movie>();

            movieRepository.Setup(u => u.GetByIdAsync(movie.Id))
                            .Returns(ConverMovieInTaskMovie(movie));

            var voteMovieCommand = new VoteMovieCommand(movie.Id, 2);
            var expctedMovieVoteCount = movie.VoteCount + 1;

            var voteMovieCommandHandler = new VoteMovieCommandHandler(movieRepository.Object);

            var movieVoteResult = await voteMovieCommandHandler.Handle(voteMovieCommand, new System.Threading.CancellationToken());

            Assert.IsType<MovieViewModel>(movieVoteResult);
            Assert.Equal(expctedMovieVoteCount, movieVoteResult.VoteCount);

            movieRepository.Verify(g => g.GetByIdAsync(movie.Id), Times.Once());
            movieRepository.Verify(g => g.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task MovieNull_Executed_ReturnInvalidOperation()
        {
            var fixture = new Fixture();
            var movieRepository = new Mock<IMovieRepository>();

            var movie = fixture.Create<Movie>();

            movieRepository.Setup(u => u.GetByIdAsync(movie.Id))
                            .Returns(ConverMovieInTaskMovie(movie));

            var voteMovieCommand = new VoteMovieCommand(2, 3);

            var voteMovieCommandHandler = new VoteMovieCommandHandler(movieRepository.Object);

            InvalidOperationException except = await Assert.ThrowsAsync<InvalidOperationException>(() => voteMovieCommandHandler.Handle(voteMovieCommand, new System.Threading.CancellationToken()));

            Assert.Equal("Filme não encontrado!", except.Message);

            movieRepository.Verify(g => g.GetByIdAsync(2), Times.Once());
            movieRepository.Verify(g => g.SaveChangesAsync(), Times.Never);
        }

        private Task<Movie> ConverMovieInTaskMovie(Movie movie)
        {
            return Task.Run(() => movie);
        }
    }
}
