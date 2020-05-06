using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Request
    {

        public int Id { get; set; }
        public string State { get; set; }
        public DateTime DateSend { get; set; }


        //Relation con internship y con student
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }


        public int EntrpreneurId { get; set; }

        public Entrepreneur Entrepreneur { get; set; }

        //public int InternshipId { get; set; }
        //public Internship Internship { get; set; }




    }
}
