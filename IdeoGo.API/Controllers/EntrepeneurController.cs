using IdeoGo.API.Domain.Services;
using IdeoGo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Controllers
{
    [Route("/api/[controller]")]
    public class EntrepeneurController
    {

        private readonly IEntrepreneurService _entrepeneurService;
    }
}
