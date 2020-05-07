using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class RequestResponse : BaseResponse
    {

        public Request Request { get; private set; }

        public RequestResponse(bool success, string message, Request request) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Request = request;
        }


        public RequestResponse(Request request) : this(true, string.Empty, request)
        {
            //Escenario feliz
        }

        public RequestResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }


    }
}
