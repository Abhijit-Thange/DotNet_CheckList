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
using ServiceLayer.IService;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _ProductService = null;
       
        public ProductsController(IProductService productService)
        { 
            _ProductService=productService;         
        }

        // GET: Products
        public async Task<ActionResult> GetProductIndex(int? CategoryId, int? page)
        {
            ViewBag.CategoryId = CategoryId;
            if(CategoryId != null)
            {
                int pageNumber = page ?? 1;
                int pageSize = 3;
                var products = await _ProductService.GetProductIndex(CategoryId,pageNumber);

                var totalRecord = await _ProductService.ProductCount(CategoryId);
                int findPages = ( totalRecord / pageSize);
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
            var product =await  _ProductService.ProductDetails(ProductId);
            if (product == null)
            {
                ViewBag.ErrorMessage="Product Not Found";
                return View();
            }
            return View(product);
        }

        public  ActionResult AddProduct(int CategoryId)
        {
            var categories = _ProductService.GetCategoryList();
            var selectList = new SelectList(categories as IEnumerable<Category>, "CategoryId", "CategoryName");

            ViewBag.Categories = selectList;

            ViewBag.CategoryId = CategoryId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
               await _ProductService.CreateProduct(product);
                return RedirectToAction("GetProductIndex",new RouteValueDictionary( new { CategoryId = product.CategoryId }));
            }
            return View(product);
        }

        public async Task<ActionResult> EditProductInfo(int ProductId)
        {
            var product = await _ProductService.EditProductDetails(ProductId);
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditProductInfo(int ProductId,Product products)
        {
            if (ModelState.IsValid)
            {
             var product=  await _ProductService.EditProduct(ProductId, products);
                if (product) 
                { 
                    return RedirectToAction("GetProductIndex", new RouteValueDictionary(new { CategoryId = products.CategoryId }));
                }               
            }

            return View(products);
        }

        public async Task<ActionResult> DeleteProduct(int ProductId)
        {
            var product = await _ProductService.DeleteProductDetails(ProductId);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<ActionResult> Delete(int ProductId, Product pro)
        {
            await _ProductService.DeleteProduct(ProductId);
            return RedirectToAction("GetProductIndex", new RouteValueDictionary(new { CategoryId = pro.CategoryId }));
        }

        public ActionResult GetFromDateToDateMfgProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetFromDateToDateMfgProduct(DateTime fromDate, DateTime toDate)
        {
            DataManager db= new DataManager();
            //  var data =db.Products.SqlQuery("Select * from db.Products where mfgDate between fromDate and toDate").ToList();
            var query = from data in db.Products
                        where data.MfgDate >= fromDate && data.MfgDate <= toDate
                        select data;
            TempData["BetweenDate"] =query.ToList();
            return RedirectToAction("GetProductIndex");
        }
    }
}
