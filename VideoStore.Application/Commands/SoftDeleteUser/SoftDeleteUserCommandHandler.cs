using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Repositories;

namespace VideoStore.Application.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public SoftDeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new InvalidOperationException("Usuário não encontrado!");

            user.SoftDelete();
            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
