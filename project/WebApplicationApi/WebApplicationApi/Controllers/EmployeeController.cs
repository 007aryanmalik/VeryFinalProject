//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System.Net.Http.Headers;
//using FoodOrderingWebsite.Models;
///*
// https://www.c-sharpcorner.com/article/consume-web-api-in-asp-net-mvc-with-crud-actions/
 
// */
//namespace FoodOrderingWebsite.Controllers
//{
//    public class EmployeeController : Controller
//    {
//        IConfiguration _Configure;
//        readonly string apiBaseUrl;
//        public EmployeeController(IConfiguration configuration)
//        {
//            _Configure = configuration;
//            apiBaseUrl = configuration.GetValue<string>("ApiUrls");
//        }

//            public async Task<IActionResult> Index()
//            {
//                List<Employee> employeeList = new List<Employee>();
//                using (var httpClient = new HttpClient())
//                {
//                    using (var response = await httpClient.GetAsync("https://localhost:7108/api/EmployeesApi"))
//                    {
//                        string apiResponse = await response.Content.ReadAsStringAsync();
//                        employeeList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
//                    }
//                }
//                return View(employeeList);
//            }

//        }
    
//}
