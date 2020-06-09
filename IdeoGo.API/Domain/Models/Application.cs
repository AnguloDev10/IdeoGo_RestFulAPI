using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Application
    {

        public int Id { get; set; }

        public int OrderRequest { get; set; }
        public string State { get; set; }
        public DateTime DateSend { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }


    }
}

