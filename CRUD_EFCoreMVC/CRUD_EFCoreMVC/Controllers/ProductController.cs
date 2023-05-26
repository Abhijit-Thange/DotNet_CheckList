using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.IServices;
using ServiceLayer.Service;

namespace CRUD_EFCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /*   public async Task<IActionResult> ProductIndex(int? CategoryId, int? page)
           {
               int pageNumber = page ?? 1;
               int pageSize = 3;
               var products = await _productService.GetProductAsync(CategoryId, pageNumber);

               var totalRecord = await _productService.ProductCountAsync(CategoryId);
               int findPages = (totalRecord / pageSize);
               var totalPages = 0;
               if ((totalRecord % pageSize) == 0)
                   totalPages = findPages;
               else
                   totalPages = findPages + 1;

               ViewBag.TotalPage = totalPages;

              // var categories = _productService.GetProductList();
              // var selectList = new SelectList(categories as IEnumerable<Category>, "CategoryId", "CategoryName");

             //  ViewBag.Categories = selectList;
               return View(products);
           }*/

        [Route("add")]
        public IActionResult AddProduct()
        {
            var categories = _productService.GetAllCategoriesAsync();
          //  var selectList = new SelectList(categories as IEnumerable<Category>, "CategoryId", "CategoryName");

          //  ViewBag.Categories = selectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product category)
        {
            if (ModelState.IsValid)
            {
                var c = await _productService.AddProductAsync(category);
                if (c)
                    return RedirectToAction("Index", "Product",category.CategoryId);
            }
            return View();
        }
/*
        public async Task<IActionResult> EditCategoryDetails(int CategoryId)
        {
            var data = await _productService.UpdateProductDetailsAsync(CategoryId);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.ErrorMessage = "Category Not Found";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int CategoryId, Product category)
        {
            if (ModelState.IsValid)
            {
                var data = await _productService.UpdateProductAsync(CategoryId, category);
                if (data)
                    return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategoryDetails(int CategoryId)
        {
            var data = await _productService.DeleteProductDetailsAsync(CategoryId);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.ErrorMessage = "Category Not Found";
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var staus = await _productService.DeleteProductAsync(CategoryId);
            if (staus)
                return RedirectToAction("Index");
            ViewBag.ErrorMessage = "Category Not found";
            return View();
        }*/
    }
}
