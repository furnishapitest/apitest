using EuroFurnish.ApplicationCore.BusinessServices.Interfaces;
using EuroFurnish.ApplicationCore.Helpers;

namespace EuroFurnish.ApplicationCore.BusinessServices.Abstract
{
    public class BusinesServiceProvider : IBusinessServiceProvider
    {
        public ICategoryService CategoryService => HttpHelper.GetService<ICategoryService>();
        public IUserService UserService => HttpHelper.GetService<IUserService>();

        public IAuthenticationService AuthenticationService => HttpHelper.GetService<IAuthenticationService>();
    }
}
