using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands;
using VideoStore.Application.Commands.CreateProductionCompany;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Commands
{
    public class CreateProductionCompanyCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsok_Executed_ReturnProductionCompanyId()
        {
            var fixture = new Fixture();
            var productionCompanyRepository = new Mock<IProductionCompanyRepository>();

            var createProductionCompanyCommand = fixture.Create<CreateProductionCompanyCommand>();

            var createProductionCompanyCommandHandler = new CreateProductionCompanyCommandHandler(productionCompanyRepository.Object);

            var id = await createProductionCompanyCommandHandler.Handle(createProductionCompanyCommand, new System.Threading.CancellationToken());

            Assert.True(id >= 0);

            productionCompanyRepository.Verify(g => g.AddProductionCompanyAsync(It.IsAny<ProductionCompany>()), Times.Once);
        }
    }
}
