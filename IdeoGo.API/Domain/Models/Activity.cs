using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Column("projectSchedule_id")]
        public int ProjectScheduleId { get; set; }
        public ProjectSchedule ProjectSchedule { get; set; }

        [Required]
        [Column("project_id")]
        public int projectId { get; set; }
        public Project project { get; set; }
    }
}
