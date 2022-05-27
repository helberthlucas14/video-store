using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Entities;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IGenreRepository _repository;

        public CreateGenreCommandHandler(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre(request.Name);
            await _repository.AddGenreAsync(genre);

            return genre.Id;
        }
    }
}
