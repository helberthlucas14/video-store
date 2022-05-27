using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStore.Application.ViewModels;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }




    }
}
