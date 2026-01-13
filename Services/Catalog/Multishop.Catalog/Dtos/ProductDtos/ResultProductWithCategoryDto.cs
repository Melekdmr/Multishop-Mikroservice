using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Dtos.ProductDtos
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
        //public string CategoryName { get; set; }
        public ResultCategoryDto Category { get; set; }
     
    }
}
