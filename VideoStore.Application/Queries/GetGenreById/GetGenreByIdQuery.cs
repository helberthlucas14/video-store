using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Queries.GetGenreById
{
    public class GetGenreByIdQuery : IRequest<Genre>
    {
        public int Id { get; private set; }

        public GetGenreByIdQuery(int id)
        {
            Id = id;
        }
    }
}
