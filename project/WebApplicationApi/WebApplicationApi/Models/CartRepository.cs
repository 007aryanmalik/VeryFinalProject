namespace FoodOrderingWebsite.Models
{
    public class CartRepository : ICartsRepository
    {
        public Task Add(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetCart()
        {
            throw new NotImplementedException();
        }
    }
}
