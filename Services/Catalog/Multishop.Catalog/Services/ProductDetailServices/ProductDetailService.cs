using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductDetailServices
{
	public class ProductDetailService:IProductDetailService
	{
		private readonly IMongoCollection<ProductDetail> _productDetailColllection;
		private readonly IMapper _mapper;

		public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);  //bağlantı
			var database = client.GetDatabase(_databaseSettings.DatabaseName);  //veritabanı
			_productDetailColllection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);  //koleksiyon-tablo
			_mapper = mapper;
		}

		public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
		{
			var values = _mapper.Map<ProductDetail>(createProductDetailDto);
			await _productDetailColllection.InsertOneAsync(values);
		}

		

		public async Task DeleteProductDetailAsync(string id)
		{
			await _productDetailColllection.DeleteOneAsync(x => x.ProductDetailID == id);
		}

		

		public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
		{
			var values = await _productDetailColllection.Find(x => true).ToListAsync();
			return (_mapper.Map<List<ResultProductDetailDto>>(values));
		}

		public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
		{
			var values = await _productDetailColllection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDetailDto>(values);
		}

	
		

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
		{
			var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
			await _productDetailColllection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, values);

		}

		
	}
}
