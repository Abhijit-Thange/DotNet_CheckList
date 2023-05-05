using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using CRUD_Operations_Product_and_Category.ServiceLayer.ProductService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.ProductBusinessLogic
{
    public class UpdateProductRepo :IUpdateProduct
    {
        DataManager db = new DataManager(); 
        public async Task<Product> EditProduct(int ProductId, Product products)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (product != null)
            {
                product.CategoryId = products.CategoryId;
                product.ProductName = products.ProductName;
                product.Price = products.Price;
                product.MfgDate = products.MfgDate;
                await db.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}