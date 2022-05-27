using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.ViewModels;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository dbContext)
        {
            _repository = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
                return null;

            return new UserViewModel(user);
        }
    }
}
