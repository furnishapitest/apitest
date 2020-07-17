using EuroFurnish.ApplicationCore.Constants;
using EuroFurnish.ApplicationCore.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.Infrastructure.Data.Contexts
{
    public class AppContextSeed
    {
        public static async Task SeedAsync(ApplicationContext appContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                // aspnetrunContext.Database.Migrate();
                // aspnetrunContext.Database.EnsureCreated();

                if (!appContext.Categories.Any())
                {
                    appContext.Categories.AddRange(GetPreconfiguredCategories());
                    await appContext.SaveChangesAsync();
                }

                if (!appContext.Products.Any())
                {
                    appContext.Products.AddRange(GetPreconfiguredProducts());
                    await appContext.SaveChangesAsync();
                }
                if (!appContext.Roles.Any())
                {
                    appContext.Roles.AddRange(GetPreconfiguredUser());
                    await appContext.SaveChangesAsync();

                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AppContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(appContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "Phone"},
                new Category() { Name = "TV"}
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                //new Product() { Name = "IPhone", CategoryId = 1 , UnitPrice = 19.5M , UnitsInStock = 10, },
                //new Product() { Name = "Samsung", CategoryId = 1 , UnitPrice = 33.5M , UnitsInStock = 10, },
                //new Product() { Name = "LG TV", CategoryId = 2 , UnitPrice = 33.5M , UnitsInStock = 10,  }
            };
        }
        private static IEnumerable<IdentityRole<long>> GetPreconfiguredUser()
        {
            return new List<IdentityRole<long>>()
            {
               new IdentityRole<long>{Name=RoleConstants.STORES },
            };
        }
    }
}
