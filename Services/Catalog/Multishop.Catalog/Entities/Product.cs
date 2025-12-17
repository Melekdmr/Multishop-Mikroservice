using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.CompilerServices;

namespace Multishop.Catalog.Entities
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public int ProductStock { get; set; }
		public string ProductImageUrl { get; set; }
		public string ProductDescription { get; set; }
		public string CategoryID { get; set; }

		[BsonIgnore]
		public Category Category { get; set; }

		/*ProductStock iş verisidir ve matematiksel anlamı olduğu için int,
ProductId ise sadece kimlik olduğu için ObjectId (string)’dir.*/
		
	}
}
