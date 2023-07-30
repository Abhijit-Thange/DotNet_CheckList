using CRUD_CoreWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CRUD_CoreWebAPI.Services.IService
{
    public interface IProductService
    {
        Task<List<Product>> GetProductIndex(int? CategoryId, int? page);
        Task<Product> ProductDetails(int? ProductId);
        Task<bool> CreateProduct(Product product);
        Task<Product> DeleteProductDetails(int ProductId);
        Task<bool> DeleteProduct(int ProductId);
        Task<bool> UpdateProductPatch(int ProductId,JsonPatchDocument product);
        Task<bool> EditProduct(int ProductId, Product product);
        Task<int> ProductCount(int? CategoryId);
    }
}
