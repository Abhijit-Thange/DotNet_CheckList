using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI.Repository.Repo
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly DataManager _dataManager;
        public CategoryRepo(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<bool> AddCategory(Category category)
        {
            if (category != null)
            {
                _dataManager.Add(category);
                await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            var data= await _dataManager.categories.FirstOrDefaultAsync(c=>c.CategoryId==CategoryId);
            if (data != null)
            {
                 _dataManager.categories.Remove(data);
                await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dataManager.categories.ToListAsync();
        }

        public async Task<bool> UpdateCategory(int CategoryId, Category category)
        {
            var data=await _dataManager.categories.FirstOrDefaultAsync(c=>c.CategoryId == CategoryId);
            if (data != null)
            {
                _dataManager.Entry(data).CurrentValues.SetValues(category);
                await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Category> CategoryDetails(int CategoryId)
        {
            return await _dataManager.categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
        }
    }
}
