

using System;
using WebApplication2.Entity;

namespace WebApplication2.Response
{
    public class AuthenticateResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public StatusToken TokenForWeb { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.UserName;
            TokenForWeb = new StatusToken(token, true);
        }
        public class StatusToken
        {
            public StatusToken(string token,bool status)
            {
                Token = token;
                IsLoggedIn = status;
            }
            public string Token { get; set; }
            public Boolean IsLoggedIn { get; set; }
            
        }
    }
}