namespace Multishop.Basket.Dtos
{
	public class BasketItemDto
	{
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }   // Kaç adet alındı
		public decimal Price { get; set; }
	}
}

