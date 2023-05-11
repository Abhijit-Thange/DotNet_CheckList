using RESTAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace RESTAPIDemo.Controllers
{
    [Route("api/category")]
    public class CategoryController : ApiController
    {
        DataManager db=new DataManager();

        [HttpGet]
        public List<Category> GetCategoryIndex()
        {
            var data=db.Categories.ToList();
            return data;
        }

        [HttpPost]
        public string AddCategory([FromBody]Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return "Category Added";
        }

        [HttpPut]
        public string UpdateCategory([FromBody]Category category)
        {
            var data=db.Categories.FirstOrDefault(c=>c.CategoryId==category.CategoryId);
            data.CategoryName = category.CategoryName;
            db.SaveChanges();
            return "Category Updated by put";
        }

        [HttpPatch]
        public string UpdateCategoryPatch([FromBody] Category category)
        {
            var data = db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            data.CategoryName = category.CategoryName;
            db.SaveChanges();
            return "Category Updated by patch";
        }

        [HttpDelete]
        public string  Delete([FromUri]int id)
        {
            var category=db.Categories.FirstOrDefault(c => c.CategoryId == id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return "Category Deleted";
        }

    }
}
