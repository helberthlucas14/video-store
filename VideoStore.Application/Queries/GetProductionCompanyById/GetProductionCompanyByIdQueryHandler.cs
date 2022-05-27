using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetProductionCompanyById
{
    public class GetProductionCompanyByIdQueryHandler : IRequestHandler<GetProductionCompanyByIdQuery, ProductionCompany>
    {
        private readonly IProductionCompanyRepository _repository;

        public GetProductionCompanyByIdQueryHandler(IProductionCompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductionCompany> Handle(GetProductionCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var productionCompany = await _repository.GetByIdAsync(request.Id);

            if (productionCompany == null)
                return null;

            return productionCompany;
        }
    }
}
