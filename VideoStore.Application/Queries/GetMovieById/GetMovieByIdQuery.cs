using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;

namespace VideoStore.Application.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<MovieViewModel>
    {
        public int Id { get; private set; }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }

    }
}
