using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IList<Skill> Skills { get; set; } = new List<Skill>();
        public IList<Profile> UserProfiles { get; set; } = new List<Profile>();
        public IList<Project> Projects { get; set; } = new List<Project>();
        public List<ProjectTag> ProjectTags { get; set; }
    }

}
