using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Resource : Requierement
    {
        public int IdR { get; set; }
        public float Quantity { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

    }
}
