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

           public async Task<IActionResult> ProductIndex(int? CategoryId, int? page)
           {
               int pageNumber = page ?? 1;
               int pageSize = 3;
               var products = await _productService.GetProductAsync(CategoryId, pageNumber);
            var totalRecord = 10;
              // var totalRecord = await _productService.ProductCountAsync(CategoryId);
               int findPages = (totalRecord / pageSize);
               var totalPages = 0;
               if ((totalRecord % pageSize) == 0)
                   totalPages = findPages;
               else
                   totalPages = findPages + 1;

               ViewBag.TotalPage = totalPages;

            var categories = await _productService.GetAllCategoriesAsync();

            var selectList = new SelectList(categories as IEnumerable<Category>, "CategoryId", "CategoryName");

            ViewBag.Categories = selectList;
            return View(products);
           }

        [Route("add")]
        public async Task<IActionResult> AddProduct(int? CategoryId)
        {
            var categories = await _productService.GetAllCategoriesAsync();

            var selectList = new SelectList(categories as IEnumerable<Category>, "CategoryId", "CategoryName");

            ViewBag.Categories = selectList;
            ViewBag.CategoryId = CategoryId;
            return View();
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
           // var c = await _productService.AddProductAsync(product);
            if (ModelState.IsValid)
            {
                var c = await _productService.AddProductAsync(product);

                if (c)
                    return RedirectToAction("ProductIndex", "Product", product.CategoryId);
            }
            return View();
        }

        public async Task<IActionResult> EditProductDetails(int ProductId)
        {
            var data = await _productService.UpdateProductDetailsAsync(ProductId);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.ErrorMessage = "Category Not Found";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(int ProductId, Product product)
        {
            if (ModelState.IsValid)
            {
                var data = await _productService.UpdateProductAsync(ProductId, product);
                if (data)
                    return RedirectToAction("ProductIndex");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProductDetails(int ProductId)
        {
            var data = await _productService.DeleteProductDetailsAsync(ProductId);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.ErrorMessage = "Product Not Found";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var staus = await _productService.DeleteProductAsync(ProductId);
            if (staus)
                return RedirectToAction("ProductIndex");
            ViewBag.ErrorMessage = "Product Not found";
            return View();
        }
    }
}
