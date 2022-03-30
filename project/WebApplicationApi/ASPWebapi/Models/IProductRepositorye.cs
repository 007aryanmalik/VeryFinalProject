using FoodOrderingWebsite.Models;

namespace ASPWebApi.Models
{
    public interface IProductRepository
    {

        Task Add(Product ProductId);
        Task Update(int ProductId, Product product);
        Task Delete(int ProductId);
        Task<Product> GetProduct(int ProductId);
        Task<IEnumerable<Product>> GetProduct();
    }
}
