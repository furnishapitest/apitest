using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces.Repositories;
using EuroFurnish.Infrastructure.Data.Contexts;
using EuroFurnish.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.Infrastructure.Data.Repositories.EntityFramework
{
    public class EfCategoryRepository : EfAsyncBaseRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
