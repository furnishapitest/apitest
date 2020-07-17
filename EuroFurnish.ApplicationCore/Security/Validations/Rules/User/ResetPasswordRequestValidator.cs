using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Security.Validations.Rules.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Security.Validations.Rules.User
{
    public class ResetPasswordRequestValidator : BaseAbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(p => p.ConfirmPassword).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty().NotNull().Equal(x => x.ConfirmPassword);
        }
    }
}
