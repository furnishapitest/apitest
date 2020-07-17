using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Providers.Interfaces
{
    public interface ITokenProvider
    {
        AccessToken CreateAccessToken(AppUser user);
    }
}
