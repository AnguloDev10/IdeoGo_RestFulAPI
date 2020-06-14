using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Goal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column("create_At")]
        public DateTime EstimatedDate { get; set; }
        [Column("project_Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
