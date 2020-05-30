﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class ProjectTag
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
