using CRUD_CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Services.IService
{
    public interface ICategories
    {
        Task<List<Category>> GetAllCategories();

        Task<bool> AddCategory(Category category);

        Task<bool> UpdateCategory(int CategoryId, Category category);
        Task<bool> DeleteCategory(int CategoryId);

        Task<Category> CategoryDetails(int CategoryId);
    }
}
