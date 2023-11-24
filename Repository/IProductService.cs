using ShoppingKart.Models;

namespace ShoppingKart.Repository
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
    }
}
