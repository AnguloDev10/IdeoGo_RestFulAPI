using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public User ProjectLeader { get; set; }

        public int ProjectLeaderId { get; set; }

        public DateTime DateCreated { get; set; }

        public IList<Application> Applications { get; set; } = new List<Application>();
        public IList<Goal> Goals { get; set; } = new List<Goal>();
        public IList<Requierement> Requierements { get; set; } = new List<Requierement>();


        //public int TagId { get; set; }

        //public Tag Tag { get; set; }


        //public ProjectSchedule ProjectSchedule { get; set; }

        //public int ProjectScheduleId { get; set; }

        public List<ProjectTag> ProjectTags { get; set; }

        public List<ProjectUser> ProjectUsers { get; set; }

    }









}
