using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Application.ViewModels;

namespace VideoStore.Application.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public ChangePasswordCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new InvalidOperationException("Usuário não encontrado!");

            if (!user.Password.Equals(_authService.ComputeSha256Hash(request.OldPassword)))
                throw new InvalidOperationException("Senha Digitada e inválida!");

            var newPasswordHash = _authService.ComputeSha256Hash(request.NewPassword);
            user.UpdatePassword(newPasswordHash);
            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
