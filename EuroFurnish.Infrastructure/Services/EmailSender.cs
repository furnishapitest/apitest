using EuroFurnish.ApplicationCore.DtoModels.Mail;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EuroFurnish.Infrastructure.Services
{
    public class EmailSender : IAppEmailService
    {
        private readonly EmailSettings _emailSettings;
        
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message,bool IsHtmlContent=false)
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSSL,
               
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };
            var _mail = new MailMessage(_emailSettings.Username, email, subject, message);
            _mail.IsBodyHtml = IsHtmlContent;
            await client.SendMailAsync(_mail);
        }

        public async Task SendEmailConfirmationMailAsync(string email,string confirmLink)
        {
            string subject = "Kayıt Ol Mail Onayı";
            string message = "Kaydınız Başarıyla Yapılmıştır<br><br>";
            message += $"<a href='{confirmLink}'>Onaylamak İçin Linke Tıklayınız</a>";
            await SendEmailAsync(email, subject, message,true);
        }
        public async Task SendResetPasswordMailAsync(string email, string confirmLink)
        {
            string subject = "Reset Password Mail Onayı";
            string message = "Aşağıdaki linke tıklayarak Şifreyi Yenileyebilirsini<<br><br>";
            message += $"<a href='{confirmLink}'>Yenilemek İçin Linke Tıklayınız</a>";
            await SendEmailAsync(email, subject, message, true);
        }
    }
}
