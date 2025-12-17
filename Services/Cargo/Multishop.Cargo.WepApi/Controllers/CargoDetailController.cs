using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtoLayer.CargoDetailCompany;
using Multishop.Cargo.EntityLayer.Concrete;

namespace Multishop.Cargo.WepApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailController : ControllerBase
	{

		private readonly ICargoDetailService _cargoDetailService;

		public CargoDetailController(ICargoDetailService cargoDetailService)
		{
			_cargoDetailService = cargoDetailService;
		}
		[HttpGet]
		public IActionResult CargoDetailList()
		{
			var values = _cargoDetailService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
		{

			//mapping
			CargoDetail cargoDetail = new CargoDetail()
			{
				SenderCustomer = createCargoDetailDto.SenderCustomer,
				ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
				Barcode=createCargoDetailDto.Barcode,
				CargoCompanyId=createCargoDetailDto.CargoCompanyId,
			};
			_cargoDetailService.TInsert(cargoDetail);
			return Ok("Kargo Detayı başarıya oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteDetail(int id)
		{
			_cargoDetailService.TDelete(id);
			return Ok("Kargo Detayı Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetDetailById(int id)
		{
			var values = _cargoDetailService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateDetail(UpdateCargoDetailDto updateCargoDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail()
			{
				CargoDetailId = updateCargoDetailDto.CargoDetailId,
				ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
				SenderCustomer = updateCargoDetailDto.SenderCustomer,
				Barcode = updateCargoDetailDto.Barcode,
				CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
			};
			_cargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo Detayı Başarıyla Güncellendi");
		}
	}
}

