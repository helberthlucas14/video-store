using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Core.Pagination;

namespace VideoStore.Application.Validators
{
    public class GetAllMovieValidator : AbstractValidator<MovieParameters>
    {
        public GetAllMovieValidator()
        {
            RuleFor(p => p.PageNumber).GreaterThan(0);
            RuleFor(p => p.PageSize).GreaterThan(0);
            RuleFor(p => p.PageSize).GreaterThan(0);
        }
    }
}
