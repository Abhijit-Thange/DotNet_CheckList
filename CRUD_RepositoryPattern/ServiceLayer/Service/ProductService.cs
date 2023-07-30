using BusinessLogicLayer.IRepository;
using CRUD_Operations_Product_and_Category.Models;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _ProductDetails;
        private readonly IProductRepo _CreateProduct;
        private readonly IProductRepo _DeleteProduct;
        private readonly IProductRepo _EditProduct;
        private readonly IProductRepo _EditProductDetails;
        private readonly IProductRepo _GetProductIndex;
        private readonly IProductRepo _DeleteProductDetails;
        private readonly IProductRepo _ProductCount;


        public ProductService(IProductRepo productDetails, IProductRepo createProduct,
                              IProductRepo deleteProduct, IProductRepo editProduct,
                              IProductRepo editProductDetails, IProductRepo getProductIndex,
                              IProductRepo deleteProductDetails, IProductRepo productCount)
        {
            _ProductDetails = productDetails;
            _CreateProduct = createProduct;
            _DeleteProduct = deleteProduct;
            _EditProduct = editProduct;
            _EditProductDetails = editProductDetails;
            _GetProductIndex = getProductIndex;
            _DeleteProductDetails = deleteProductDetails;
            _ProductCount = productCount;
        }

        public Task<int> ProductCount(int? CategoryId)
        {
            return _ProductCount.ProductCount(CategoryId);
        }

        public Task CreateProduct(Product product)
        {
            return _CreateProduct.CreateProduct(product);
        }

        public Task DeleteProduct(int ProductId)
        {
            return _DeleteProduct.DeleteProduct(ProductId);
        }

        public Task<Product> DeleteProductDetails(int ProductId)
        {
            return _DeleteProductDetails.DeleteProductDetails(ProductId);
        }

        public Task<bool> EditProduct(int ProductId, Product product)
        {
            return _EditProduct.EditProduct(ProductId, product);
        }

        public Task<Product> EditProductDetails(int ProductId)
        {
            return _EditProductDetails.EditProductDetails(ProductId);
        }

        public Task<List<Product>> GetProductIndex(int? CategoryId, int page)
        {
          return  _GetProductIndex.GetProductIndex(CategoryId, page);
        }

        public Task<Product> ProductDetails(int? ProductId)
        {
            return _ProductDetails.ProductDetails(ProductId);
        }

        public List<Category> GetCategoryList()
        {
            return _CreateProduct.GetCategoryList();
        }
    }
}
