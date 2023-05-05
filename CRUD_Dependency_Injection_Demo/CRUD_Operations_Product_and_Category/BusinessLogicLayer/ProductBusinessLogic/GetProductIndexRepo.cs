using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.ProductService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.ProductBusinessLogic
{
    public class GetProductIndexRepo:IGetProductIndex
    {
        DataManager db=new DataManager();   
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
    }
}