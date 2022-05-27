using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.InputModels;

namespace VideoStore.Application.Validators
{
    public class MovieDirectorValidator : AbstractValidator<DirectorInputModel>
    {
        public MovieDirectorValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().NotNull().WithMessage("Diretor é obrigátorio!")
                 .GreaterThan(0).WithMessage("Diretor é obrigátorio!");
        }
    }
}
