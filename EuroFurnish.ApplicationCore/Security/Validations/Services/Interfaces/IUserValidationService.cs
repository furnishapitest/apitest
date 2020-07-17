using EuroFurnish.ApplicationCore.DtoModels.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Security.Validations.Services.Interfaces
{
    public interface IUserValidationService
    {
        IValidator<UserRegisterDto> UserRegisterRule { get; }
        IValidator<UserLoginDto> UserLoginRule { get; }
        IValidator<ResetTokenMailDto> ResetPasswordMailRule { get; }
        IValidator<ResetPasswordDto> ResetPasswordRule { get; }
    }
}
