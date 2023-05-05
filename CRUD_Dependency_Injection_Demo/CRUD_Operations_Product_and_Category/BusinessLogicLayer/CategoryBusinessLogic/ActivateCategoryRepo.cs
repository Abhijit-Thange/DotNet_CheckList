using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic
{
    public class ActivateCategoryRepo:IActivateCategory
    {
        DataManager db=new DataManager();
        public async Task ActivateCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            category.IsActive = true;
            await db.SaveChangesAsync();
        }
    }
}