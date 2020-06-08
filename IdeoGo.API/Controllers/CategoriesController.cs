using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
       
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper; 
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GoalResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<GoalResource>>(categories);
            return resources;
        }
    }
}


