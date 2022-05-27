using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands;
using VideoStore.Application.Commands.CreatePeople;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
   public  class CreatePeopleCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsok_Executed_ReturnPeopleId()
        {
            var fixture = new Fixture();
            var peopleRepository = new Mock<IPeopleRepository>();

            var people = fixture.Create<People>();
            var createPeopleCommand = fixture.Create<CreatePeopleCommand>();

            var createPeopleCommandHandler = new CreatePeopleCommandHandler(peopleRepository.Object);

            var id = await createPeopleCommandHandler.Handle(createPeopleCommand, new System.Threading.CancellationToken());

            Assert.True(id >= 0);

            peopleRepository.Verify(g => g.AddPeopleAsync(It.IsAny<People>()), Times.Once);
        }
    }
}
