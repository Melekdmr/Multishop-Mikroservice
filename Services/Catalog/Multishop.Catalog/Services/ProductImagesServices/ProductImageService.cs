using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Dtos.ProductImageDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductImagesServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly IMongoCollection<ProductImage> _productImageColllection;
		private readonly IMapper _mapper;

		public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);  //bağlantı
			var database = client.GetDatabase(_databaseSettings.DatabaseName);  //veritabanı
			_productImageColllection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);//koleksiyon-tablo
			_mapper = mapper;
		}

		public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(createProductImageDto);
			await _productImageColllection.InsertOneAsync(values);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _productImageColllection.DeleteOneAsync(x => x.ProductImageID == id);
		}

		public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
		{
			var values = await _productImageColllection.Find(x => true).ToListAsync();
			return (_mapper.Map<List<ResultProductImageDto>>(values));
		}

		public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
		{
			var values = await _productImageColllection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductImageDto>(values);
		}

		public async  Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(updateProductImageDto);
			await _productImageColllection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);

		}
	}
}
