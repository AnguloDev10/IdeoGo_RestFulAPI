using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public Collaborator collaborator { get; set; }

        //public int CollaboratorId { get; set; }

        //public User user { get; set; }

        //public int userId { get; set; }

        //public int UserId;
        //internal object Categories;

        //public Entrepreneur Entrepreneur { get; set; }

        //public IList<Collaborator> Collaborator { get; set; } = new List<Collaborator>();


        public int CategoryId { get; set; }
        public Category Categories { get; set; }



    }









}
