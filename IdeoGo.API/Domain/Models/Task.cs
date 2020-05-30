using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int ProjectScheduleId { get; set; }
        public ProjectSchedule ProjectSchedule { get; set; }
    }
}
