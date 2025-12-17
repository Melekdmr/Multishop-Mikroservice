using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Services.ProductDetailServices;

namespace Multishop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductDetailController : ControllerBase
	{
		private readonly IProductDetailService _ProductDetailService;

		public ProductDetailController(IProductDetailService ProductDetailService)
		{
			_ProductDetailService = ProductDetailService;
		}
		[HttpGet]
		public async Task<IActionResult> ProductDetailList()
		{
			var values = await _ProductDetailService.GetAllProductDetailAsync();
			return Ok(values);
		}
		[HttpGet("id")]
		public async Task<IActionResult> GetProductDetailById(string id)
		{
			var values = await _ProductDetailService.GetByIdProductDetailAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
		{
			await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
			return Ok("Ürün detaylarıbaşarıyla eklendi");
		}
		[HttpDelete("id")]

		public async Task<IActionResult> DeleteProductDetail(string id)
		{
			await _ProductDetailService.DeleteProductDetailAsync(id);
			return Ok("Ürün detayları başarıyla silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
		{
			await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
			return Ok("Ürün detayları başarıyla güncellendi");
		}
	}
}
