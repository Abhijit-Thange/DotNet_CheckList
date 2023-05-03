using CRUD_Operations_Product_and_Category.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceLayer
{
    public interface ICategoryBusinessLogic
    {
        Task<List<Category>> GetCategoryIndex(int page);
        Task<Category> CategoryDetails(int CategoryId);
        Task CreateCategory(Category category);
        Task<bool> EditCategory(int CategoryId, Category category);
        Task DeleteCategory(int CategoryId);
    }
}
