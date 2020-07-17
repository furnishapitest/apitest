using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EuroFurnish.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : BaseController<CategoryController>
    {
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _businessServiceProvider.CategoryService.GetTest();
            return Ok(model);
        }
    }
}