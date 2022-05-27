using DevFreela.Application.Commands.LoginUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
