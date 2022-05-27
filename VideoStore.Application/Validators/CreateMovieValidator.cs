using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.CreateMovie;

namespace VideoStore.Application.Validators
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieValidator()
        {
            RuleFor(p => p.Title)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Nome é obrigátorio!");

            RuleForEach(x => x.Genres).SetValidator(new MovieGenreValidator());
            RuleForEach(x => x.Actors).SetValidator(new MoveActorInputValidator());
            RuleForEach(x => x.Directors).SetValidator(new MovieDirectorValidator());
            RuleForEach(x => x.ProductionCompanies).SetValidator(new MovieProductionValidator());
        }
    }
}
