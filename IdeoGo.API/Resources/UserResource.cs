using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Occupation { get; set; }

        public string Experience { get; set; }

        public AccountResource account { get; set; }

        public int accountId { get; set; }

        public IList<ProjectResource> Projects { get; set; } = new List<ProjectResource>();
    }
}
