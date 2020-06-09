using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public EGender Gender { get; set; }

        [Required]
        public string Occupation { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [Required]
        [Column("type_user")]
        public string TypeUser { get; set; }
        
        [Required]
        public User User { get; set; }
        
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        public IList<Skill> Skills { get; set; } = new List<Skill>();

        [Required]
        [Column("tag_id")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }


}

