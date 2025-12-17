using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using Multishop.Cargo.EntityLayer.Concrete;

namespace Multishop.Cargo.WepApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompanyController : ControllerBase
	{


		private readonly ICargoCompanyService _cargoCompanyService;

		public CargoCompanyController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}
		[HttpGet]
		public IActionResult CargoCompanyList()
		{
			var values = _cargoCompanyService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
		{

			//mapping
			CargoCompany cargoCompany = new CargoCompany()
			{
				CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
			};
			_cargoCompanyService.TInsert(cargoCompany);
			return Ok("Kargo şirketi başarıya oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteCompany(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok("Kargo Şirketi Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetCompanyById(int id)
		{
			var values = _cargoCompanyService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			CargoCompany cargoCompany = new CargoCompany()
			{
				CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
				CargoCompanyName = updateCargoCompanyDto.CargoCompanyName,
			};
			_cargoCompanyService.TUpdate(cargoCompany);
			return Ok("Kargo Şirketi Başarıyla Güncellendi");
		}
	}
}
