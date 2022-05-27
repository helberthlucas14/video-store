using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.InputModels;

namespace VideoStore.Application.Validators
{
    public class MoveActorInputValidator : AbstractValidator<ActorInputModel>
    {
        public MoveActorInputValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().NotNull().WithMessage("Ator é obrigátorio!")
                 .GreaterThan(0).WithMessage("Ator é obrigátorio!");
        }
    }
}
