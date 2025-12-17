using StackExchange.Redis;

namespace Multishop.Basket.Settings
{    //Redis ile Gerçek İletişim Katmanı
    //konfigürasyın ayarları için kullanılacak sınıf
	public class RedisService
	{
		public string _host { get; set; }
		public int _port { get; set; }

		/*Redis’e tek ve güçlü bir bağlantı açar. Redis’te her işlem için yeni bağlantı açılmaz
        ConnectionMultiplexer = bağlantı yöneticisi*/
		private ConnectionMultiplexer _connectionMultiplexer;

		//Redis’in adres bilgilerini tutar

		//Redis adresini dışarıdan alır.constructor (DI)
		public RedisService(string host, int port)
		{
			_host = host;
			_port = port;
		}

		//Redise bağlan
/* uygulama ayağa kalkarken Redis sunucusuna fiziksel bağlantıyı açar*/
public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

		/*Redis içindeki database’i döner

Redis default olarak 0–15 arası DB sunar*/
		public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
}
}
