using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class MTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Column("projectschedule_Id")]
        public int ProjectScheduleId { get; set; }
        public ProjectSchedule ProjectSchedule { get; set; }

        [Required]
        [Column("project_Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
