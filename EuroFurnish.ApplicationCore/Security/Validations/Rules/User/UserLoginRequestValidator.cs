using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Security.Validations.Rules.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Security.Validations.Rules.User
{
    public class UserLoginRequestValidator : BaseAbstractValidator<UserLoginDto>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(p => p.Password).NotEmpty().NotNull().MinimumLength(6);
        }
    }
}
