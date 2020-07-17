using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.BusinessServices.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> SignUp(UserRegisterDto userRegisterDto);
        Task<GenerateConfirmTokenDto> GenerateEmailConfirmationTokenAsync(ResetTokenMailDto user);
        Task<string> GenerateEmailConfirmationTokenAsync(AppUser user);
        Task ConfirmEmailAsync(UserEmailConfirmationDto userEmailConfirmationDto);
        Task<string> GeneratePasswordResetTokenAsync(ResetTokenMailDto resetTokenMailDto);
        Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
