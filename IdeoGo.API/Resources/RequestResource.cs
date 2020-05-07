using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class RequestResource
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime DateSend { get; set; }


        //Relation con internship y con student
        public int CollaboratorId { get; set; }
        public CollaboratorResource Collaborator { get; set; }

        public int RegistryId { get; set; }
        public RegistryResource Registry { get; set; }
    }

}
