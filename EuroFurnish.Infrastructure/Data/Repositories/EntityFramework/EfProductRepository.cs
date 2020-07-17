using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces.Repositories;
using EuroFurnish.ApplicationCore.Specifications;
using EuroFurnish.Infrastructure.Data.Contexts;
using EuroFurnish.Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.Infrastructure.Data.Repositories.EntityFramework
{
    public class EfProductRepository : EfAsyncBaseRepository<Product>, IProductRepository
    {
        public EfProductRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Product>> GetProductByIdWithCategoryAsync(long productId)
        {           
            var spec = new ProductWithCategorySpecification(productId);
            return (await GetAsync(spec));
        }
    }
}
