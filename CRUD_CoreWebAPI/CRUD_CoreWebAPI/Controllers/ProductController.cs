using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet("{CategoryId}/pageNo/{page}")]
       public async Task<List<Product>> GetProductIndex(int? CategoryId, int? page)
        {
           var products= await _product.GetProductIndex(CategoryId, page);
            return products;
        }

        [HttpPost("")]
        public async Task<string> AddProduct( [FromBody]Product product)
        {
            if(ModelState.IsValid)
            {
              var isAdd = await  _product.CreateProduct(product);
                if(isAdd)
                {
                    return "Product Added..";
                }
            }
            return "Data Not Valid..";
        }
    }
}
