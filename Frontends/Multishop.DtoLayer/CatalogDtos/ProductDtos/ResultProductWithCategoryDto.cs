using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.DtoLayer.CatalogDtos.ProductDtos
{
  public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}
