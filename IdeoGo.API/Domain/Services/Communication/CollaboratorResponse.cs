using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class CollaboratorResponse : BaseResponse
    {
        public Collaborator Collaborator { get; private set; }

        public CollaboratorResponse(bool success, string message, Collaborator collaborator) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Collaborator = collaborator;
        }


        public CollaboratorResponse(Collaborator collaborator) : this(true, string.Empty, collaborator)
        {
            //Escenario feliz
        }

        public CollaboratorResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }
    }
}
