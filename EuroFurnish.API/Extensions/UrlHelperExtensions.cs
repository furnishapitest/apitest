using EuroFurnish.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EuroFurnish.API.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, long userId, string code, string scheme)
        {
            var link = urlHelper.Action(
                action: "ConfirmMail",
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
            return link;
        }
        public static string ResetPasswordMailLink(this IUrlHelper urlHelper, string email, string code, string scheme)
        {
            var link = urlHelper.Action(
                action: "ConfirmMail",
                controller: "Account",
                values: new { email, code },
                protocol: scheme);
            return link;
        }
    }
}
