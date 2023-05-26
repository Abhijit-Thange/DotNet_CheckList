using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product category);

        Task<List<Category>> GetAllCategoriesAsync();

     /*   Task<List<Product>> GetProductAsync(int? CategoryId, int? pageNumber);
        Task<bool> UpdateProductAsync(int CategoryId, Product category);
        Task<Product> UpdateProductDetailsAsync(int CategoryId);

        Task<bool> DeleteProductAsync(int CategoryId);
        Task<Product> DeleteProductDetailsAsync(int CategoryId);
        Task<int> ProductCountAsync(int? CategoryId);
     */
    }
}
