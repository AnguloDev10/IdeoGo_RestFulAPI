using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EGender Gender { get; set; }

        public string Occupation { get; set; }

        public int Age { get; set; }

        public string TypeUser { get; set; }

        public UserResource User { get; set; }

        public TagResource Tag { get; set; }
    }
}
