using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Skill 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string DegreesRequired { get; set; }
        
        [Required]
        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }

        [Required]
        [Column("tag_id")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

