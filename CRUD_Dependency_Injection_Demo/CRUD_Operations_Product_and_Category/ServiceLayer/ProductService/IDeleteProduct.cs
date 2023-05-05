using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operations_Product_and_Category.ServiceLayer.ProductService
{
    public interface IDeleteProduct
    {
        Task DeleteProduct(int ProductId);
    }
}
