using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class ProfileResponse : BaseResponse
    {
        public Profile Profile { get; private set; }

        public ProfileResponse(bool success, string message, Profile profile) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Profile = profile;
        }


        public ProfileResponse(Profile profile) : this(true, string.Empty, profile)
        {
            //Escenario feliz
        }

        public ProfileResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }
    }
}
