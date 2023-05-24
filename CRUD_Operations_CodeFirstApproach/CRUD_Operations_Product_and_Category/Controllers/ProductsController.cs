using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using System.Web.Routing;
using System.Data.SqlClient;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class ProductsController : Controller
    {
         DataManager db = new DataManager();

        // GET: Products
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetProductIndex(int? CategoryId, int? page)
        {
            ViewBag.CategoryId = CategoryId;
            if(CategoryId != null)
            {
                int pageNumber = page ?? 1;
                int pageSize = 3;
                var products = await db.Database.SqlQuery<Product>("sp_getProductDataWithPageSize @PageNo, @PageSize, @CategoryId",
                    new SqlParameter("@PageNo", pageNumber),
                    new SqlParameter("@PageSize", pageSize),
                    new SqlParameter("@CategoryId", CategoryId)).ToListAsync();

                var totalRecord = db.Products.ToList().Where(a=>a.CategoryId == CategoryId).Count();
                int findPages = (totalRecord / pageSize);
                var totalPages = 0;
                if ((totalRecord % pageSize) == 0)
                    totalPages = findPages;
                else
                    totalPages = findPages + 1;

                ViewBag.TotalPage = totalPages;

                var Categories = db.Categories.ToList();
                var selectList = new SelectList(Categories, "CategoryId", "CategoryName");

                ViewBag.Categories = selectList;

                return View(products);
            }
            return View(TempData["BetweenDate"]);  
            
        }


        public async Task<ActionResult> ProductDetails(int? ProductId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(a => a.ProductId == ProductId);
            if (product == null)
            {
                ViewBag.ErrorMessage="Product Not Found";
                return View();
            }
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(int CategoryId)
        {
            var Categories=db.Categories.ToList();
            var selectList = new SelectList(Categories, "CategoryId", "CategoryName");

            ViewBag.Categories = selectList;
            ViewBag.CategoryId = CategoryId;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("GetProductIndex",new RouteValueDictionary( new { CategoryId = product.CategoryId }));
            }
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditProductInfo(int ProductId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == ProductId);
            return View(product);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int ProductId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(x=>x.ProductId == ProductId);
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("DeleteProduct")]
        public async Task<ActionResult> Delete(int ProductId, Product pro)
        {
            Product product = await db.Products.FindAsync(ProductId);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProductIndex", new RouteValueDictionary(new { CategoryId = pro.CategoryId }));
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
