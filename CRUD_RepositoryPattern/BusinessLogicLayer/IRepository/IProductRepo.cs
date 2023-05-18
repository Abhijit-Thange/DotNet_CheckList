using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepository
{
    public interface IProductRepo
    {
        Task<List<Product>> GetProductIndex(int? CategoryId, int? page);

        Task<Product> ProductDetails(int? ProductId);
        Task CreateProduct(Product product);
        Task<Product> DeleteProductDetails(int ProductId);
        Task DeleteProduct(int ProductId);
        Task<Product> EditProductDetails(int ProductId);
        Task<bool> EditProduct(int ProductId, Product product);
        Task<int> ProductCount(int? CategoryId);
        List<Category> GetCategoryList();
    }
}
