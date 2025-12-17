using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DtoLayer.Dtos.CargoCustomerDto;
using Multishop.Cargo.EntityLayer.Concrete;

namespace Multishop.Cargo.WepApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomerController : ControllerBase
	{

		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomerController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}
		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			var values = _cargoCustomerService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCostumerDto createCargoCustomerDto)
		{

			//mapping
			CargoCustomer cargoCustomer = new CargoCustomer()
			{
				CustomerName = createCargoCustomerDto.CustomerName,
				CustomerSurname = createCargoCustomerDto.CustomerSurname,
				Email = createCargoCustomerDto.Email,
				Phone = createCargoCustomerDto.Phone,
				District = createCargoCustomerDto.District,
				City = createCargoCustomerDto.City,
				Address = createCargoCustomerDto.Address,
			};
			_cargoCustomerService.TInsert(cargoCustomer);
			return Ok("Müşteri başarıya oluşturuldu");
		}
		[HttpDelete]
		public IActionResult DeleteCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Müşteri Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetCustomerById(int id)
		{
			var values = _cargoCustomerService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateCustomer(UpdateCargoCostumerDto updateCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer()
			{
				CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
				CustomerName = updateCargoCustomerDto.CustomerName,
				CustomerSurname = updateCargoCustomerDto.CustomerSurname,
				Email = updateCargoCustomerDto.Email,
				Phone = updateCargoCustomerDto.Phone,
				District = updateCargoCustomerDto.District,
				City = updateCargoCustomerDto.City,
				Address = updateCargoCustomerDto.Address,
			};
			_cargoCustomerService.TUpdate(cargoCustomer);
			return Ok("Müşteri  Başarıyla Güncellendi");
		}
	}
}

