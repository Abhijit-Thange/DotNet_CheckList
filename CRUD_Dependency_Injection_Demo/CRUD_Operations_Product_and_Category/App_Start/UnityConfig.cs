using BusinessLogicLayer.BusinessLogicLayer;
using BusinessLogicLayer.ServiceLayer;
using CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic;
using CRUD_Operations_Product_and_Category.BusinessLogicLayer.ProductBusinessLogic;
using CRUD_Operations_Product_and_Category.BusinessLogicLayer.ReportBusinessLogic;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
using CRUD_Operations_Product_and_Category.ServiceLayer.ProductService;
using CRUD_Operations_Product_and_Category.ServiceLayer.ReportService;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CRUD_Operations_Product_and_Category
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
          //  container.RegisterType<ICategoryBusinessLogic, CategoryBusinessLogic>();

            //Category
            container.RegisterType<IGetCategoryIndex, GetCategoryIndexRepo>();
            container.RegisterType<ICreateCategory, CreateCategoryRepo>();
            container.RegisterType<IUpdateCategory, UpdateCategoryRepo>();
            container.RegisterType<IDeleteCategory, DeleteCategoryRepo>();
            container.RegisterType<ICategoryDetails, CategoryDetailsRepo>();
            container.RegisterType<IActivateCategory, ActivateCategoryRepo>();
            container.RegisterType<IDeactivateCategory, DeactivateCategoryRepo>();

            //Product
            container.RegisterType<IGetProductIndex, GetProductIndexRepo>();
            container.RegisterType<IAddProduct, AddProductRepo>();
            container.RegisterType<IUpdateProduct, UpdateProductRepo>();
            container.RegisterType<IDeleteProduct, DeleteProductRepo>();
            container.RegisterType<IProductDetails, ProductDetailsRepo>();

            //Account
            container.RegisterType<IReport, ReportRepo>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}