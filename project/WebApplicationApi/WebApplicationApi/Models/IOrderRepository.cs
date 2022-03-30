using FoodOrderingWebsite.Models;

namespace WebApplicationApi.Models
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        // Task Update(int id, Cart cart);
        //Task Delete(int OrderId);
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetOrder();
    }
}
