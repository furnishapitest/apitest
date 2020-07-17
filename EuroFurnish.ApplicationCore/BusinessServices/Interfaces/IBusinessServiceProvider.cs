namespace EuroFurnish.ApplicationCore.BusinessServices.Interfaces
{
    public interface IBusinessServiceProvider
    {
        ICategoryService CategoryService { get; }
        IUserService UserService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
