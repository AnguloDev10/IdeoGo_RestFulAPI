using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Occupation { get; set; }

        public string Experience { get; set; }

        public Account account { get; set; }

        public int accountId { get; set; }

        public IList<Project> Projects { get; set; } = new List<Project>();
    }
}
