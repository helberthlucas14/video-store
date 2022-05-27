using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Commands.VoteMovie;

namespace VideoStore.Application.Validators
{
    public class VoteMovieValidator : AbstractValidator<VoteMovieCommand>
    {
        public VoteMovieValidator()
        {
            RuleFor(p => p.MovieId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Filme deve ser informado!");

            RuleFor(p => p.Vote)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(4);
        }
    }
}
