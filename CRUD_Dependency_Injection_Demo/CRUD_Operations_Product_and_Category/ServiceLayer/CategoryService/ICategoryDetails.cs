using CRUD_Operations_Product_and_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService
{
    public interface ICategoryDetails
    {
        Task<Category> CategoryDetails(int CategoryId);
    }
}
