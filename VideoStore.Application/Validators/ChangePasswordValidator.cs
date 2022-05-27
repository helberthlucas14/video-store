﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoStore.Application.Commands.ChangePassword;

namespace VideoStore.Application.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.OldPassword)
                .Must(ValidPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, e um caractere especial!");

            RuleFor(p => p.NewPassword)
                .Must(ValidPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, e um caractere especial!");

        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}
