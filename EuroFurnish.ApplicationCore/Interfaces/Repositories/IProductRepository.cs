using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Interfaces.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetProductByIdWithCategoryAsync(long productId);
    }
}
