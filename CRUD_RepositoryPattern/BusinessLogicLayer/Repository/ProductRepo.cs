using BusinessLogicLayer.IRepository;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class ProductRepo : IProductRepo
    {
        DataManager db = new DataManager();
        public async Task CreateProduct(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();

        }

        public async Task DeleteProduct(int ProductId)
        {
            var product = await db.Products.FindAsync(ProductId);
            db.Products.Remove(product);
            await db.SaveChangesAsync();

        }

        public async Task<Product> DeleteProductDetails(int ProductId)
        {
           return await db.Products.FindAsync(ProductId);
        }

        public async Task<bool> EditProduct(int ProductId, Product product)
        {
            var products = await db.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (product != null)
            {
                products.CategoryId = product.CategoryId;
                products.ProductName = product.ProductName;
                products.Price = product.Price;
                products.MfgDate = product.MfgDate;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Product> EditProductDetails(int ProductId)
        {
           return await db.Products.FirstOrDefaultAsync(p=>p.ProductId == ProductId);
        }

        public async Task<List<Product>> GetProductIndex(int? CategoryId, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;
            var products = await db.Database.SqlQuery<Product>("sp_getProductDataWithPageSize @PageNo, @PageSize, @CategoryId",
                new SqlParameter("@PageNo", pageNumber),
                new SqlParameter("@PageSize", pageSize),
                new SqlParameter("@CategoryId", CategoryId)).ToListAsync();
            return products;

        }

        public async Task<int> ProductCount(int? CategoryId)
        {
            var d=await db.Products.Where(p=>p.CategoryId == CategoryId).CountAsync(); 
          var data= db.Products.ToList().Where(p=>p.CategoryId== CategoryId).Count();
            return data;
        }

        public async Task<Product> ProductDetails(int? ProductId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(a => a.ProductId == ProductId);
            return product;
        }

        public List<Category> GetCategoryList()
        {
            return db.Categories.ToList();
        }
    }
}
