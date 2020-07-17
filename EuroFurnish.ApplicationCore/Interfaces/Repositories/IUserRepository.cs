using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository
    {
        UserManager<AppUser> UserManager { get; set; }
        SignInManager<AppUser> SignInManager { get; set; }
        void SaveRefreshTokenAsync(AppUser appUser, string refreshToken, DateTime refreshTokenExpiration);
        void RemoveRefreshToken(AppUser appUser);
        Task<AppUser> FindUserByRefreshToken(string refreshToken);
        Task AddToRoleAsync(AppUser appUser, string password, string role);
        Task<AppUser> FindByIdAsync(long Id);
        Task<AppUser> FindByUsernameAsync(string userName);
        Task<AppUser> FindByEmailAsync(string email);
    }
}
