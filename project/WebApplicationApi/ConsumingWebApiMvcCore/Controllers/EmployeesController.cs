using ConsumingWebApiMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumingWebApiMvcCore.Controllers
{
    public class EmployeesController : Controller
    {
        IConfiguration _Configure;
        readonly string apiBaseUrl;
        public EmployeesController(IConfiguration configuration)
        {
            _Configure = configuration;
            apiBaseUrl = configuration.GetValue<string>("ApiUrls");
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employeeList = new List<Employee>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7108/api/EmployeesApi/api/Employees/Get"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employeeList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return View(employeeList);
        }

       // public ViewResult Details() => View();

    
        public async Task<IActionResult> Details(int? id)
        {
            Employee employee = new Employee();
            using (var httpClient = new HttpClient())                         //[Route("api/Employees/Details/{id}")]
            {
                using (var response = await httpClient.GetAsync("https://localhost:7108/api/EmployeesApi/api/Employees/Details/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(employee);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            Employee insertEmployee = new Employee();
            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                httpClient.BaseAddress = new Uri("https://localhost:7108/api/EmployeesApi/");
                                          //https://localhost:7108/api/ProductApi
                //https://localhost:7108/api/EmployeesApi/api/Employees/Create

                var postTask = httpClient.PostAsJsonAsync<Employee>("api/Employees/Create", employee);
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
           
            ModelState.AddModelError(String.Empty,"Server Error... Please Contact Administrator ");
            return View(insertEmployee);
        }



        public async Task<ActionResult> Edit(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7108/api/EmployeesApi/api/Employees/Details/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<Employee>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Employee Emp)
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("https://localhost:7108/api/EmployeesApi/api/Employees/Edit/" + id,Emp);
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
                HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7108/api/EmployeesApi/api/Employees/Details/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var Employee = JsonConvert.DeserializeObject<Employee>(responseData);

                    return View(Employee);
                }
            }
            return View("Error");
        }



        [HttpPost]
        public async Task<ActionResult> Delete(int id, Employee Emp)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7108/api/EmployeesApi/api/Employees/Delete/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }


    }
}
