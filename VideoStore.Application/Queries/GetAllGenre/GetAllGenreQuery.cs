using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Core.Pagination;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Queries.GetAllGenre
{
    public class GetAllGenreQuery : QueryStringParameters, IRequest<List<Genre>>
    {
        public GetAllGenreQuery()
        {
        }
    }
}
