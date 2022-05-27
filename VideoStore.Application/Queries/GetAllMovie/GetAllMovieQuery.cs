using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Queries.GetAllMovie
{
    public class GetAllMovieQuery : IRequest<PagedList<MovieViewModel>>
    {
        public MovieParameters movieParameters;

        public GetAllMovieQuery(MovieParameters parameters)
        {
            movieParameters = parameters;
        }
    }
}
