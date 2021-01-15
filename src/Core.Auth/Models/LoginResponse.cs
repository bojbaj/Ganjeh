using System;

namespace Core.Auth.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }        
    }
}