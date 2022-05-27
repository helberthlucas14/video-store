using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public SoftDeleteUserCommand(int id)
        {
            Id = id;
        }

    }
}
