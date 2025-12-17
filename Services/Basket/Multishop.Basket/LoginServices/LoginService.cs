namespace Multishop.Basket.LoginServices
{
	public class LoginService : ILoginService
	{
		// IHttpContextAccessor: Şu anki HTTP isteğine ve kullanıcı bilgisine servislerden erişmemizi sağlar
		private readonly IHttpContextAccessor _httpContextAccessor;

		// Constructor: LoginService çalıştığında HttpContextAccessor'ı alır
		public LoginService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		// GetUserId: Kullanıcının token içindeki "sub" claim'ini (yani userId) döner
		public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value; //Her zaman JWT içindeki sub claim’inden gelmeli o yüzden set yok değiştirilemez
	}
}
//HttpContext, o anki HTTP isteğine (request) ait tüm bilgileri taşıyan nesnedir.Şu anda uygulamaya gelen isteğin kimliği, kullanıcısı, header’ları, token’ı, IP’si, vs.