using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Services.Service
{
    public class Categories : ICategories
    {
        private readonly ICategoryRepo _categoryRepo;

        public Categories(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepo.GetAllCategories();
        }

        public async Task<bool> AddCategory(Category category)
        {
            return await _categoryRepo.AddCategory(category);
        }

       public async Task<bool> UpdateCategory(int CategoryId, Category category)
        {
            return await _categoryRepo.UpdateCategory(CategoryId, category);
        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            return await _categoryRepo.DeleteCategory(CategoryId);
        }

        public async Task<Category> CategoryDetails(int CategoryId)
        {
            return await _categoryRepo.CategoryDetails(CategoryId);
        }

        public async Task<bool> UpdateCategoryPatchAsync(int CategoryId, JsonPatchDocument category)
        {
            return await _categoryRepo.UpdateCategoryPatchAsync(CategoryId, category);
        }
    }
}
