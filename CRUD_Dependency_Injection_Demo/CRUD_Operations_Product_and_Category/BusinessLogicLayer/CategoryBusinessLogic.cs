using BusinessLogicLayer.ServiceLayer;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class CategoryBusinessLogic
    {
        DataManager db = new DataManager();



        public async Task ActivateCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            category.IsActive = true;
            await db.SaveChangesAsync();
        }
    }
}
