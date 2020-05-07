using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class EntrepreneurResource
    {
        public int ProfileId { get; set; }
        public ProfileResource Profile { get; set; }

        public IList<ProjectResource> Projects { get; set; } = new List<ProjectResource>();
        public IList<TagResource> Publications { get; set; } = new List<TagResource>();
    }
}
