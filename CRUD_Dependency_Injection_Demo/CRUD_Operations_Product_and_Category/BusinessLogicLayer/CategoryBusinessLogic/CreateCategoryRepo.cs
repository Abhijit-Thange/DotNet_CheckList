using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic
{
    public class CreateCategoryRepo:ICreateCategory
    {
        DataManager db=new DataManager();
        public async Task CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }
    }
}