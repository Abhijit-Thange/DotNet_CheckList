using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService
{
    public interface IActivateCategory
    {
        Task ActivateCategory(int CategoryId);

    }
}
