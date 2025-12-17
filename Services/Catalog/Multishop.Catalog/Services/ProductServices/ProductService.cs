using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductServices
{
	public class ProductService : IProductService
	{
		private readonly IMongoCollection<Product> _productColllection;
		private readonly IMapper _mapper;

		public ProductService(IMapper mapper ,IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);  //bağlantı
			var database = client.GetDatabase(_databaseSettings.DatabaseName);  //veritabanı
			_productColllection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);  //koleksiyon-tablo
			_mapper = mapper;
		}

		public async Task CreateProductAsync(CreateProductDto createProductDto)
		{
			var values=_mapper.Map<Product>(createProductDto);
			await _productColllection.InsertOneAsync(values);
		}

		public async Task DeleteProductAsync(string id)
		{
			await _productColllection.DeleteOneAsync(x => x.ProductId == id);
		}

		public async Task<List<ResultProductDto>> GetAllProductAsync()
		{
			var values= await _productColllection.Find( x => true ).ToListAsync();
			return (_mapper.Map<List<ResultProductDto>>(values));
		}

		public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
		{
			var values= await _productColllection.Find<Product>(x=>x.ProductId==id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDto>(values);
		}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
		{
			var values = _mapper.Map<Product>(updateProductDto);
			await _productColllection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);

		}
	}
}
