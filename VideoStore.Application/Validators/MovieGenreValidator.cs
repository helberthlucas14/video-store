using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.InputModels;

namespace VideoStore.Application.Validators
{
    public class MovieGenreValidator : AbstractValidator<GenreInputModel>
    {
        public MovieGenreValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().NotNull().WithMessage("Genero é obrigátorio!")
                 .GreaterThan(0).WithMessage("Genero é obrigátorio!");
        }
    }
}
