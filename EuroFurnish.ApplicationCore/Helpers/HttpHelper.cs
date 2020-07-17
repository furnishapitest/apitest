using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace EuroFurnish.ApplicationCore.Helpers
{
    public static class HttpHelper
    {
       
        private static IHttpContextAccessor _accessor;
        private static IApplicationBuilder _serviceProvider;
        public static void Configure(IHttpContextAccessor httpContextAccessor, IApplicationBuilder app)
        {
            _serviceProvider = app;
            _accessor = httpContextAccessor;
        }
        public static T GetService<T>()
        {
            object service;
            if (_accessor != null && _accessor.HttpContext != null && _accessor.HttpContext.RequestServices != null)
            {
                service = _accessor.HttpContext.RequestServices.GetService(typeof(T));                
            }
            else
            {
                if (_serviceProvider == null || _serviceProvider.ApplicationServices == null)
                {
                    return default;
                }
                service = _serviceProvider.ApplicationServices.GetService(typeof(T));
            }
            return (T)service;
        }
    }
}
