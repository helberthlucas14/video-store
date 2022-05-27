using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Repositories;
using VideoStore.Application.ViewModels;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedList<UserViewModel>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _repository.GetAllAsync(request.usersParameters);
            var usersViewModel = users.Select(p => new UserViewModel(p)).ToList();
            return PagedList<UserViewModel>.ToPagedList(usersViewModel, request.usersParameters.PageNumber, request.usersParameters.PageSize);
        }
    }
}
