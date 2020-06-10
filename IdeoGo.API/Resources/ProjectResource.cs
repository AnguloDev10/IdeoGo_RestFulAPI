using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class ProjectResource
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public TagResource Tag { get; set; }

        //public ProjectScheduleResource ProjectSchedule { get; set; }

        public UserResource ProjectLeader { get; set; }
    }
}
