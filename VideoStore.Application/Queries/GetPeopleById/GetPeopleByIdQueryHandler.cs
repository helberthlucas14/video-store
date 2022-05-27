using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetPeopleById
{
    public class GetPeopleByIdQueryHandler : IRequestHandler<GetPeopleByIdQuery, People>
    {
        private readonly IPeopleRepository _repository;

        public GetPeopleByIdQueryHandler(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<People> Handle(GetPeopleByIdQuery request, CancellationToken cancellationToken)
        {
            var people = await _repository.GetByIdAsync(request.Id);

            if (people == null)
                return null;

            return people;
        }
    }
}
