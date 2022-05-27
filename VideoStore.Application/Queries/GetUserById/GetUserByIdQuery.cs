using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;

namespace VideoStore.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; private set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
