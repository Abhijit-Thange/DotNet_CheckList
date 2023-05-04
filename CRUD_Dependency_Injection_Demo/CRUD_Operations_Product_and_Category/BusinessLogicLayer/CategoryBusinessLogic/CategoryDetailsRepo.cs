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
    public class CategoryDetailsRepo:ICategoryDetails
    {
        DataManager db=new DataManager();
        public async Task<Category> CategoryDetails(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(x => x.CategoryId == CategoryId);

            return category;
        }
    }
}