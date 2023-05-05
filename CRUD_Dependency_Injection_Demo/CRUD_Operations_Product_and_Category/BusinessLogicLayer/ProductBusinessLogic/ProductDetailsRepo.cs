using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.ProductService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.ProductBusinessLogic
{
    public class ProductDetailsRepo:IProductDetails
    {
        DataManager db= new DataManager();
        public async Task<Product> ProductDetails(int? ProductId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(a => a.ProductId == ProductId);
            return product;
        }
    }
}