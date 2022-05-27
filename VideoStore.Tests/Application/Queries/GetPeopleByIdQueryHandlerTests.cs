using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetPeopleById;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetPeopleByIdQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_OnePeopleExists_ReturnPeople()
        {
            var fixture = new Fixture();
            var people = fixture.Create<Task<People>>();

            var peopleRepository = new Mock<IPeopleRepository>();

            var getPeopleByIdQuery = new GetPeopleByIdQuery(people.Id);

            var getPeopleByIdQueryHandler = new GetPeopleByIdQueryHandler(peopleRepository.Object);
            peopleRepository.Setup(pr => pr.GetByIdAsync(people.Id))
                           .Returns(people);

            var peopleResult = await getPeopleByIdQueryHandler.Handle(getPeopleByIdQuery, new System.Threading.CancellationToken()); ;

            Assert.NotNull(peopleResult);
            Assert.IsType<People>(peopleResult);
        }
    }
}
