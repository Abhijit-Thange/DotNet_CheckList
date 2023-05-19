using CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic;
using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoryIndex(int page);
       
    }
}