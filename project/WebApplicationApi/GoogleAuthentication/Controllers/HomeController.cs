using GoogleAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GoogleAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AddToCart(int id)
        {
            return View();
            //        Product product = new Product();
            //        if (HttpContext.Current.Session["ShoppingCart"] == null)
            //        {
            //                List<Item> cart = new List<Item>();
            //                cart.Add(new Item { Product = product.find(id), Quantity = 1 });
            //                Session["cart"] = cart;
            //        }
            //        else
            //        {
            //                List<Item> cart = (List<Item>)Session["cart"];
            //                int index = isExist(id);
            //                if (index != -1)
            //                {
            //                    cart[index].Quantity++;
            //                }
            //                else
            //                {
            //                    cart.Add(new Item { Product = product.find(id), Quantity = 1 });
            //                }
            //                Session["cart"] = cart;
            //        }
            //            return RedirectToAction("Index");
            //    }

            //    public ActionResult Remove(string id)
            //    {
            //            List<Item> cart = (List<Item>)Session["cart"];
            //            int index = isExist(id);
            //            cart.RemoveAt(index);
            //            Session["cart"] = cart;
            //            return RedirectToAction("Index");
            //    }

            //    private int isExist(string id)
            //    {
            //            List<Item> cart = (List<Item>)Session["cart"];
            //            for (int i = 0; i < cart.Count; i++)
            //                if (cart[i].Product.Id.Equals(id))
            //                    return i;
            //            return -1;
            //    }

        }  
    }
}