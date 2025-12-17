using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;
using System.Collections.Generic;

namespace Multishop.Catalog.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		//Category belgelerinin tutulduğu MongoDB koleksiyonuna sınıf içinde erişim sağlayan bir field tanımlar.
		private readonly IMongoCollection<Category> _categoriesCollection;

		//nesneler arası veri dönüşümünü yapmak için sınıf içinde erişilebilecek bir mapper nesnesi tanımlar.
		private readonly IMapper _mapper;

		public CategoryService(IMapper mapper ,IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);  //bağlantı
			var database = client.GetDatabase(_databaseSettings.DatabaseName);   //veritabanı
			_categoriesCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectiionName);//koleksiyon-tablo
			_mapper = mapper;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
		{
			var values = _mapper.Map<Category>(createCategoryDto);

			await _categoriesCollection.InsertOneAsync(values);
		}

		public async Task DeleteCategoryAsync(string id)
		{
			await _categoriesCollection.DeleteOneAsync(x=>x.CategoryID==id);
		}

		public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
		{
			var values=await _categoriesCollection.Find( x=>true).ToListAsync();
			return (_mapper.Map< List<ResultCategoryDto>>(values));
		}

		public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
		{
			var values = await _categoriesCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdCategoryDto>(values);
		}

		public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
		{
			var values = _mapper.Map<Category>(updateCategoryDto);
			await _categoriesCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
		}
	}
}
