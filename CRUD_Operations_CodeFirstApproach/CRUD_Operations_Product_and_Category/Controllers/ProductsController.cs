using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System.Web.Routing;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.UI;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class ProductsController : Controller
    {
        private DataManager db = new DataManager();

        // GET: Products
        public async Task<ActionResult> GetProductIndex(int? id,int? page)
        {
            ViewBag.Id = id;
            if(id != null)
            {
                int pageNumber = page ?? 1;
                int pageSize = 3;
                var products = await db.Database.SqlQuery<Product>("sp_getProductDataWithPageSize @PageNo, @PageSize, @CategoryId",
                    new SqlParameter("@PageNo", pageNumber),
                    new SqlParameter("@PageSize", pageSize),
                    new SqlParameter("@CategoryId",id)).ToListAsync();

                var totalRecord = db.Products.ToList().Where(a=>a.CategoryId == id).Count();
                int findPages = (totalRecord / pageSize);
                var totalPages = 0;
                if ((totalRecord % pageSize) == 0)
                    totalPages = findPages;
                else
                    totalPages = findPages + 1;

                ViewBag.TotalPage = totalPages;

              //  var product = await db.Products.Where(x => x.CategoryId == id).ToListAsync();
                return View(products);
            }
            return View(TempData["BetweenDate"]);  
           
            
        }

        public async Task<ActionResult> ProductDetails(int? id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                ViewBag.ErrorMessage="Product Not Found";
                return View();
            }
            return View(product);
        }

        public ActionResult AddProduct(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("GetProductIndex",new RouteValueDictionary( new { id = product.CategoryId }));
            }

            return View(product);
        }

        public async Task<ActionResult> EditProductInfo(int id)
        {
            var product = await db.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditProductInfo(int ProductId,Product products)
        {
            if (ModelState.IsValid)
            {
                var product= await db.Products.FirstOrDefaultAsync(p=>p.ProductId == ProductId);
                if (product != null)
                {
                    product.CategoryId =products.CategoryId;
                    product.ProductName = products.ProductName; 
                    product.Price = products.Price;
                    product.MfgDate = products.MfgDate;
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetProductIndex", new RouteValueDictionary(new { id = product.CategoryId }));
                }               
            }
            return View(products);
        }

        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<ActionResult> Delete(int id,Product pro)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProductIndex", new RouteValueDictionary(new { id = pro.CategoryId }));
        }


        public ActionResult GetFromDateToDateMfgProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetFromDateToDateMfgProduct(DateTime fromDate, DateTime toDate)
        {
            //  var data =db.Products.SqlQuery("Select * from db.Products where mfgDate between fromDate and toDate").ToList();
            var query = from data in db.Products
                        where data.MfgDate >= fromDate && data.MfgDate <= toDate
                        select data;
            TempData["BetweenDate"] =query.ToList();
            return RedirectToAction("GetProductIndex");
        }
    }
}
