using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IList<Skill> Skills { get; set; } = new List<Skill>();

        public IList<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

        public IList<Project> Projects { get; set; } = new List<Project>();
    }

}
