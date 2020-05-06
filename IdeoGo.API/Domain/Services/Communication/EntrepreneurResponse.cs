using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class EntrepreneurResponse: BaseResponse
    {
        public Entrepreneur Entrepreneur { get; private set; }

        public EntrepreneurResponse(bool success, string message, Entrepreneur entrepreneur) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Entrepreneur = entrepreneur;
        }


        public EntrepreneurResponse(Entrepreneur entrepreneur) : this(true, string.Empty, entrepreneur)
        {
            //Escenario feliz
        }

        public EntrepreneurResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }
    }
}
