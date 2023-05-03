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
using BusinessLogicLayer.ServiceLayer;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class ProductsController : Controller
    {
        private IProductBusinessLogic _GetProductIndex = null;
        private IProductBusinessLogic _ProductDetails = null;
        private IProductBusinessLogic _AddProduct = null;
        private IProductBusinessLogic _EditProduct = null;
        private IProductBusinessLogic _DeleteProduct = null;

        public ProductsController(IProductBusinessLogic GetProductIndex, IProductBusinessLogic ProductDetails,
                                   IProductBusinessLogic AddProduct, IProductBusinessLogic EditProduct,
                                   IProductBusinessLogic DeleteProduct)
        { 
            _GetProductIndex=GetProductIndex;
            _ProductDetails=ProductDetails; 
            _AddProduct=AddProduct;
            _EditProduct=EditProduct;
            _DeleteProduct=DeleteProduct;
        }


        DataManager db = new DataManager();

        // GET: Products
        public async Task<ActionResult> GetProductIndex(int? CategoryId, int? page)
        {
            ViewBag.CategoryId = CategoryId;
            if(CategoryId != null)
            {
                int pageNumber = page ?? 1;
                int pageSize = 3;
                var products = await _GetProductIndex.GetProductIndex(pageNumber, pageSize);

                var totalRecord = db.Products.ToList().Where(a=>a.CategoryId == CategoryId).Count();
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

        public ActionResult AddProduct(int CategoryId)
        {
            ViewBag.CategoryId = CategoryId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
               await _AddProduct.AddProduct(product);
                return RedirectToAction("GetProductIndex",new RouteValueDictionary( new { CategoryId = product.CategoryId }));
            }
            return View(product);
        }

        public async Task<ActionResult> EditProductInfo(int ProductId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == ProductId);
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditProductInfo(int ProductId,Product products)
        {
            if (ModelState.IsValid)
            {
             bool product=  await _EditProduct.EditProduct(ProductId, products);
                if (product) 
                { 
                    return RedirectToAction("GetProductIndex", new RouteValueDictionary(new { id = products.CategoryId }));
                }               
            }
            return View(products);
        }

        public async Task<ActionResult> DeleteProduct(int ProductId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(x=>x.ProductId == ProductId);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<ActionResult> Delete(int ProductId, Product pro)
        {
            await _DeleteProduct.DeleteProduct(ProductId);
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
