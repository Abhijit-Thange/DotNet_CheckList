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

        public async Task<List<Category>> GetCategoryAsync()
        {
          return await _categoryRepo.GetCategoryAsync();
        }

        public Task<bool> UpdateCategoryAsync(int CategoryId, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
