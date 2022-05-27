using AutoFixture;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using VideoStore.Application.Commands.SoftDeleteUser;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class SoftDeleteUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnUnitValue()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();

            var user = fixture.Create<User>();

            userRepository.Setup(u => u.GetByIdAsync(user.Id))
                            .Returns(ConverMovieInTaskMovie(user));


            var softDeleteUserCommand = new SoftDeleteUserCommand(user.Id);

            var voteMovieCommandHandler = new SoftDeleteUserCommandHandler(userRepository.Object);

            var userResult = await voteMovieCommandHandler.Handle(softDeleteUserCommand, new System.Threading.CancellationToken());

            Assert.IsType<Unit>(userResult);
            Assert.False(user.Active);
            userRepository.Verify(g => g.GetByIdAsync(user.Id), Times.Once());
            userRepository.Verify(g => g.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task InputDataNotOk_Executed_ReturnInvaliOperation()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();

            var userId = 123231;

            var user = fixture.Create<User>();

            userRepository.Setup(u => u.GetByIdAsync(user.Id))
                            .Returns(ConverMovieInTaskMovie(user));

            var softDeleteUserCommand = new SoftDeleteUserCommand(userId);

            var softDeleteCommandHandler = new SoftDeleteUserCommandHandler(userRepository.Object);

            InvalidOperationException except = await Assert.ThrowsAsync<InvalidOperationException>(() => softDeleteCommandHandler.Handle(softDeleteUserCommand, new System.Threading.CancellationToken()));

            Assert.Equal("Usuário não encontrado!", except.Message);

            userRepository.Verify(g => g.GetByIdAsync(userId), Times.Once());
            userRepository.Verify(g => g.SaveChangesAsync(), Times.Never);
        }

        private Task<User> ConverMovieInTaskMovie(User user)
        {
            return Task.Run(() => user);
        }

    }
}
