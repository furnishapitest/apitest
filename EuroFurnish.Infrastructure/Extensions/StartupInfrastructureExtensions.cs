using EuroFurnish.ApplicationCore.DtoModels.Mail;
using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces;
using EuroFurnish.ApplicationCore.Interfaces.Repositories;
using EuroFurnish.ApplicationCore.Interfaces.Repositories.Base;
using EuroFurnish.Infrastructure.Data.Contexts;
using EuroFurnish.Infrastructure.Data.Repositories.Base;
using EuroFurnish.Infrastructure.Data.Repositories.EntityFramework;
using EuroFurnish.Infrastructure.Logging;
using EuroFurnish.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EuroFurnish.Infrastructure.Extensions
{
    public static class StartupInfrastructureExtensions
    {
        public static void AddDataLayerServiceDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfAsyncBaseRepository<>));
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
        }

        public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(c =>
           c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
           sql => sql.MigrationsAssembly("EuroFurnish.API")));
        }
        public static void AddIdentityDI(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<long>>()
              .AddEntityFrameworkStores<ApplicationContext>()
              .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;

            });
        }

        public static void AddEmailServiceDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddSingleton<IAppEmailService, EmailSender>();
        }
    }
}
