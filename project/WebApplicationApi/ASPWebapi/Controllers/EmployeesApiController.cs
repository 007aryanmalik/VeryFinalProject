//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using FoodOrderingWebsite.Models;

//namespace FoodOrderingWebsite.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeesApiController : ControllerBase
//    {
//        private readonly IEmployeeRepository _iEmployeeRepository;

//        public EmployeesApiController(IEmployeeRepository employeeRepository)
//        {
//            this._iEmployeeRepository = employeeRepository;
//        }

//        [HttpGet]
//        [Route("api/Employees/Get")]
//        public async Task<IEnumerable<Employee>> Get()
//        {
//            return await _iEmployeeRepository.GetEmployees();
//        }
//        [HttpPost]
//        [Route("api/Employees/Create")]
//        public async Task CreateAsync([FromBody] Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                await _iEmployeeRepository.Add(employee);
//            }
//        }
//        [HttpGet]
//        [Route("api/Employees/Details/{id}")]
//        public async Task<Employee> Details(int id)
//        {
//            var result = await _iEmployeeRepository.GetEmployee(id);
//            return result;
//        }
//        [HttpPut]
//        [Route("api/Employees/Edit/{id}")]
//        //public async Task EditAsync(int id, [FromBody] Employee employee)
//        public async Task EditAsync(int id, Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                await _iEmployeeRepository.Update(id, employee);
//            }
//        }
//        [HttpDelete]
//        [Route("api/Employees/Delete/{id}")]
//        public async Task DeleteConfirmedAsync(int id)
//        {
//            await _iEmployeeRepository.Delete(id);
//        }

//    }
//}
