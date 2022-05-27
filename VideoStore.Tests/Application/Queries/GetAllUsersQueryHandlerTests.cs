using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetAllUsers;
using VideoStore.Application.Repositories;
using VideoStore.Application.ViewModels;
using VideoStore.Core.Pagination;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
   public class GetAllUsersQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_ThreeMoviesExists_ReturnPagedListUserViewModel()
        {
            var fixture = new Fixture();
            var movies = fixture.Create<List<User>>();

            var userParameters = new UserParameters();
            var pagedListMovie = new PagedList<User>(movies, movies.Count, 0, 0);

            var movieRepository = new Mock<IUserRepository>();

            var getAllMoviesQuery = new GetAllUsersQuery(userParameters);

            var getAllMovieQueryHandler = new GetAllUsersQueryHandler(movieRepository.Object);
            movieRepository.Setup(pr => pr.GetAllAsync(userParameters))
                           .Returns(pagedListMovie);

            var usersPagedList = await getAllMovieQueryHandler.Handle(getAllMoviesQuery, new System.Threading.CancellationToken()); ;

            Assert.NotNull(usersPagedList);
            Assert.NotEmpty(usersPagedList);
            Assert.Equal(3, usersPagedList.TotalRecords);
            Assert.Equal(1, usersPagedList.TotalPages);
            Assert.Equal(50, usersPagedList.PageSize);
            Assert.IsType<PagedList<UserViewModel>>(usersPagedList);
            movieRepository.Verify(mr => mr.GetAllAsync(userParameters), Times.Once);
        }
    }
}
