using FoodOrderingWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPWebApi.Controllers
{
       public class ProductController : Controller
    {
        IConfiguration _Configure;
        readonly string apiBaseUrl;
        public ProductController(IConfiguration configuration)
        {
            _Configure = configuration;
            apiBaseUrl = configuration.GetValue<string>("ApiUrls");
        }

        //public async Task<IActionResult> Index()
        //{
        //    List<Product> employeeList = new List<Product>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:7108/api/ProductApi"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            employeeList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
        //        }
        //    }
        //    return View(employeeList);
        //}

       }
}
