using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.InputModels;

namespace VideoStore.Application.Validators
{
    public class MovieProductionValidator : AbstractValidator<ProductionCompanyInputModel>
    {
        public MovieProductionValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().NotNull().WithMessage("Produção é obrigátorio!")
                .GreaterThan(0).WithMessage("Produção é obrigátorio!");
        }
    }
}
