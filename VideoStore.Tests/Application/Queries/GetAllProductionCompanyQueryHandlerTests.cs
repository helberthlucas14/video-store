using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Queries.GetAllProductionCompany;
using VideoStore.Application.Repositories;
using Xunit;

namespace VideoStore.Tests.Application.Queries
{
    public class GetAllProductionCompanyQueryHandlerTests
    {
        [Fact]
        public async Task ShouldReturn_ThreeGenresExists_ReturnListProductionCompany()
        {
            var fixture = new Fixture();
            var productionsCompanies = fixture.Create<List<ProductionCompany>>();
            var tListPerson = fixture.Create<Task<List<ProductionCompany>>>();

            var productionCompanyRepository = new Mock<IProductionCompanyRepository>();

            var getAllPersonQueryHandler = new GetAllProductionCompanyQueryHandler(productionCompanyRepository.Object);
            productionCompanyRepository.Setup(pr => pr.GetAllAsync())
                           .Returns(tListPerson);

            var productionCompanyResult = await getAllPersonQueryHandler.Handle(new GetAllProductionCompanyQuery(), new System.Threading.CancellationToken());

            Assert.NotNull(productionCompanyResult);
            Assert.NotEmpty(productionCompanyResult);
            Assert.IsType<List<ProductionCompany>>(productionCompanyResult);
            Assert.Equal(3, productionCompanyResult.Count());
            productionCompanyRepository.Verify(mr => mr.GetAllAsync(), Times.Once);
        }
    }
}
