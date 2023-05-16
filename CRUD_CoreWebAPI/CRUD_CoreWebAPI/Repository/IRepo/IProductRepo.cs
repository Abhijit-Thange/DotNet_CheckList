using CRUD_CoreWebAPI.Models;

namespace CRUD_CoreWebAPI.Repository.IRepo
{
    public interface IProductRepo
    {
        Task<List<Product>> GetProductIndex(int? CategoryId, int? page);
        Task<Product> ProductDetails(int? ProductId);
        Task<bool> CreateProduct(Product product);
        Task<Product> DeleteProductDetails(int ProductId);
        Task DeleteProduct(int ProductId);
        Task<Product> EditProductDetails(int ProductId);
        Task<bool> EditProduct(int ProductId, Product product);
        Task<int> ProductCount(int? CategoryId);
    }
}
