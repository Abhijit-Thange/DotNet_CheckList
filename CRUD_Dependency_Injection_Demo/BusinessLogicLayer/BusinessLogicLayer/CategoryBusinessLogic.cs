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
    public class CategoryBusinessLogic : ICategoryBusinessLogic
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

        public async Task<Category> CategoryDetails(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(x => x.CategoryId == CategoryId);

            return category;
        }

        public async Task CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();            
        }

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

        public async Task DeleteCategory(int CategoryId)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(p => p.CategoryId == CategoryId);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }

        public async Task ActivateCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            category.IsActive = true;
            await db.SaveChangesAsync();
        }
    }
}
