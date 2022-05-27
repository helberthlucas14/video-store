using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateUser;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {

        [Fact]
        public async Task InputDataIsok_Executed_ReturnUserId()
        {
            var fixture = new Fixture();
            var userRepository = new Mock<IUserRepository>();

            var createUserCommand = fixture.Create<CreateUserCommand>();

            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object);

            var id = await createUserCommandHandler.Handle(createUserCommand, new System.Threading.CancellationToken());

            Assert.True(id >= 0);

            userRepository.Verify(g => g.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
