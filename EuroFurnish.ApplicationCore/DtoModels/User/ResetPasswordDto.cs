﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.DtoModels.User
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
