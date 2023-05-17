using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("update/{ProductId}")]
        public async Task<string> UpdateProduct([FromRoute] int ProductId, [FromBody] Product product)
        {
            if(ModelState.IsValid)
            {
                var update= await _product.EditProduct(ProductId, product);
                if (update)
                    return "Product Updated Successfully ";
            }
            return "Data not Valid";
        }

        [HttpDelete("delete/{ProductId}")]
        public async Task<string> DeleteProduct([FromRoute] int ProductId)
        {
            var delete= await _product.DeleteProduct(ProductId);
            if (delete)
                return "Product Deleted";
            return "Product Not Found";
        }

        [HttpPatch("{ProductId}")]
        public async Task<string> UpdateProductPatch([FromRoute] int ProductId, [FromBody] JsonPatchDocument product)
        {
            if(ModelState.IsValid)
            {
             var update =   await _product.UpdateProductPatch(ProductId, product);
                if (update)
                    return "Product Updated...";
            }
            return "Data InValid..";
        }

        [HttpGet("{ProductId}")]
        public async Task<Product> GetProductDetails([FromRoute] int ProductId)
        {
            return await _product.ProductDetails(ProductId);
        }
    }
}
