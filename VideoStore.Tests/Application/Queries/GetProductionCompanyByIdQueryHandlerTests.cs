using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetProductionCompanyById;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
   public  class GetProductionCompanyByIdQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_OneProductionCompanyExists_ReturnProductionCompany()
        {
            var fixture = new Fixture();
            var productionCompany = fixture.Create<Task<ProductionCompany>>();

            var productionCompanyRepository = new Mock<IProductionCompanyRepository>();

            var getPeopleByIdQuery = new GetProductionCompanyByIdQuery(productionCompany.Id);

            var getPeopleByIdQueryHandler = new GetProductionCompanyByIdQueryHandler(productionCompanyRepository.Object);
            productionCompanyRepository.Setup(pr => pr.GetByIdAsync(productionCompany.Id))
                           .Returns(productionCompany);

            var productionCompanyResult = await getPeopleByIdQueryHandler.Handle(getPeopleByIdQuery, new System.Threading.CancellationToken()); ;

            Assert.NotNull(productionCompanyResult);
            Assert.IsType<ProductionCompany>(productionCompanyResult);
        }
    }
}
