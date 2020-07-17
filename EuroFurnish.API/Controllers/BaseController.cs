using AutoMapper;
using EuroFurnish.ApplicationCore.BusinessServices.Interfaces;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;
using EuroFurnish.ApplicationCore.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace EuroFurnish.API.Controllers
{
    public class BaseController<TName> : ControllerBase
    {
        protected IMapper _mapper => HttpHelper.GetService<IMapper>();
        protected IAppLogger<TName> _logger => HttpHelper.GetService<IAppLogger<TName>>();
        protected IBusinessServiceProvider _businessServiceProvider => HttpHelper.GetService<IBusinessServiceProvider>();
        //protected IResponseProvider _responseProvider => HttpHelper.GetService<IResponseProvider>();
        protected IAppEmailService _appEmailService => HttpHelper.GetService<IAppEmailService>();
        protected long GetUserId => long.Parse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value);
        protected string GetUserFullName => User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name).Value;     
        protected string GetUserMail => User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Email).Value;
        
    }
}
