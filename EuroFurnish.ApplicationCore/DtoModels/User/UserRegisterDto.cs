using EuroFurnish.ApplicationCore.DtoModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.DtoModels.User
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
