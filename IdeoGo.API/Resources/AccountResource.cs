using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class AccountResource
    {
        public int Id { get; set; }

        public string Key { get; set; }
        //properties

        public DateTime CreatAt { get; set; }

        public bool Payment { get; set; }

        public IList<UserResource> Users { get; set; } = new List<UserResource>();
    }
}
