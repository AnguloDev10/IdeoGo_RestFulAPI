using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        [Required]
        public DateTime Datesignup { get; set; }

        public string Token { get; set; }

        //[Required]
        //[Column("profile_id")]
        //public int ProfileId { get; set; }
        //public Profile Profile { get; set; }

        //[Required]
        //[Column("project_id")]
        //public int ProjectId { get; set; }
        //public Project Project { get; set; }

        public IList<ProjectUser> ProjectUsers { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<Membership> Memberships { get; set; }

        public IList<Subscription> Subscriptions { get; set; }

    }
}
