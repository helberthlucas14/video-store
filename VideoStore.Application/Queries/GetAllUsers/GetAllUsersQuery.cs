using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<PagedList<UserViewModel>>
    {
        public UserParameters usersParameters;

        public GetAllUsersQuery(UserParameters parameters)
        {
            usersParameters = parameters;
        }
    }
}
