using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.DtoModels.User
{
    public class UserEmailConfirmationDto
    {
        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
