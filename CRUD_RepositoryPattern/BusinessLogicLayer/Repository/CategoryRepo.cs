using BusinessLogicLayer.IRepository;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        DataManager db = new DataManager();
        public async Task ActivateCategory(int CategoryId)
        {

            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            category.IsActive = true;
            await db.SaveChangesAsync();
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

        public async Task DeactivateCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            category.IsActive = false;
            await db.SaveChangesAsync();
        }

        public async Task DeleteCategory(int CategoryId)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(p => p.CategoryId == CategoryId);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }

        public async Task<Category> DeleteCategoryDetails(int CategoryId)
        {
            return await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);

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

        public async Task<Category> EditCategoryDetails(int CategoryId)
        {
            return await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
        }

        public async Task<List<Category>> GetCategoryIndex(int page)
        {
            int pageNumber = page;
            int pageSize = 3;
            var Categories = await db.Database.SqlQuery<Category>("sp_getCategoryDataWithPageSize @PageNo, @PageSize",
                new SqlParameter("@PageNo", pageNumber),
                new SqlParameter("@PageSize", pageSize)).ToListAsync();
            return Categories;
        }

        public async Task<int> CategoryCount()
        {
            return await db.Categories.CountAsync();
        }

    }
}
