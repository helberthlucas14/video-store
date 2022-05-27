using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.SoftDeleteUser;

namespace VideoStore.Application.Validators
{
    public class SoftDeleteUserValidator : AbstractValidator<SoftDeleteUserCommand>
    {
        public SoftDeleteUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
