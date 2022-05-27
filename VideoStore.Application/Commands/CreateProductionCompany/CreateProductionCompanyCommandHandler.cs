using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.CreateProductionCompany
{
    public class CreateProductionCompanyCommandHandler : IRequestHandler<CreateProductionCompanyCommand, int>
    {
        private readonly IProductionCompanyRepository _repository;

        public CreateProductionCompanyCommandHandler(IProductionCompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductionCompanyCommand request, CancellationToken cancellationToken)
        {
            var productionCompany = new ProductionCompany(request.Name);
            await _repository.AddProductionCompanyAsync(productionCompany);

            return productionCompany.Id;
        }

    }
}
