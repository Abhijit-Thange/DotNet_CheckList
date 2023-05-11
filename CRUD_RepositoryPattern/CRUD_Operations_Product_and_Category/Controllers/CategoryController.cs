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
using BusinessLogicLayer;
using ServiceLayer.IService;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService = null;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        public CategoryController() { }

        // GET: Category

        [AllowAnonymous]
        public async Task<ActionResult> GetCategoryIndex(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;
            var Categories = await _CategoryService.GetCategoryIndex(pageNumber);

            var totalRecord = await _CategoryService.CategoryCount();
            int findPages = (totalRecord / pageSize);
            var totalPages = 0;
            if ((totalRecord % pageSize) == 0)
                totalPages = findPages;
            else
                totalPages = findPages + 1;

            ViewBag.TotalPage = totalPages;
            ViewBag.PageNo = pageNumber;

            return View(Categories);
        }

        public async Task<ActionResult> CategoryDetails(int CategoryId)
        {
            var category = await _CategoryService.CategoryDetails(CategoryId);
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
                await _CategoryService.CreateCategory(category);
                return RedirectToAction("GetCategoryIndex");
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("update-Category")]
        public async Task<ActionResult> EditCategory(int CategoryId)
        {
            Category category = await _CategoryService.EditCategoryDetails(CategoryId);

            return View(category);
        }


        [Route("update-Category")]
        [HttpPost]
        public async Task<ActionResult> EditCategory(int CategoryId, Category category)
        {
            if (ModelState.IsValid)
            {
                bool update = await _CategoryService.EditCategory(CategoryId, category);
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
            var category = await _CategoryService.DeleteCategoryDetails(CategoryId);
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [Route("~/delete-category/{CategoryId}")]
        [HttpPost, ActionName("DeleteCategory")]
        public async Task<ActionResult> Delete(int CategoryId)
        {
            await _CategoryService.DeleteCategory(CategoryId);
            return RedirectToAction("GetCategoryIndex");
        }

        public async Task<ActionResult> ActivateCategory(int CategoryId, int page)
        {
            await _CategoryService.ActivateCategory(CategoryId);
            return RedirectToAction("GetCategoryIndex", new RouteValueDictionary(new { page = page }));
        }

        public async Task<ActionResult> DeactivateCategory(int CategoryId, int page)
        {
            await _CategoryService.DeactivateCategory(CategoryId);
            return RedirectToAction("GetCategoryIndex", new RouteValueDictionary(new { page = page }));
        }
    }
}
