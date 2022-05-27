using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;
using VideoStore.Application.Repositories;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Queries.GetAllMovie
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, PagedList<MovieViewModel>>
    {
        private readonly IMovieRepository _repository;

        public GetAllMovieQueryHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<MovieViewModel>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {
            var movies = _repository.GetAllAsync(request.movieParameters);

            var moviesViewModel = movies.Select(p => new MovieViewModel(p)).ToList();

            return PagedList<MovieViewModel>.ToPagedList(moviesViewModel, request.movieParameters.PageNumber, request.movieParameters.PageSize);
        }
    }
}
