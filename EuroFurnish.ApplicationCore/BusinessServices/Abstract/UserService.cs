using EuroFurnish.ApplicationCore.BusinessServices.Interfaces;
using EuroFurnish.ApplicationCore.Constants;
using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;
using EuroFurnish.ApplicationCore.Security.Validations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.BusinessServices.Abstract
{
    public class UserService : BaseService, IUserService
    {
        private IUserValidationService _userValidationService => HttpHelper.GetService<IUserValidationService>();

        public async Task<AppUser> SignUp(UserRegisterDto userRegisterDto)
        {
            await _userValidationService.UserRegisterRule.ValidateAsync(userRegisterDto);
            var user = _mapper.Map<AppUser>(userRegisterDto);
            user.UserName = user.Email;
            user.EmailConfirmed = false;
            await _unitOfWork.UserRepository.AddToRoleAsync(user, userRegisterDto.Password, RoleConstants.STORES);
            return user;
        }
        #region EmailConfirm
        public async Task<GenerateConfirmTokenDto> GenerateEmailConfirmationTokenAsync(ResetTokenMailDto resetTokenMailDto)
        {
            await _userValidationService.ResetPasswordMailRule.ValidateAsync(resetTokenMailDto);
            var user = await _unitOfWork.UserRepository.FindByEmailAsync(resetTokenMailDto.Email);
            if (user == null)
                throw new ArgumentNullException("Can not find user");           
            var token = await _unitOfWork.UserRepository.UserManager.GenerateEmailConfirmationTokenAsync(user);
            if (token == null)
                throw new ArgumentNullException("Token Null");
            return new GenerateConfirmTokenDto {Token=token,User=user };
        }
        public async Task<string> GenerateEmailConfirmationTokenAsync(AppUser user)
        {
            var token = await _unitOfWork.UserRepository.UserManager.GenerateEmailConfirmationTokenAsync(user);
            if (token == null)
                throw new ArgumentNullException("Token Null");
            return token;
        }
        public async Task ConfirmEmailAsync(UserEmailConfirmationDto userEmailConfirmationDto)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(userEmailConfirmationDto.UserId);
            if (user == null)
                throw new Exception("Can not find user");
            var checkToken = await _unitOfWork.UserRepository.UserManager.ConfirmEmailAsync(user, userEmailConfirmationDto.Token);
            if (!checkToken.Succeeded)
                throw new Exception("Token Error");
        }
        #endregion

        #region ResetPassword
        public async Task<string> GeneratePasswordResetTokenAsync(ResetTokenMailDto resetTokenMailDto)
        {
            await _userValidationService.ResetPasswordMailRule.ValidateAsync(resetTokenMailDto);
            var user = await _unitOfWork.UserRepository.FindByEmailAsync(resetTokenMailDto.Email);
            if (user == null)
                throw new ArgumentNullException("Can not find user");
            if (user.EmailConfirmed == false)
                throw new Exception("Email Confirm Error");
            var token = await _unitOfWork.UserRepository.UserManager.GeneratePasswordResetTokenAsync(user);
            if (token == null)
                throw new ArgumentNullException("Token Null");
            return token;
        }

        public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            await _userValidationService.ResetPasswordRule.ValidateAsync(resetPasswordDto);
            var user = await _unitOfWork.UserRepository.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                throw new Exception("Can not find user");
            var checkToken = await _unitOfWork.UserRepository.UserManager.ResetPasswordAsync(user, resetPasswordDto.Token,resetPasswordDto.Password);
            if (!checkToken.Succeeded)
                throw new Exception("Token Error");
        }
        #endregion

    }
}
