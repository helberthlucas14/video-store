using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetAllPersonQuery;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetAllPersonQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_ThreeGenresExists_ReturnListPerson()
        {
            var fixture = new Fixture();
            var person = fixture.Create<List<People>>();
            var tListPerson = fixture.Create<Task<List<People>>>();

            var peopleRepository = new Mock<IPeopleRepository>();

            var getAllPersonQueryHandler = new GetAllPersonQueryHandler(peopleRepository.Object);
            peopleRepository.Setup(pr => pr.GetAllAsync())
                           .Returns(tListPerson);

            var genreResult = await getAllPersonQueryHandler.Handle(new GetAllPersonQuery(), new System.Threading.CancellationToken());

            Assert.NotNull(genreResult);
            Assert.NotEmpty(genreResult);
            Assert.IsType<List<People>>(genreResult);
            Assert.Equal(3, genreResult.Count);
            peopleRepository.Verify(mr => mr.GetAllAsync(), Times.Once);
        }
    }
}
