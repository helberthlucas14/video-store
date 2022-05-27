using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.CreatePeople
{
    public class CreatePeopleCommandHandler : IRequestHandler<CreatePeopleCommand, int>
    {
        private readonly IPeopleRepository _repository;

        public CreatePeopleCommandHandler(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            var people = new People(request.Name, request.Biography, request.Gender, request.Birthday);
            await _repository.AddPeopleAsync(people);

            return people.Id;
        }
    }
}
