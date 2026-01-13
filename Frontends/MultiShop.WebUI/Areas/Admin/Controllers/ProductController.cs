using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.DtoLayer.CatalogDtos.CategoryDtos;
using Multishop.DtoLayer.CatalogDtos.ProductDtos;
using Multishop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]  //sınıf seviyesinde olsun
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
     
            private readonly IHttpClientFactory _httpClientFactory;

            public ProductController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
            [Route("Index")]
            public async Task<IActionResult> Index()
            {
                ViewBag.v1 = "Anasayfa";
                ViewBag.v2 = "Ürünler";
                ViewBag.v3 = "Ürün Listesi";
                ViewBag.v0 = "Ürün İşlemleri";

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:7060/api/Product");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); //json dan metine çevirir listele,id ye göre getir 
                    return View(values);
                }
                return View();
            }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("http://localhost:7060/api/Categories");
            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values= JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues=(from c in values
                                                 select new SelectListItem
                                                 {
                                                     Text = c.CategoryName,
                                                     Value = c.CategoryID
                                                 }).ToList();

            ViewBag.CategoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto); //metni jsona çevir
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMassage = await client.PostAsync("http://localhost:7060/api/Product", stringContent);
            if (responseMassage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]


        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:7060/api/Product/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }


        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme Sayfası";
            ViewBag.v0 = "Ürün İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("http://localhost:7060/api/Categories");
            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from c in values
                                                   select new SelectListItem
                                                   {
                                                       Text = c.CategoryName,
                                                       Value = c.CategoryID
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
            var responseMessge2 = await client.GetAsync($"http://localhost:7060/api/Product/{id}");
            if (responseMessge2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessge2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData2);
                return View(values2);

            }
            return View();
        }
        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto); //metni json a çevir
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessge = await client.PutAsync($"http://localhost:7060/api/Product/", stringContent);
            if (responseMessge.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }
            return View();
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7060/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData); //json dan metine çevirir listele,id ye göre getir 
                return View(values);
            }
            return View();
        }
    }
}


