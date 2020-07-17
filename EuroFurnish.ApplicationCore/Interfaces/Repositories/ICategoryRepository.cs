using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Interfaces.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
       
    }
}
