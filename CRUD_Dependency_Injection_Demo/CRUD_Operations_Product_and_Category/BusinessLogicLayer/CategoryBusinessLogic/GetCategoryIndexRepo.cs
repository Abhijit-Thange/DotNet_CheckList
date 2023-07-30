using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic
{
    public class GetCategoryIndexRepo:IGetCategoryIndex
    {
        DataManager db = new DataManager();

        public async Task<List<Category>> GetCategoryIndex(int page)
        {
            int pageNumber = page;
            int pageSize = 3;
            var Categories = await db.Database.SqlQuery<Category>("sp_getCategoryDataWithPageSize @PageNo, @PageSize",
                new SqlParameter("@PageNo", pageNumber),
                new SqlParameter("@PageSize", pageSize)).ToListAsync();

            return Categories;
        }
    }
}