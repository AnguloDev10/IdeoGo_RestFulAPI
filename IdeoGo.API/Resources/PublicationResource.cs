using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Description { get; set; }

        public DateTime CreateAt { get; set; }

        public int EntrepreneurId { get; set; }
        public EntrepreneurResource Entrepreneur { get; set; }
    }
}
