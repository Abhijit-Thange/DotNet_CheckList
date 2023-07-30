using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI.Repository.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataManager _dataManager;

        public ProductRepo(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<bool> CreateProduct( Product product)
        {
           if(product != null)
            {
                _dataManager.products.Add(product);
                await  _dataManager.SaveChangesAsync();
                return true;
            }
           return false;
        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
           var data= await _dataManager.products.FirstOrDefaultAsync(p=>p.ProductId==ProductId);
            if(data != null)
            {
                _dataManager.products.Remove(data);
                await  _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EditProduct(int ProductId, Product product)
        {
            var data=await _dataManager.products.FirstOrDefaultAsync(x => x.ProductId == ProductId);
            if(data != null)
            {
               _dataManager.Entry(data).CurrentValues.SetValues(product);
              var n=  await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProductPatch(int ProductId, JsonPatchDocument product)
        {
            var data= await _dataManager.products.FirstOrDefaultAsync(p=>p.ProductId == ProductId);
            if(data != null)
            {
                product.ApplyTo(data);
                await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetProductIndex(int? CategoryId, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;
            var products = await _dataManager.products.FromSqlRaw("EXEC sp_getProductDataWithPageSize @PageNo, @PageSize, @CategoryId",
                new SqlParameter("@PageNo", pageNumber),
                new SqlParameter("@PageSize", pageSize),
                new SqlParameter("@CategoryId", CategoryId)).ToListAsync();
            return products;
        }

        public async Task<Product> ProductDetails(int? ProductId)
        {
            return await _dataManager.products.FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }

        public Task<int> ProductCount(int? CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
