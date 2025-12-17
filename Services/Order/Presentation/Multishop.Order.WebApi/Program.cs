using Microsoft.AspNetCore.Authentication.JwtBearer;
using Multishop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;
using Multishop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using Multishop.Order.Application.Feature.Mediator.Handlers;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.Services;
using Multishop.Order.Persistence.Context;
using Multishop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.Authority = builder.Configuration["IdentityServerUrl"];
	opt.Audience = "ResourceOrder";
	opt.RequireHttpsMetadata = false;
});

builder.Services.AddDbContext<OrderContext>();
//Service Registiration'ý Program.cs de çaðýrýyoruz.
/* Dependency Injection (baðýmlýlýk enjeksiyonu) yapýsýný kullanarak IRepository<> arayüzünü her istek için Repository<> sýnýfý ile eþleþtirir. Ayrýca AddApplicationServices metodu, uygulamanýn servis katmanýndaki özel servisleri (örneðin handler’lar, validator’lar vb.) otomatik olarak servislere ekler.*/
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddApplicationServices(builder.Configuration);
#region

builder.Services.AddScoped<GetAddressOueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();


builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();

//builder.Services.AddScoped<GetOrderingByIdQueryHandler>();
//builder.Services.AddScoped<GetOrderingOueryHandler>();
//builder.Services.AddScoped<CreateOrderingCommandHandler>();
//builder.Services.AddScoped<UpdateOrderingCommandHandler>(); 
//builder.Services.AddScoped<RemoveOrderingCommandHandler>();
#endregion
// Add services to the container.

builder.Services.AddControllers();
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
