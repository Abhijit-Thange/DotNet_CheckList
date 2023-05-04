using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceLayer
{
    public interface IProductBusinessLogic
    {
        Task<List<Product>> GetProductIndex(int? CategoryId, int? page);
        Task<Product> ProductDetails(int? ProductId);
        Task AddProduct(Product product);
        Task<Product> EditProduct(int ProductId, Product products);
        Task DeleteProduct(int ProductId);
    }
}
