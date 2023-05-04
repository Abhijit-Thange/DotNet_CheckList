using BusinessLogicLayer.ServiceLayer;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class Custom : IGetCategoryIndex
    {
        DataManager db=new DataManager();
        public Task<Category> CategoryDetails(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCategory(int CategoryId, Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetCategoryIndex(int page)
        {
            var c= await db.Categories.Where(x=>x.CategoryId==1).ToListAsync();
            return c;
        }
    }
}
