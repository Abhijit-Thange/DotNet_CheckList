using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoryIndex(int page);

        Task<Category> CategoryDetails(int CategoryId);
        Task CreateCategory(Category category);
        Task<Category> DeleteCategoryDetails(int CategoryId);
        Task DeleteCategory(int CategoryId);
        Task<Category> EditCategoryDetails(int CategoryId);
        Task<bool> EditCategory(int CategoryId, Category category);
        Task ActivateCategory(int CategoryId);
        Task DeactivateCategory(int CategoryId);
        Task<int> CategoryCount();

    }
}
