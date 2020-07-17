using EuroFurnish.ApplicationCore.BusinessServices.Interfaces;
using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Providers.Interfaces;
using EuroFurnish.ApplicationCore.Security.Token;
using EuroFurnish.ApplicationCore.Security.Validations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.BusinessServices.Abstract
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private IUserValidationService _userValidationService => HttpHelper.GetService<IUserValidationService>();
        private ITokenProvider _tokenProvider => HttpHelper.GetService<ITokenProvider>();
        public async Task<AccessToken> CreateAccessTokenAsync(UserLoginDto userLoginDto)
        {
            await  _userValidationService.UserLoginRule.ValidateAsync(userLoginDto);
            var user = await _unitOfWork.UserRepository.FindByUsernameAsync(userLoginDto.Email);
            if(user==null)
                throw new ArgumentNullException($"{userLoginDto.Email}  : user can not find");
            var checkUserPassword = await _unitOfWork.UserRepository.UserManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (checkUserPassword==false)
                throw new ArgumentNullException($"user password can not find");
            if(user.EmailConfirmed==false)
                throw new Exception($"Email Confirmation Error");
            var tokenModel = _tokenProvider.CreateAccessToken(user);
            _unitOfWork.UserRepository.SaveRefreshTokenAsync(user, tokenModel.RefreshToken, tokenModel.Expiration);
            await _unitOfWork.CommitAsync();
            return tokenModel;
        }

        public async Task<AccessToken> CreateAccessTokenByRefreshTokenAsync(string refreshToken)
        {
            var user =  await _unitOfWork.UserRepository.FindUserByRefreshToken(refreshToken);
            if(user==null)
                throw new ArgumentNullException($"user can not find");
            if (user.RefreshTokenEndDate > DateTime.Now)
                throw new Exception($"Refresh Token süresi dolmuştur.");
            var tokenModel = _tokenProvider.CreateAccessToken(user);
            _unitOfWork.UserRepository.SaveRefreshTokenAsync(user, tokenModel.RefreshToken, tokenModel.Expiration);
            await _unitOfWork.CommitAsync();
            return tokenModel;
        }

        public async Task RevokeRefreshToken(string refreshToken)
        {
            var user = await _unitOfWork.UserRepository.FindUserByRefreshToken(refreshToken);
            if (user == null)
                throw new ArgumentNullException($"user can not find");
            _unitOfWork.UserRepository.RemoveRefreshToken(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
