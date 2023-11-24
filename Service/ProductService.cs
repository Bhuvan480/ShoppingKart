using ShoppingKart.Data;
using ShoppingKart.Models;
using ShoppingKart.Repository;

namespace ShoppingKart.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public List<ProductModel> GetProducts()
        {
            return _db.Products.ToList();
        }
    }
}
