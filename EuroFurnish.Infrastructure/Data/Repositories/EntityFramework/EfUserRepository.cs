using EuroFurnish.ApplicationCore.Constants;
using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces.Repositories;
using EuroFurnish.ApplicationCore.Security.Token;
using EuroFurnish.Infrastructure.Data.Contexts;
using EuroFurnish.Infrastructure.Data.Repositories.Base;
using EuroFurnish.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.Infrastructure.Data.Repositories.EntityFramework
{
    public class EfUserRepository : IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public EfUserRepository(ApplicationContext dbContext, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, RoleManager<IdentityRole<long>> roleManager)
        {
            _dbContext = dbContext;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public UserManager<AppUser> UserManager { get; set; }
        public SignInManager<AppUser> SignInManager { get; set; }
        private RoleManager<IdentityRole<long>> RoleManager { get; set; }

        public async Task AddToRoleAsync(AppUser appUser,string password,string role)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var userResult = await UserManager.CreateAsync(appUser, password);
                    if (userResult.Succeeded)
                    {
                        var roleResult = await UserManager.AddToRoleAsync(appUser, role);
                        if (roleResult.Succeeded == false)
                            throw new Exception("Role Error");
                    }
                    else
                    {
                        throw new Exception("User Error");
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {                    
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }

        }
        public async Task<AppUser> FindUserByRefreshToken(string refreshToken)
        {
            return await _dbContext.Users.GetActive().FirstOrDefaultAsync(p => p.RefreshToken == refreshToken);
        }
        public async Task<AppUser> FindByIdAsync(long Id)
        {
            return await _dbContext.Users.GetActive().FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task<AppUser> FindByUsernameAsync(string userName)
        {
            return await _dbContext.Users.GetActive().FirstOrDefaultAsync(p => p.UserName == userName);
        }
        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await _dbContext.Users.GetActive().FirstOrDefaultAsync(p => p.Email == email);
        }
        public void RemoveRefreshToken(AppUser appUser)
        {
            appUser.RefreshToken = null;
            appUser.RefreshTokenEndDate = DateTime.MinValue;
            _dbContext.Entry(appUser).State = EntityState.Modified;
        }

        public void SaveRefreshTokenAsync(AppUser appUser, string refreshToken, DateTime refreshTokenExpiration)
        {
            appUser.RefreshToken = refreshToken;
            appUser.RefreshTokenEndDate = refreshTokenExpiration;
            _dbContext.Entry(appUser).State = EntityState.Modified;
        }
    }
}
