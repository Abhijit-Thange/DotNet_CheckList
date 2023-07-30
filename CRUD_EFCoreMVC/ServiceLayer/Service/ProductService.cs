using BusinessLogicLayer.IRepo;
using DataAccessLayer.Models;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            return await _productRepo.AddProductAsync(product); 
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _productRepo.GetCategoriesAsync();
        }

        public async Task<List<Product>> GetProductAsync(int? CategoryId, int? pageNumber)
        {
            return await _productRepo.GetProductAsync(CategoryId, pageNumber);
        }

           public async Task<bool> DeleteProductAsync(int ProductId)
           {
               return await _productRepo.DeleteProductAsync(ProductId);
           }

           public async Task<Product> DeleteProductDetailsAsync(int ProductId)
           {
               return await _productRepo.DeleteProductDetailsAsync(ProductId);
           }

           public async Task<bool> UpdateProductAsync(int ProductId, Product product)
           {
               return await _productRepo.UpdateProductAsync(ProductId, product);
           }

           public async Task<Product> UpdateProductDetailsAsync(int ProductId)
           {
               return await _productRepo.UpdateProductDetailsAsync(ProductId);
           }

       /*   public async Task<int> ProductCountAsync(int? CategoryId)
           {
               return await _productRepo.ProductCountAsync(CategoryId);
           }*/
    }
}
