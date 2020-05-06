using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Entrepreneur : User
    {
  
    public IList<Project> Projects { get; set; } = new List<Project>();
    public IList<Request> Requests { get; set; } = new List<Request>();

    
    }
}
