namespace Multishop.Basket.Settings
{
	public class RedisSettings
	{
		public string Host{ get; set; }
		public int Port{ get; set; }
	}
}
/*appsettings.json içindeki RedisSettings bölümünü C# tarafına taşır.
  Bu sınıf olmazsa;
Ayarlara erişmek için sürekli: Configuration["RedisSettings:Host"] yazmak zorunda kalırız
RedisSettings = JSON’un C#’taki kopyası */


