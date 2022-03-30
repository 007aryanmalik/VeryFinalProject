using FoodOrderingWebsite.Models;

namespace WebApplicationApi.Models
{
    public class OrderRepository : IOrderRepository
    {
        public Task Add(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrder()
        {
            throw new NotImplementedException();
        }
    }
}
