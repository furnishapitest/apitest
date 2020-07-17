using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.BusinessServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AccessToken> CreateAccessTokenAsync(UserLoginDto userLoginDto);
        Task<AccessToken> CreateAccessTokenByRefreshTokenAsync(string refreshToken);
        Task RevokeRefreshToken(string refreshToken);
    }
}
