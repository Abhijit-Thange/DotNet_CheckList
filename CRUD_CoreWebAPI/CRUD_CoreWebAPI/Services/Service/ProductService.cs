using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.JsonPatch;

namespace CRUD_CoreWebAPI.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            return await _productRepo.CreateProduct(product);
        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            return await _productRepo.DeleteProduct(ProductId);
        }

        public Task<Product> DeleteProductDetails(int ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditProduct(int ProductId, Product product)
        {
            return await _productRepo.EditProduct(ProductId, product);

        }

        public async Task<bool> UpdateProductPatch(int ProductId,JsonPatchDocument product)
        {
            return await _productRepo.UpdateProductPatch(ProductId, product);
        }

        public Task<List<Product>> GetProductIndex(int? CategoryId, int? page)
        {
            return _productRepo.GetProductIndex(CategoryId, page);
        }

        public Task<int> ProductCount(int? CategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> ProductDetails(int? ProductId)
        {
            return await _productRepo.ProductDetails(ProductId);
        }
    }
}
