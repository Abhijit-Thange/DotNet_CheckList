using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic
{
    public class UpdateCategoryRepo:IUpdateCategory
    {
        DataManager db=new DataManager();
        public async Task<bool> EditCategory(int CategoryId, Category category)
        {
            var data = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            if (data != null)
            {
                data.CategoryId = category.CategoryId;
                data.CategoryName = category.CategoryName;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}