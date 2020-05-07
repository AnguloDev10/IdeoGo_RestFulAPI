using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        private Category existingCategory;

        public Category Category { get; private set; }

        public CategoryResponse(bool success, string message, Category category) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Category = category;
        }


        public CategoryResponse(Category category) : this(true, string.Empty, category)
        {
            //Escenario feliz
        }

        public CategoryResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }

     
    }
}