using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class RegistryResource
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public float Amount { get; set; }


        public string Note { get; set; }

        //RelationShip

        public int CollaboratorId { get; set; }

        public CollaboratorResource Collaborator { get; set; }
        public int ProjectId { get; set; }
        public ProjectResource Project { get; set; }
    }
}
