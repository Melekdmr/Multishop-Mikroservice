using System.Collections.Generic;

namespace Multishop.Basket.Dtos
{
	public class BasketTotalDto
	{
		public string UserId { get; set; }
		public string DiscountCode { get; set; }
		public string DiscountRate { get; set; } //indirim oranı/tutarı
		public List<BasketItemDto> BasketItems { get; set; }
		public decimal TotalPrice { get => BasketItems.Sum(x => x.Quantity * x.Price); }
	}
}
