using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Appoitment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }


        [Required]
        [Column("projectSchedule_id")]
        public int ProjectScheduleId { get; set; }
        public ProjectSchedule ProjectSchedule { get; set; }



        //[Column("Project_Id")]
        //public int ProjectleaderId { get; set; }
        //public User User { get; set; }
    }
}
