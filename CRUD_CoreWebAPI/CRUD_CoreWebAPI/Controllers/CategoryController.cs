using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategories _categories;

        public CategoryController(ICategories categories)
        {
            _categories = categories;
        }

        [HttpGet]
       public async Task<List<Category>> GetCategories()
        {
           var data= await _categories.GetAllCategories();
            return data;
        }

        [HttpPost]
        public async Task<string> AddCategory([FromBody]Category category) 
        {
            if(ModelState.IsValid)
            {
                var insert = await _categories.AddCategory(category);
                if (insert)
                    return "Data Inserted Sucessfully";
            }
            return "Data Not Inserted...";
        }

        [HttpPut("{CategoryId}")]
       public async Task<string> UpdateCategory([FromRoute]int CategoryId,[FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
             var update=   await _categories.UpdateCategory(CategoryId, category);
                if(update)
                    return "Update Successfully";
            }
            return "Not Update";
        }

        [HttpDelete("{CategoryId}")]
        public async Task<string> DeleteCategory([FromRoute]int CategoryId)
        {
           var delete= await _categories.DeleteCategory(CategoryId);
            if (delete) return "Category Deleted Successfully";
            return "Category Not Found";
        }

        [HttpGet("{CategoryId}")]
       public async Task<Category> CategoryDetails([FromRoute]int CategoryId)
        {
            return await _categories.CategoryDetails(CategoryId);
        }
    }
}
