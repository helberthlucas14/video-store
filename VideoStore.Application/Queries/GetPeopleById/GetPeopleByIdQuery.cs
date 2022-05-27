using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Queries.GetPeopleById
{
    public class GetPeopleByIdQuery : IRequest<People>
    {
        public int Id { get; set; }
        
        public GetPeopleByIdQuery(int id)
        {
            Id = id;
        }

    }
}
