using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetAllGenre
{
    public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQuery, List<Genre>>
    {
        private readonly IGenreRepository _repository;

        public GetAllGenreQueryHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Genre>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
