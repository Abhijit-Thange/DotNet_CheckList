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
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic;
using BusinessLogicLayer;
using BusinessLogicLayer.ServiceLayer;
using BusinessLogicLayer.BusinessLogicLayer;

namespace CRUD_Operations_Product_and_Category.Controllers
{
   // [AllowAnonymous]
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
        private IGetCategoryIndex _GetCategoryIndex = null;
        private ICategoryDetails _CategoryDetails = null;
        private ICreateCategory _CreateCategory = null;
        private IUpdateCategory _EditCategory = null;
        private IDeleteCategory _DeleteCategory = null;
       // private ICategoryBusinessLogic _GetCategoryIndex = new Custom();


        public CategoryController(IGetCategoryIndex GetCategoryIndex, ICategoryDetails CategoryDetails,
                                  ICreateCategory CreateCategory, IUpdateCategory EditCategory, IDeleteCategory DeleteCategory) 
        {
            _GetCategoryIndex= GetCategoryIndex;
            _CategoryDetails = CategoryDetails;
            _CreateCategory = CreateCategory;
            _EditCategory = EditCategory;
            _DeleteCategory = DeleteCategory;
        }

        public CategoryController() { }

          DataManager db = new DataManager();

        // GET: Category
        [AllowAnonymous]
        public async Task<ActionResult> GetCategoryIndex(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;
            var Categories = await _GetCategoryIndex.GetCategoryIndex(pageNumber);

            var totalRecord=db.Categories.Count();
            int findPages = (totalRecord / pageSize);
            var totalPages=0;
            if ((totalRecord % pageSize)==0)
             totalPages = findPages;
            else
                totalPages = findPages+1;

            ViewBag.TotalPage = totalPages;
            ViewBag.PageNo = pageNumber;

            return View(Categories);
        }

        public async Task<ActionResult> CategoryDetails(int CategoryId)
        {
            var category = await _CategoryDetails.CategoryDetails(CategoryId);
            if (category == null)
            {
                ViewBag.ErrorMessage = "Given Id is Not in Record...";
                return View();
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateCategory()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
              await _CreateCategory.CreateCategory(category);
                return RedirectToAction("GetCategoryIndex");
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
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
              bool update=  await _EditCategory.EditCategory(CategoryId, category);
                if (update)
                { 
                    return RedirectToAction("GetCategoryIndex");
                }               
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("~/delete-category/{CategoryID}")]

        public async Task<ActionResult> DeleteCategory(int CategoryId)
        {
            var category = await db.Categories.FirstOrDefaultAsync(p=>p.CategoryId==CategoryId);
           
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("~/delete-category/{CategoryId}")]
        [HttpPost, ActionName("DeleteCategory")]
        public async Task<ActionResult> Delete(int CategoryId)
        {
            await _DeleteCategory.DeleteCategory(CategoryId);
            return RedirectToAction("GetCategoryIndex");
        }

        public async Task<ActionResult> ActivateCategory(int CategoryId, int page)
        {
           var active=new CategoryBusinessLogic();
            await active.ActivateCategory(CategoryId);
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
