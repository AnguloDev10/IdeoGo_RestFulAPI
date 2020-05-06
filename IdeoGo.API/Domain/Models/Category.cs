using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public IList<Project> projects { get; set; } = new List<Project>();

            
    }
}
