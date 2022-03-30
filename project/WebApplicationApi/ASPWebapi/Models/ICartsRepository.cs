namespace FoodOrderingWebsite.Models
{
    public interface ICartsRepository
    {
        Task Add(Cart cart);
       Task Update(int id, Cart cart);
        Task Delete(int id);
        Task<Cart> GetCart(int id);
        Task<IEnumerable<Cart>> GetCart();
    }
}
