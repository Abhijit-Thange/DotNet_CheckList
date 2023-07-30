using BusinessLogicLayer.IRepo;
using DataAccessLayer.Models;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            return await _categoryRepo.AddCategoryAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int CategoryId)
        {
            return await _categoryRepo.DeleteCategoryAsync(CategoryId);
        }

        public async Task<Category> DeleteCategoryDetailsAsync(int CategoryId)
        {
           return await _categoryRepo.DeleteCategoryDetailsAsync(CategoryId);
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
          return await _categoryRepo.GetCategoryAsync();
        }

        public async Task<bool> UpdateCategoryAsync(int CategoryId, Category category)
        {
            return await _categoryRepo.UpdateCategoryAsync(CategoryId, category);
        }

        public async Task<Category> UpdateCategoryDetailsAsync(int CategoryId)
        {
            return await _categoryRepo.UpdateCategoryDetailsAsync(CategoryId);
        }
    }
}
