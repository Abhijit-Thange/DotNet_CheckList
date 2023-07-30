using BusinessLogicLayer.IRepository;
using CRUD_Operations_Product_and_Category.Models;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _ActivateCategory;
        private readonly ICategoryRepo _DeactivateCategory;
        private readonly ICategoryRepo _CategoryDetails;
        private readonly ICategoryRepo _CreateCategory;
        private readonly ICategoryRepo _DeleteCategory;
        private readonly ICategoryRepo _EditCategory;
        private readonly ICategoryRepo _EditCategoryDetails;
        private readonly ICategoryRepo _GetCategoryIndex;
        private readonly ICategoryRepo _DeleteCategoryDetails;
        private readonly ICategoryRepo _CategoryCount;

        public CategoryService(ICategoryRepo activateCategory, ICategoryRepo deactivateCategory,
                               ICategoryRepo categoryDetails, ICategoryRepo createCategory,
                               ICategoryRepo deleteCategory, ICategoryRepo editCategory,
                               ICategoryRepo getCategoryIndex, ICategoryRepo deleteCategoryDetails,
                               ICategoryRepo editCategoryDetails, ICategoryRepo categoryCount)
        {
            _ActivateCategory = activateCategory;
            _DeactivateCategory = deactivateCategory;
            _CategoryDetails = categoryDetails;
            _CreateCategory = createCategory;
            _DeleteCategory = deleteCategory;
            _EditCategory = editCategory;
            _GetCategoryIndex = getCategoryIndex;
            _DeleteCategoryDetails = deleteCategoryDetails;
            _EditCategoryDetails = editCategoryDetails;
            _CategoryCount = categoryCount;
        }

        public Task ActivateCategory(int CategoryId)
        {
            return _ActivateCategory.ActivateCategory(CategoryId);
        }

        public Task<int> CategoryCount()
        {
            return _CategoryCount.CategoryCount();
        }

        public Task<Category> CategoryDetails(int CategoryId)
        {
            return _CategoryDetails.CategoryDetails(CategoryId);
        }

        public Task CreateCategory(Category category)
        {
            return _CreateCategory.CreateCategory(category);
        }

        public Task DeactivateCategory(int CategoryId)
        {
            return _DeactivateCategory.DeactivateCategory(CategoryId);
        }


        public Task DeleteCategory(int CategoryId)
        {
            return _DeleteCategory.DeleteCategory(CategoryId);
        }

        public Task<Category> DeleteCategoryDetails(int CategoryId)
        {
            return _DeleteCategoryDetails.DeleteCategoryDetails(CategoryId);
        }

        public Task<Category> EditCategoryDetails(int CategoryId)
        {
            return _EditCategoryDetails.EditCategoryDetails(CategoryId);
        }
        public Task<bool> EditCategory(int CategoryId, Category category)
        {
            return _EditCategory.EditCategory(CategoryId, category);
        }

        public Task<List<Category>> GetCategoryIndex(int page)
        {
            return _GetCategoryIndex.GetCategoryIndex(page);
        }
    }
}
