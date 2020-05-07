using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Field { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }

        //Relationships
        public int UserId { get; set; }
        public UserResource User { get; set; }
    }
}
