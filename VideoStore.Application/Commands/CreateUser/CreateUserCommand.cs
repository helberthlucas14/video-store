using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get;  set; }
        public string Password { get;  set; }
        public string Email { get;  set; }
        public string Role { get;  set; }

        public CreateUserCommand(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
}
