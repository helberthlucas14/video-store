using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateGenre;

namespace VideoStore.Application.Validators
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(p => p.Name)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Nome é obrigátorio!");
        }
    }
}
