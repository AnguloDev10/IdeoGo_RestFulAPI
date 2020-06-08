using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Datesignup { get; set; }

        //public int ProfileId { get; set; }
        //public Profile Profile { get; set; }

        public IList<ProjectUser> ProjectUsers { get; set; }

        public IList<Application> Applications { get; set; }



    }
}
