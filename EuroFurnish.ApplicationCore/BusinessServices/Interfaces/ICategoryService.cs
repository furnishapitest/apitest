using EuroFurnish.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.BusinessServices.Interfaces
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<Category>> GetTest();
    }
}
