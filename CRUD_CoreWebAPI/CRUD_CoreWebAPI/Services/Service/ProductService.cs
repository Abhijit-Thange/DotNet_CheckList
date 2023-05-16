﻿using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using CRUD_CoreWebAPI.Services.IService;

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

        public Task DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProductDetails(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditProduct(int ProductId, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> EditProductDetails(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductIndex(int? CategoryId, int? page)
        {
            return _productRepo.GetProductIndex(CategoryId, page);
        }

        public Task<int> ProductCount(int? CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> ProductDetails(int? ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
