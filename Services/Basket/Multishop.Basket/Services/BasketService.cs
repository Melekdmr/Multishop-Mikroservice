using Multishop.Basket.Dtos;
using Multishop.Basket.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace Multishop.Basket.Services
{
	public class BasketService : IBasketService
	{
		private readonly RedisService _redisService;

		public BasketService(RedisService redisService)
		{
			_redisService = redisService;
		}

		public async Task DeleteBasket(string userId)
		{
			await _redisService.GetDb().KeyDeleteAsync(userId);
		}
		public async Task<BasketTotalDto> GetBasket(string userId)
		{
		var existBasket= await _redisService.GetDb().StringGetAsync(userId);
			return JsonSerializer.Deserialize<BasketTotalDto>(existBasket); //sepetin boş olma durumu için uyarı eklenebilir

		}

		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{  //key=userid value=basketTotalDto
			await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
		}
	}
}
