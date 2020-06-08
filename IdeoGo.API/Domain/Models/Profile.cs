using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EGender Gender { get; set; }

        public string Occupation { get; set; }

        public int Age { get; set; }

        public string TypeUser { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }


        public IList<Skill> Skills { get; set; } = new List<Skill>();

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }


}

