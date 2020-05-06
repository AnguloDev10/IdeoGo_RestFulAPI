using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Collaborator : User
    {

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }


        public IList<Project> Projects { get; set; } = new List<Project>();
        public IList<Request> Requests { get; set; } = new List<Request>();
        public IList<Registry> Registry { get; set; } = new List<Registry>();


    }
}
