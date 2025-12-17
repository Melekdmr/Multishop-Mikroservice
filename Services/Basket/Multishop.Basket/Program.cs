using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Multishop.Basket.LoginServices;
using Multishop.Basket.Services;
using Multishop.Basket.Settings;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
// 11  Authorization policy oluşturuluyor
// RequireAuthenticatedUser() → Bu policy, tüm controller/metotlarda kullanıcı giriş yapmış (authenticated) olmasını zorunlu kılar
var requiredAuthorizePolicy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser() // Kullanıcının giriş yapmış olması gerekiyor
	.Build(); // Policy nesnesi oluşturuluyor
//sub 'ın maplemesini kaldırdık

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

//  1️  JWT Authentication ekleniyor
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(opt =>
	{
		//opt.MapInboundClaims = false;
		// IdentityServer URL: Token doğrulaması buradan yapılacak

		opt.Authority = builder.Configuration["IdentityServerUrl"];

		// Bu API'nin hedef kitlesi (audience)
		opt.Audience = "ResourceBasket";

		// Geliştirme ortamında HTTPS zorunluluğunu kapat
		opt.RequireHttpsMetadata = false;
	});
//  Bu sayede her HTTP isteğinde JWT token kontrol edilir
//  LoginService token içinden "sub" claim ile userId alır

// 2️ HttpContextAccessor servisi ekleniyor
builder.Services.AddHttpContextAccessor();
//  LoginService, hangi kullanıcının request gönderdiğini bilmek için bunu kullanır

// 3️ LoginService ve BasketService DI konteynerına ekleniyor
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();
//  Scoped: Her HTTP isteği için ayrı instance
//  Controller constructor üzerinden bu servisleri alabilir
//  BasketController → IBasketService ve ILoginService kullanıyor

// 4️  RedisSettings appsettings.json’dan çekiliyor
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
//  Redis host ve port ayarlarını güçlü tipli şekilde kullanmamızı sağlar
//  RedisService bu ayarları alarak bağlantıyı kuracak

// 5️  RedisService singleton olarak ekleniyor
builder.Services.AddSingleton<RedisService>(sp =>
{
	// 5.1️  RedisSettings alınır
	var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;

	// 5.2️ RedisService instance oluşturulur
	var redis = new RedisService(redisSettings.Host, redisSettings.Port);

	// 5.3️  Redis'e fiziksel bağlantı açılır
	redis.Connect();

	// 5.4️  Singleton olarak DI konteynerına eklenir
	return redis;
});
//  Singleton: Tüm uygulama boyunca tek bir RedisService kullanılır
//  BasketService bu tek instance üzerinden Redis’e veri okuma/yazma işlemi yapar
//  Böylece her işlem için yeni bağlantı açılmaz, performans artar

// Add services to the container.



//  11 Controller’lara global olarak authorization uygulanıyor
builder.Services.AddControllers(opt =>
{
	// Add global filter → tüm controller/action'lar için yukarıdaki policy geçerli olacak
	opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePolicy));
});
//  Sonuç: Artık tüm API endpointleri, giriş yapmış kullanıcılar için erişilebilir
//  Eğer kullanıcı giriş yapmamışsa 401 Unauthorized döner


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
