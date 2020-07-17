using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Security.Token
{
    public class AccessToken
    {
        public AccessToken() { }
        
        public AccessToken(string token, DateTime expiration, string refreshToken)
        {
            Token = token;
            Expiration = expiration;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
