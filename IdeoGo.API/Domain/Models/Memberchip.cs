using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Memberchip
    {
        
        public int Id { get; set; }
       
        public DateTime StartAt { get; set; }
        
        public DateTime EndAt { get; set; }

    }
}
