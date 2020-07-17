using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EuroFurnish.API.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        private IUnitOfWork unitOfWork => HttpHelper.GetService<IUnitOfWork>();
        [HttpGet("Find")]
        public async Task<IActionResult> Find(long productId)
        {
            var data = await unitOfWork.ProductRepository.GetProductByIdWithCategoryAsync(productId);
          
            return Ok(data);
        }
    }
}