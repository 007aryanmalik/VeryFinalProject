using GoogleAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoogleAuthentication.Controllers
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
        public async Task<IActionResult> Index()
        {
            List<Product> productList = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7108/api/ProductApi/api/Products/Get/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(productList);
        }

        // public ViewResult Details() => View();


        public async Task<IActionResult> Details(int? id)
        {
            Product product = new Product();
            using (var httpClient = new HttpClient())                         //[Route("api/Products/Details/{id}")]
            {
                using (var response = await httpClient.GetAsync("https://localhost:7108/api/ProductApi/api/Products/Details/"+id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<Product>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            Product insertProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(Product), Encoding.UTF8, "application/json");
                httpClient.BaseAddress = new Uri("https://localhost:7108/api/ProductApi/");

                //https://localhost:7108/api/ProductsApi/api/Products/Create

                var postTask = httpClient.PostAsJsonAsync<Product>("api/Products/Create", product);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result;
                }
            }

            ModelState.AddModelError(String.Empty, "Server Error... Please Contact Administrator ");
            return View(insertProduct);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7108/api/ProductApi/api/Products/Details/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Product = JsonConvert.DeserializeObject<Product>(responseData);

                return View(Product);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            using (var client = new HttpClient())
            {
                                                                                  // https://localhost:7108/api/ProductApi/api/Products/Edit/2
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("https://localhost:7108/api/ProductApi/api/Products/Edit/"+id, product);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }


        //Delete
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7108/api/ProductApi/api/Products/Details/"+id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var product = JsonConvert.DeserializeObject<Product>(responseData);

                    return View(product);
                }
            }
            return View("Error");
        }



        [HttpPost]
        public async Task<ActionResult> Delete(int id, Product product)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7108/api/ProductApi/api/Products/Delete/"+id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }


    }
}