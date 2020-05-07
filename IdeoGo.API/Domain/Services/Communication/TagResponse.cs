using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class TagResponse : BaseResponse
    {

        public Tag Tag { get; private set; }

        public TagResponse(bool success, string message, Tag tag) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Tag = tag;
        }


        public TagResponse(Tag tag) : this(true, string.Empty, tag)
        {
            //Escenario feliz
        }

        public TagResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }


    }
}
