using SampleMVCApp.DAL;
using SampleMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCApp.Controllers
{
    public class CategoriesController : Controller
    {
        DataAccess dac=new DataAccess();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertProductCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> InsertProductCategory(Category c)
        {
            //await Task.Run(() => { })
            dac.Categories.Add(c);
          await dac.SaveChangesAsync();
            return RedirectToAction("CategoryList","Categories");
        }
        public  ActionResult CategoryList()
        {
            List<Category> categories = dac.Categories.ToList();
            ViewData["list"] = categories;
            return View();
        }

        public ActionResult UpdateProductCategory(int? from)
        {
            int? id = from;
            ViewBag.From = id;
            return View();
        }

       [HttpPost]
        public async Task<ActionResult> UpdateProductCategory(int CategoryId,Category category) 
        { 
            using(var mgr=new DataAccess())
            {
                var data=mgr.Categories.FirstOrDefault(c=>c.CategoryId == CategoryId);
                if(data != null)
                {
                    data.CategoryId = category.CategoryId;
                    data.CategoryName = category.CategoryName;
                  await mgr.SaveChangesAsync();
                    return RedirectToAction("CategoryList", "Categories");
                }
                else
                {
                    ViewBag.ErrorMwessage = "Given Category Id not exists in Record...";
                    return View();
                }
            }           
        } 

        public async Task<ActionResult> DeleteProductCategory(int? id)
        {
            using (var mgr = new DataAccess())
            {
                var data=mgr.Categories.FirstOrDefault(c=>c.CategoryId==id);

                if(data != null)
                {
                    mgr.Categories.Remove(data);
                    await mgr.SaveChangesAsync();
                    return RedirectToAction("CategoryList", "Categories");
                }

                return RedirectToAction("CategoryList", "Categories");

            }
        }
      
    }
}