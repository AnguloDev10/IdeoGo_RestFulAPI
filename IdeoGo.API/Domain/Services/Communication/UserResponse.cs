using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {

        public User User { get; private set; }

        public UserResponse(bool success, string message, User user) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            User = user;
        }


        public UserResponse(User user) : this(true, string.Empty, user)
        {
            //Escenario feliz
        }

        public UserResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }


    }
}
