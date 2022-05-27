using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetUserById;
using VideoStore.Application.Repositories;
using VideoStore.Application.ViewModels;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_OneUserExists_ReturnUserViewModel()
        {
            var fixture = new Fixture();
            var user = fixture.Create<Task<User>>();

            var userRepository = new Mock<IUserRepository>();

            var getUserByIdQuery = new GetUserByIdQuery(user.Id);

            var getPeopleByIdQueryHandler = new GetUserByIdQueryHandler(userRepository.Object);
            userRepository.Setup(pr => pr.GetByIdAsync(user.Id))
                           .Returns(user);

            var userResult = await getPeopleByIdQueryHandler.Handle(getUserByIdQuery, new System.Threading.CancellationToken()); ;

            Assert.NotNull(userResult);
            Assert.IsType<UserViewModel>(userResult);
        }
    }
}
