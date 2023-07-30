using BusinessLogicLayer.IRepo;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repo
{
    public class ProductRepo:IProductRepo
    {
        private DataManager _dataManager;

        public ProductRepo(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            _dataManager.products.Add(product);
            await _dataManager.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
             var data= await _dataManager.categories.ToListAsync();
            return data;
        }
        public async Task<List<Product>> GetProductAsync(int? CategoryId, int? page)
        {
              int pageNumber = page ?? 1;
              int pageSize = 3;
            /* var products = await _dataManager.products.FromSqlRaw("EXEC sp_getProductDataWithPageSize @PageNo, @PageSize, @CategoryId",
                 new SqlParameter("@PageNo", pageNumber),
                 new SqlParameter("@PageSize", pageSize),
                 new SqlParameter("@CategoryId", CategoryId)).ToListAsync();
             return products;*/
          /*  var products = await _dataManager.products.FromSqlInterpolated($@"
        EXEC sp_getProductDataWithPageSize 
        @PageNo = {pageNumber}, 
        @PageSize = {pageSize}, 
        @CategoryId = {CategoryId}")

      .ToListAsync();*/
          var products=await _dataManager.products.Where(p=>p.CategoryId==CategoryId).ToListAsync();
            return products;
        }
        
       public async Task<bool> DeleteProductAsync(int ProductId)
       {
           var data = await _dataManager.products.FirstOrDefaultAsync(p=>p.ProductId == ProductId);
           if (data != null)
           {
               _dataManager.products.Remove(data);
               await _dataManager.SaveChangesAsync();
               return true;
           }
           return false;
       }

       public async Task<Product> DeleteProductDetailsAsync(int ProductId)
       {
           return await _dataManager.products.FirstOrDefaultAsync(c => c.ProductId == ProductId);
       }

      

       public async Task<bool> UpdateProductAsync(int ProductId, Product product)
       {
           var data = await _dataManager.products.FirstOrDefaultAsync(c => c.ProductId == ProductId);
           if (data != null)
           {
               _dataManager.Entry(data).CurrentValues.SetValues(product);
               await _dataManager.SaveChangesAsync();
               return true;
           }
           return false;
       }

       public async Task<Product> UpdateProductDetailsAsync(int CategoryId)
       {
           return await _dataManager.products.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
       }
        /*

       public async Task<int> ProductCountAsync(int? CategoryId)
       {
           int count= await _dataManager.products.Count(c => c.CategoryId == CategoryId);
           return count;
       }*/
    }
}
