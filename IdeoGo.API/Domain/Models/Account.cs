using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Account
    {

        public int Id { get; set; }

        public string Key { get; set; }
        //properties

        public DateTime CreatAt { get; set; }

        public bool Payment { get; set; }

        ///public IList<User> Users { get; set; } = new List<User>();
        

    }
}
