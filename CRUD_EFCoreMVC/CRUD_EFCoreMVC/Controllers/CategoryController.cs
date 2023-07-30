using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;

namespace CRUD_EFCoreMVC.Controllers
{
    
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var data=await _categoryService.GetCategoryAsync();
            return View(data);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if(ModelState.IsValid)
            {
                var c = await _categoryService.AddCategoryAsync(category);
                if (c)
                    return RedirectToAction("Index", "Category");
            }           
            return View();
        }

        public async Task<IActionResult> EditCategoryDetails(int CategoryId)
        {
            var data=await _categoryService.UpdateCategoryDetailsAsync(CategoryId);
            if(data !=null)
            {
                return View(data);
            }
            ViewBag.ErrorMessage = "Category Not Found";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int CategoryId ,Category category)
        {
            if (ModelState.IsValid)
            {
              var data= await _categoryService.UpdateCategoryAsync(CategoryId, category);
                if(data)
                    return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategoryDetails(int CategoryId)
        {
            var data = await _categoryService.DeleteCategoryDetailsAsync(CategoryId);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.ErrorMessage = "Category Not Found";
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var staus=await _categoryService.DeleteCategoryAsync(CategoryId);
            if (staus)
                return RedirectToAction("Index");
            ViewBag.ErrorMessage = "Category Not found";
            return View();
        }

       
    }
}
