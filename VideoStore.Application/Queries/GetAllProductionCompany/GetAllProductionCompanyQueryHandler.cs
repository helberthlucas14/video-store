using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetAllProductionCompany
{
    public class GetAllProductionCompanyQueryHandler : IRequestHandler<GetAllProductionCompanyQuery, List<ProductionCompany>>
    {
        private readonly IProductionCompanyRepository _repository;

        public GetAllProductionCompanyQueryHandler(IProductionCompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductionCompany>> Handle(GetAllProductionCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
