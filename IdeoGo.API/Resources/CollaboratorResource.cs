using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class CollaboratorResource
    {
        public int ProfileId { get; set; }
        public ProfileResource Profile { get; set; }


        public IList<ProjectResource> Projects { get; set; } = new List<ProjectResource>();
        public IList<RequestResource> Requests { get; set; } = new List<RequestResource>();
        public IList<RegistryResource> Registry { get; set; } = new List<RegistryResource>();
    }
}
