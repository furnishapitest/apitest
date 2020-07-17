using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Security.Validations.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Security.Validations.Services.Abstracts
{
    public class UserValidationService : IUserValidationService
    {
        public IValidator<UserRegisterDto> UserRegisterRule => HttpHelper.GetService<IValidator<UserRegisterDto>>();
        public IValidator<UserLoginDto> UserLoginRule => HttpHelper.GetService<IValidator<UserLoginDto>>();
        public IValidator<ResetTokenMailDto> ResetPasswordMailRule => HttpHelper.GetService<IValidator<ResetTokenMailDto>>();
        public IValidator<ResetPasswordDto> ResetPasswordRule => HttpHelper.GetService<IValidator<ResetPasswordDto>>();
    }
}
