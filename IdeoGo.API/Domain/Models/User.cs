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

        public DateTime DateSignUp { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public IList<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

        public IList<Application> Applications { get; set; } = new List<Application>();



    }
}
