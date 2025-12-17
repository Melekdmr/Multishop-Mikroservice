using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
	public class ProductImage
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)] /*Bu alanı MongoDB’de ObjectId olarak sakla ama C# tarafında string olarak kullanmaya izin ver.(Veri dönüşümü)*/
		public string ProductImageID { get; set; }
		public string Image1 { get; set; }
		public string Image2 { get; set; }
		public string Image3 { get; set; }
		public string ProductId { get; set; }
		[BsonIgnore]
		public Product Product { get; set; }
	}
}
