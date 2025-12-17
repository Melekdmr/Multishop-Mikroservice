using Multishop.Basket.Dtos;

namespace Multishop.Basket.Services
{//SOLID prensibi → Interface Segregation
	public interface IBasketService
	{
		Task<BasketTotalDto> GetBasket (string userId);
		Task SaveBasket(BasketTotalDto basketTotalDto);
		Task  DeleteBasket(string userId);
	}
}
