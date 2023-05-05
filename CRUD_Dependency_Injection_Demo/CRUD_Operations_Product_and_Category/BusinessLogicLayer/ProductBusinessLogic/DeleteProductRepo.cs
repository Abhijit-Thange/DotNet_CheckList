using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.ProductBusinessLogic
{
    public class DeleteProductRepo :IDeleteProduct
    {
        DataManager db=new DataManager();
        public async Task DeleteProduct(int ProductId)
        {
            var product = await db.Products.FindAsync(ProductId);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
    }
}