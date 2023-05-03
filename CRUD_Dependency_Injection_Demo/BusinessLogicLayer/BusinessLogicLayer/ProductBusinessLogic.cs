using BusinessLogicLayer.ServiceLayer;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        DataManager db=new DataManager();
        public async Task AddProduct(Product product)
        {
             db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProduct(int ProductId)
        {
            Product product = await db.Products.FindAsync(ProductId);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }

        public async Task<bool> EditProduct(int ProductId, Product products)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (product != null)
            {
                product.CategoryId = products.CategoryId;
                product.ProductName = products.ProductName;
                product.Price = products.Price;
                product.MfgDate = products.MfgDate;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetProductIndex(int? CategoryId, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;
            var products = await db.Database.SqlQuery<Product>("sp_getProductDataWithPageSize @PageNo, @PageSize, @CategoryId",
                new SqlParameter("@PageNo", pageNumber),
                new SqlParameter("@PageSize", pageSize),
                new SqlParameter("@CategoryId", CategoryId)).ToListAsync();
            return products;
        }

        public async Task<Product> ProductDetails(int? ProductId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(a => a.ProductId == ProductId);
            return product;
        }
    }
}
