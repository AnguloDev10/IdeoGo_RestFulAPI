using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class AppoitmentResponse: BaseResponse<Appoitment>
    {
        public AppoitmentResponse(Appoitment appoitment) : base(appoitment)
        {

        }

        public AppoitmentResponse(string message) : base(message) { }


    }
}
