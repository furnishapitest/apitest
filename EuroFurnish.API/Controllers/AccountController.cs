using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroFurnish.API.Extensions;
using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EuroFurnish.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseController<AccountController>
    {
        #region User-Register
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var user = await _businessServiceProvider.UserService.SignUp(userRegisterDto);
            var confirmToken = await _businessServiceProvider.UserService.GenerateEmailConfirmationTokenAsync(user);
            await ConfirmMailSender(user, confirmToken);
            return Ok();
        }
        #endregion

        #region Login-Token
        [HttpPost("SignIn")]
        public async Task<IActionResult> AccessToken(UserLoginDto userLoginDto)
        {
            var model = await _businessServiceProvider.AuthenticationService.CreateAccessTokenAsync(userLoginDto);
            return Ok(model);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var model = await _businessServiceProvider.AuthenticationService.CreateAccessTokenByRefreshTokenAsync(refreshTokenDto.RefreshToken);
            return Ok(model);
        }
        [HttpPost("RemoveRefreshToken")]
        public async Task<IActionResult> RemoveRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            await _businessServiceProvider.AuthenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);
            return Ok();
        }
        #endregion

        #region Confirm-Mail
        private async Task ConfirmMailSender(AppUser user, string confirmToken)
        {
            var confirmLink = Url.EmailConfirmationLink(user.Id, confirmToken, Request.Scheme);
            await _appEmailService.SendEmailConfirmationMailAsync(user.Email, confirmLink);
        }
        [HttpPost("ConfirmMail")]
        public async Task<IActionResult> ConfirmMail(UserEmailConfirmationDto userEmailConfirmationDto)
        {
            await _businessServiceProvider.UserService.ConfirmEmailAsync(userEmailConfirmationDto);
            return Ok();
        }
        [HttpPost("ConfirmMailToken")]
        public async Task<IActionResult> ConfirmMailToken(ResetTokenMailDto resetTokenMailDto)
        {           
            var model = await _businessServiceProvider.UserService.GenerateEmailConfirmationTokenAsync(resetTokenMailDto);
            await ConfirmMailSender(model.User, model.Token);
            return Ok();
        }
        #endregion

        #region Reset-Password
        [HttpPost("ResetPasswordToken")]
        public async Task<IActionResult> ResetPasswordToken(ResetTokenMailDto resetTokenMailDto)
        {
            var token = await _businessServiceProvider.UserService.GeneratePasswordResetTokenAsync(resetTokenMailDto);
            var confirmLink = Url.ResetPasswordMailLink(resetTokenMailDto.Email, token, Request.Scheme);
            await _appEmailService.SendResetPasswordMailAsync(resetTokenMailDto.Email, confirmLink);
            return Ok();
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassowrd(ResetPasswordDto resetPasswordDto)
        {
            await _businessServiceProvider.UserService.ResetPasswordAsync(resetPasswordDto);
            return Ok();
        }
        #endregion

    }
}