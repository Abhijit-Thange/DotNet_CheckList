using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic
{
    public class DeactivateCategoryRepo:IDeactivateCategory
    {
        DataManager db=new DataManager();
        public async Task DeactivateCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            category.IsActive = false;
            await db.SaveChangesAsync();
        }

    }
}