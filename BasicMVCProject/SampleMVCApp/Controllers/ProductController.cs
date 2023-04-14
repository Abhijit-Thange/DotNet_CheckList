using SampleMVCApp.DAL;
using SampleMVCApp.Models;
using SampleMVCApp.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCApp.Controllers
{
    public class ProductController : Controller
    {
        DataAccess dac=new DataAccess();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertProduct(int? from)
        {
           ViewData["id"] = from;
           ViewBag.Form = from;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> InsertProduct(Product product)
        {
            dac.Products.Add(product);
           await dac.SaveChangesAsync();
            return RedirectToAction("CategoryList", "Categories");
        }

        public ActionResult GetProduct(int? id)
        {
              var data= dac.Products.ToList();
            int? CId = id;
          /*  var products = (from p in dac.Products
                            join c in dac.Categories on p.CategoryId equals CId
                            select new Product_Category_Data
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                CategoryId = c.CategoryId,
                                
                            });*/
          /*  var query1 = from c in dac.Products join p in dac.Categories
                        on c.CategoryId.Equals(cId),
                        select Product;*/

            var query = dac.Products.Where(x => x.CategoryId == CId).ToList();
            ViewBag.id = CId;
            ViewBag.Products=query;
            return View();
        }

        public ActionResult UpdateProduct(int? from)
        {
            int? id = from;
            ViewBag.From = id;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(int ProductId, Product product)
        {
            using (var mgr = new DataAccess())
            {
                var data = mgr.Products.FirstOrDefault(c => c.ProductId == ProductId);
              //  int id = product.ProductId;
                if (data != null)
                {
                    data.ProductId = product.ProductId;
                    data.ProductName = product.ProductName;
                    await mgr.SaveChangesAsync();
                    return RedirectToAction("GetProduct", "Product", new {id=product.ProductId});
                }
                else
                {
                    string message = "Given Category Id not exists in Record...";
                    ViewData["message"] = message;
                    return RedirectToAction("GetProduct", "Product");
                }
            }
        }

        public async Task<ActionResult> DeleteProduct(int? id)
        {
            using (var mgr = new DataAccess())
            {
                var data = mgr.Products.FirstOrDefault(c => c.ProductId == id);

                if (data != null)
                {
                    mgr.Products.Remove(data);
                    await mgr.SaveChangesAsync();
                    return RedirectToAction("GetProduct", "Product");
                }

                return RedirectToAction("GetProduct", "Product");
            }
        }
    }
}