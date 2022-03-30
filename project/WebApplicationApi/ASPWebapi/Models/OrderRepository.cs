using FoodOrderingWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationApi.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDbContext db;

        public OrderRepository(FoodDbContext db)
        {
            this.db = db;
        }
        public async Task Add(Order order)
        {
            db.Orders.Add(order);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Order> GetOrder(int id)
        {
            try
            {
                Order order = await db.Orders.FindAsync(id);
                if (order == null)
                {
                    return null;
                }
                return order;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            try
            {
                var order1 = await db.Orders.ToListAsync();
                return order1.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
    }
}
