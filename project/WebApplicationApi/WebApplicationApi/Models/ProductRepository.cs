using FoodOrderingWebsite.Models;

namespace WebApplicationApi.Models
{
    public class ProductRepository : IProductRepository
    {
        public Task Add(Product ProductId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetOrder(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Task Update(int ProductId, Product cart)
        {
            throw new NotImplementedException();
        }
    }
}
