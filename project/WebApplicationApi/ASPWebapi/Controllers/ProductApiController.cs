using FoodOrderingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplicationApi.Models;
using ASPWebApi.Models;

namespace ASPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _iProductRepository;

        public ProductApiController(IProductRepository ProductRepository)
        {
            this._iProductRepository = ProductRepository;
        }

        [HttpGet]
        [Route("api/Products/Get")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _iProductRepository.GetProduct();
        }
        [HttpPost]
        [Route("api/Products/Create")]
        public async Task CreateAsync([FromBody] Product Product)
        {
            if (ModelState.IsValid)
            {
                await _iProductRepository.Add(Product);
            }
        }
        [HttpGet]
        [Route("api/Products/Details/{id}")]
        public async Task<Product> Details(int id)
        {
            var result = await _iProductRepository.GetProduct(id);
            return result;
        }
        [HttpPut]
        [Route("api/Products/Edit/{id}")]
        //public async Task EditAsync(int id, [FromBody] Product Product)
        public async Task EditAsync(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                await _iProductRepository.Update(id, product);
            }
        }
        [HttpDelete]
        [Route("api/Products/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _iProductRepository.Delete(id);
        }
    }
}
