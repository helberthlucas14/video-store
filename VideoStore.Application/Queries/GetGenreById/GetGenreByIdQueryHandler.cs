using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre>
    {

        private readonly IGenreRepository _repository;

        public GetGenreByIdQueryHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetByIdAsync(request.Id);

            if (genre == null)
                return null;

            return genre;
        }
    }
}
