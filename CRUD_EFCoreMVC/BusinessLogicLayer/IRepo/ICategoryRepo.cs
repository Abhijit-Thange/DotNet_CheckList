using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IRepo
{
    public interface ICategoryRepo
    {
        Task<bool> AddCategoryAsync(Category category);

        Task<List<Category>> GetCategoryAsync();

        Task<bool> UpdateCategoryAsync(int CategoryId,Category category);

        Task<Category> UpdateCategoryDetailsAsync(int CategoryId);

        Task<bool> DeleteCategoryAsync(int CategoryId);

        Task<Category> DeleteCategoryDetailsAsync(int CategoryId);
    }
}
