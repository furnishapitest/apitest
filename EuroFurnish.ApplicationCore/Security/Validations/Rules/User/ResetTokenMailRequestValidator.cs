using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Security.Validations.Rules.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Security.Validations.Rules.User
{
    public class ResetTokenMailRequestValidator : BaseAbstractValidator<ResetTokenMailDto>
    {
        public ResetTokenMailRequestValidator()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress();
        }
    }
}
