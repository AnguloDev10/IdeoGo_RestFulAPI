using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Entrepreneur : User
    {

        //Relationship
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public IList<Project> Projects { get; set; } = new List<Project>();
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        //public IList<Request> Requests { get; set; } = new List<Request>();
        st>();

    
    }
}
