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
    [Route("/api/[controller]")]//va a asociarse con las routas 
    public class CategoriesController:Controller
    {
        //es una clase normal
        ///controler // net core 2 requisitos: catgorioescomntreoller debe descender de la clase controller y la clase controler esta en un paquete mvc del using, que dice que se comporta segun el patron mvc
        //
        private readonly ICategoryService _categoryService;//UN AQTRIBUTO DE SOLO LECTURA
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


