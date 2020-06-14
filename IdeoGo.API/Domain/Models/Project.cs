using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public User ProjectLeader { get; set; }
        
        [Required]
        [Column("project_leader_id")]
        public int ProjectLeaderId { get; set; }
        
        [Required]
        [Column("create_at")]
        public DateTime DateCreated { get; set; }

        public IList<Application> Applications { get; set; } = new List<Application>();
        public IList<Goal> Goals { get; set; } = new List<Goal>();
        public IList<Requierement> Requierements { get; set; } = new List<Requierement>();
        public IList<Activity> Activities { get; set; } = new List<Activity>();
        public IList<MTask> MTasks { get; set; } = new List<MTask>();
        public IList<ProjectSchedule> projectSchedules { get; set; } = new List<ProjectSchedule>();

        [Column("tag_Id")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public List<ProjectTag> ProjectTags { get; set; }
        public List<ProjectUser> ProjectUsers { get; set; }

    }









}
