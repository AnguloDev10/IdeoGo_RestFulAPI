using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Membership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("Start_At")]
        public DateTime StartAt { get; set; }
        [Required]
        [Column("End_At")]
        public DateTime EndAt { get; set; }

        [Required]
        public string Name { get; set; }


        //[Required]
        //[Column("User_Id")]
        //public int ProfileId { get; set; }
        //public Profile Profile { get; set; }

    }
}
