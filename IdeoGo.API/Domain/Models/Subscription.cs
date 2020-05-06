using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
}
