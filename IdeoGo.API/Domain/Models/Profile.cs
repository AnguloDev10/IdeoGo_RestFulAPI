using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Field { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }

        //Relationships
        public int EntrepreneurId { get; set; }
        public Entrepreneur Entrepreneur { get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }



    }
}
