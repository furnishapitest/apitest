using EuroFurnish.ApplicationCore.BusinessServices.Interfaces;
using EuroFurnish.ApplicationCore.DtoModels.User;
using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Security.Validations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.BusinessServices.Abstract
{
    public class CategoryService : BaseService, ICategoryService
    {
       
        public async Task<IReadOnlyList<Category>> GetTest()
        {
            var data = await _unitOfWork.CategoryRepository.GetAllAsync();
            if (data == null)
                throw new ArgumentNullException("No Category");
            return data;
        }
       
    }
}
