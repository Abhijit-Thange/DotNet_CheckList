using CRUD_CoreWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Repository.IRepo
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllCategories();

        Task<bool> AddCategory(Category category);

        Task<bool> UpdateCategory(int CategoryId,Category category);

        Task<bool> DeleteCategory(int CategoryId);

        Task<Category> CategoryDetails(int CategoryId);

        Task<bool> UpdateCategoryPatchAsync(int CategoryId, JsonPatchDocument category);
    }
}
