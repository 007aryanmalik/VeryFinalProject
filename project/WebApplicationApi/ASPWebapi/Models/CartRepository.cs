using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsite.Models
{
    public class CartRepository : ICartsRepository
    {
        private readonly FoodDbContext db;

        public CartRepository(FoodDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Cart cart)
        {
            //employee.Id = Guid.NewGuid().ToString();
            db.Carts.Add(cart);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Cart> GetCart(int id)
        {

            try
            {
                Cart cart = await db.Carts.FindAsync(id);
                if (cart == null)
                {
                    return null;
                }
                return cart;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetCart()
        {
            try
            {
                var cart1 = await db.Carts.ToListAsync();
                return cart1.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(int id, Cart cart)
        {
            try
            {
                //db.Entry(employee).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                var obj = db.Carts.Find(id);
                if (obj != null)
                {
                    //obj.CartId = cart.CartId;
                    obj.Quantity=cart.Quantity;

                   db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Cart cart2 = await db.Carts.FindAsync(id);
                db.Carts.Remove(cart2);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

           //private bool EmployeeExists(string id)
        //{
        //    //return db.Employees.Count(e => e.Id == id) > 0;
        //}

    }
}

