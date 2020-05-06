using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveCategoryResource
    {
        /// <summary>
        /// TODO ESTO ES EL BACKEND Y LA PARTE DEL USUARIO ES FRONTEND
        /// 
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
