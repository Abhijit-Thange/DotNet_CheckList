using BusinessLogicLayer.IRepo;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private DataManager _dataManager; 

        public CategoryRepo(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
           _dataManager.categories.Add(category);
            await _dataManager.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteCategoryAsync(int CategoryId)
        {
            var data = await _dataManager.categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            if(data!=null)
            {
                _dataManager.categories.Remove(data);
                await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Category> DeleteCategoryDetailsAsync(int CategoryId)
        {
            return await _dataManager.categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            var data = await _dataManager.categories.ToListAsync();
            return data;
        }

        public async Task<bool> UpdateCategoryAsync(int CategoryId, Category category)
        {
            var data = await _dataManager.categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
            if (data != null)
            {
                _dataManager.Entry(data).CurrentValues.SetValues(category);
                await _dataManager.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Category> UpdateCategoryDetailsAsync(int CategoryId)
        {
            return await _dataManager.categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
        }
    }
}
