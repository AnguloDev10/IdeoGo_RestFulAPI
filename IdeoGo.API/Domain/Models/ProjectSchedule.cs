 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class ProjectSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [Column("project_id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public IList<MTask> Tasks { get; set; } = new List<MTask>();
        public IList<Activity> Activities { get; set; } = new List<Activity>();


    }
}
