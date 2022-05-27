﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStore.Application.Repositories;
using VideoStore.Application.Service.Auth;
using VideoStore.Application.ViewModels;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            return new LoginUserViewModel(user.Email, token);
        }
    }
}
