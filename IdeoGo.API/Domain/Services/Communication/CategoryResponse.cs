using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public CategoryResponse(Category category) : base(category)
        {
        }

        public CategoryResponse(string message) : base(message) { }


    }
}