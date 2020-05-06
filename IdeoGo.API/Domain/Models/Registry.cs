using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Registry
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public float Amount { get; set; }


        public string Note { get; set; }

        //RelationShip
        
        public int CollaboratorId { get; set; }

        public Project Project { get; set; }

    }
}
