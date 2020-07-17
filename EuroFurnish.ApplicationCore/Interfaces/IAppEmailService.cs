using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Interfaces
{
    public interface IAppEmailService
    {
        Task SendEmailAsync(string email, string subject, string message, bool IsHtmlContent = false);
        Task SendEmailConfirmationMailAsync(string email,string confirmLink);
        Task SendResetPasswordMailAsync(string email, string confirmLink);
    }
}
