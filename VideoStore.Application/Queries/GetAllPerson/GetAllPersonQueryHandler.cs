using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetAllPersonQuery
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<People>>
    {
        private readonly IPeopleRepository _repository;

        public GetAllPersonQueryHandler(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<People>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
