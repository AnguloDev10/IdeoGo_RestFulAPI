using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;

namespace IdeoGo.API.Domain.Services
{
    public class PublicationResponse : BaseResponse
    {
        public Publication Publication { get; private set; }

        public PublicationResponse(bool success, string message, Publication publ) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Publication = publ;
        }


        public PublicationResponse(Publication publ) : this(true, string.Empty, publ)
        {
            //Escenario feliz
        }

        public PublicationResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }


    }
}