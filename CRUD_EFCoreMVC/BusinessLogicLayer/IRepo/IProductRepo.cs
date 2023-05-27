using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepo
{
    public interface IProductRepo
    {
       Task<bool> AddProductAsync(Product product);

        Task<List<Category>> GetCategoriesAsync();

        Task<List<Product>> GetProductAsync(int? CategoryId, int? pageNumber);
        Task<bool> UpdateProductAsync(int ProductId, Product product);
        Task<Product> UpdateProductDetailsAsync(int ProductId);
        Task<bool> DeleteProductAsync(int ProductId);
        Task<Product> DeleteProductDetailsAsync(int ProductId);
     /*   Task<int> ProductCountAsync(int? CategoryId);
     */
    }
}
