using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class ApplicationResource
    {
        public int Id { get; set; }
        public int OrderRequest { get; set; }
        public string State { get; set; }
        public DateTime DateSend { get; set; }
    }
}
