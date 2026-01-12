using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string CategoryID { get; set; }
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        public string CategoryName { get; set; }
    }
}
