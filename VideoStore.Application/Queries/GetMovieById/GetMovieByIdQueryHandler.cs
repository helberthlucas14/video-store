using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieViewModel>
    {
        private readonly IMovieRepository _repository;

        public GetMovieByIdQueryHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieViewModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _repository.GetByIdAsync(request.Id);

            if (movie == null)
                return null;

            return new MovieViewModel(movie.Id, movie.Title, movie.Overview, movie.VoteCount,
                                      movie.VoteAvarage, movie.Popularity, movie.Genres, movie.Actors,
                                      movie.Directors, movie.ProductionComapanies);
        }
    }
}
