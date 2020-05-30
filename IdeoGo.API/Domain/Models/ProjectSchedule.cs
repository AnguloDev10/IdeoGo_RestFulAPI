 using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class ProjectSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  Vector <DateTime> Dates { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public IList<Task> Tasks { get; set; } = new List<Task>();

        public IList<Activity> Activities { get; set; } = new List<Activity>();


    }
}
