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

        public IList<Project> Projects { get; set; } = new List<Project>();
    }
}
