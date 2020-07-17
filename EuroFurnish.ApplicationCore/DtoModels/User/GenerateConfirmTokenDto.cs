using EuroFurnish.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.DtoModels.User
{
    public class GenerateConfirmTokenDto
    {
        public string Token { get; set; }
        public AppUser User { get; set; }
    }
}
