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
    public class DeleteCategoryRepo:IDeleteCategory
    {
        DataManager db=new DataManager();
        public async Task DeleteCategory(int CategoryId)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(p => p.CategoryId == CategoryId);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }
    }
}