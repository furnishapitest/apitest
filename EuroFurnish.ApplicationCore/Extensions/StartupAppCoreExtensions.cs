using EuroFurnish.ApplicationCore.BusinessServices.Abstract;
using EuroFurnish.ApplicationCore.BusinessServices.Interfaces;
using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Providers.Abstract;
using EuroFurnish.ApplicationCore.Providers.Interfaces;
using EuroFurnish.ApplicationCore.Security.Token;
using EuroFurnish.ApplicationCore.Security.Validations.Rules.User;
using EuroFurnish.ApplicationCore.Security.Validations.Services.Abstracts;
using EuroFurnish.ApplicationCore.Security.Validations.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace EuroFurnish.ApplicationCore.Extensions
{
    public static class StartupAppCoreExtensions
    {
        public static void AddBussinessServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IBusinessServiceProvider, BusinesServiceProvider>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IResponseProvider, ResponseProvider>();
            services.AddScoped<ITokenProvider, TokenProvider>();
        }
        public static void AddJWTTokenOption(this IServiceCollection services,IConfiguration configuration)
        {
            var jwtTokenSection = configuration.GetSection("TokenOption");
            services.Configure<TokenOption>(jwtTokenSection);
            var tokenOption = jwtTokenSection.Get<TokenOption>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtOption =>
                {
                    jwtOption.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer=true,
                        ValidateLifetime=true,
                        ValidateIssuerSigningKey=true,
                        ValidIssuer=tokenOption.Issuer,
                        ValidAudience=tokenOption.Audience,
                        IssuerSigningKey= SignHandler.GetSecurityKey(tokenOption.SecurityKey),
                        ClockSkew=TimeSpan.Zero,
                    };

                });
        }
        public static void AddValidationRuleDI(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserRegisterDto>, UserRegisterRequestValidator>();
            services.AddTransient<IValidator<UserLoginDto>, UserLoginRequestValidator>();
            services.AddTransient<IValidator<ResetTokenMailDto>, ResetTokenMailRequestValidator>();
            services.AddTransient<IValidator<ResetPasswordDto>, ResetPasswordRequestValidator>();
        }
        public static void AddValidationServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IUserValidationService,UserValidationService>();            
        }
         
    }
}
