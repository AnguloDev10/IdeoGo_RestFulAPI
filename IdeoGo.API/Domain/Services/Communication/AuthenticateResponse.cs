using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        ///public string Password { get; set; }
        public DateTime Datesignup { get; set; }
        public string Token { get; set; }

        public string Password { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Datesignup = user.Datesignup;
            Token = token;
        }
    }
}
