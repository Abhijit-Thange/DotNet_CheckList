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
using System.Data.SqlClient;
using System.Web.Routing;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
          DataManager db = new DataManager();
      
        // GET: Category
        public async Task<ActionResult> GetCategoryIndex(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;
            var Categories = await db.Database.SqlQuery<Category>("sp_getCategoryDataWithPageSize @PageNo, @PageSize",
                new SqlParameter("@PageNo",pageNumber),
                new SqlParameter("@PageSize",pageSize)).ToListAsync();

            var totalRecord=db.Categories.Count();
            int findPages = (totalRecord / pageSize);
            var totalPages=0;
            if ((totalRecord % pageSize)==0)
             totalPages = findPages;
            else
                totalPages = findPages+1;

            ViewBag.TotalPage = totalPages;
            ViewBag.PageNo = pageNumber;

          //  var d = await db.Database.SqlQuery<Category>("sp_getCategoryDataWithPageSize @PageNo, @PageSize",pageNumber,pageSize).ToListAsync();
           // var data = await db.Categories.ToListAsync();
            return View(Categories);
        }

        public async Task<ActionResult> CategoryDetails(int? CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(x=>x.CategoryId== CategoryId);
            if (category == null)
            {
                ViewBag.ErrorMessage = "Given Id is Not in Record...";
                return View();
            }
            return View(category);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("GetCategoryIndex");
            }

            return View(category);
        }

        [Route("update-Category")]
        public async Task<ActionResult> EditCategory(int CategoryId)
        {
           
            Category category = await db.Categories.FirstOrDefaultAsync(c=>c.CategoryId== CategoryId);
           
            return View(category);
        }

        [Route("update-Category")]
        [HttpPost]
        public async Task<ActionResult> EditCategory(int CategoryId,Category category)
        {
            if (ModelState.IsValid)
            {
               var data=await db.Categories.FirstOrDefaultAsync(c=>c.CategoryId==CategoryId);
                if (data != null)
                {
                    data.CategoryId=category.CategoryId;
                    data.CategoryName=category.CategoryName;
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetCategoryIndex");
                }
                
            }
            return View(category);
        }

        [Route("~/delete-category/{CategoryID}")]

        public async Task<ActionResult> DeleteCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(p=>p.CategoryId==CategoryId);
           
            return View(category);
        }

        [Route("~/delete-category/{CategoryId}")]
        [HttpPost, ActionName("DeleteCategory")]
        public async Task<ActionResult> Delete(int CategoryId)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(p=> p.CategoryId== CategoryId);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("GetCategoryIndex");
        }

        public async Task<ActionResult> ActivateCategory(int CategoryId, int page)
        {
            var category =await db.Categories.FirstOrDefaultAsync(c=>c.CategoryId== CategoryId);
            category.IsActive = true;
           await db.SaveChangesAsync();
            return RedirectToAction("GetCategoryIndex",new RouteValueDictionary(new {page = page}));
        }

        public async Task<ActionResult> DeactivateCategory(int CategoryId, int page)
        {
            var category =await db.Categories.FirstOrDefaultAsync(c=> c.CategoryId== CategoryId);
            category.IsActive = false;
           await db.SaveChangesAsync();
            return RedirectToAction("GetCategoryIndex", new RouteValueDictionary(new { page = page })); 
        }
    }
}
