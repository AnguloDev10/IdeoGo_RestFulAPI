using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderRequest { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Column("date_send")]
        public DateTime DateSend { get; set; }

        [Required]
        [Column("user_Id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Column("project_Id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

