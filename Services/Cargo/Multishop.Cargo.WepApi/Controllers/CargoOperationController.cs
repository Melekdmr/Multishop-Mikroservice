using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using Multishop.Cargo.EntityLayer.Concrete;

namespace Multishop.Cargo.WepApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoOperationController : ControllerBase
	{

		private readonly ICargoOperationService _cargoOperationService;

		public CargoOperationController(ICargoOperationService cargoOperationService)
		{
			_cargoOperationService = cargoOperationService;
		}
		[HttpGet]
		public IActionResult CargoOperationList()
		{
			var values = _cargoOperationService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{

			//mapping
			CargoOperation cargoOperation = new CargoOperation()
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = createCargoOperationDto.OperationDate,
			};
			_cargoOperationService.TInsert(cargoOperation);
			return Ok("Kargo Operasyonu  başarıya oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteOperation(int id)
		{
			_cargoOperationService.TDelete(id);
			return Ok("Kargo Operasyonu  Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetOperationById(int id)
		{
			var values = _cargoOperationService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			CargoOperation cargoOperation = new CargoOperation()
			{  CargoOperationId=updateCargoOperationDto.CargoOperationId,
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate,
			};
			_cargoOperationService.TUpdate(cargoOperation);
			return Ok("Kargo Operasyonu Başarıyla Güncellendi");
		}
	}
}

