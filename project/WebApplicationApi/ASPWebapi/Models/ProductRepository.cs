using ASPWebApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Models;

namespace FoodOrderingWebsite.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodDbContext db;

        public ProductRepository(FoodDbContext db)
        {
            this.db = db;
        }

        public async Task Add(Product product)
        {
            //employee.Id = Guid.NewGuid().ToString();
            db.Products.Add(product);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Product> GetProduct(int id)
        {

            try
            {
                Product product = await db.Products.FindAsync(id);
                if (product == null)
                {
                    return null;
                }
                return product;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            try
            {
                var product1 = await db.Products.ToListAsync();
                return product1.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(int id, Product product)
        {
            try
            {
                //db.Entry(employee).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                var obj = db.Products.Find(id);
                if (obj != null)
                {
                    obj.ProductId = product.ProductId;
                    obj.ProductPicture = product.ProductPicture;
                    obj.ProductPrice= product.ProductPrice;
                    obj.ProductName= product.ProductName;
                    obj.ProductDescription= product.ProductDescription;
                    obj.Quantity= product.Quantity;

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
                Product product2 = await db.Products.FindAsync(id);
                db.Products.Remove(product2);
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

