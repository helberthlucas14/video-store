using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Queries.GetAllPersonQuery
{
    public class GetAllPersonQuery : IRequest<List<People>>
    {
        public GetAllPersonQuery()
        {
        }

    }
}
