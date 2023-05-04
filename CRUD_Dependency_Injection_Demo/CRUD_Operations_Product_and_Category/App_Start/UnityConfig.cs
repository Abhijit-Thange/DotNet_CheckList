using BusinessLogicLayer.BusinessLogicLayer;
using BusinessLogicLayer.ServiceLayer;
using CRUD_Operations_Product_and_Category.BusinessLogicLayer.CategoryBusinessLogic;
using CRUD_Operations_Product_and_Category.ServiceLayer.CategoryService;
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

            container.RegisterType<IProductBusinessLogic, ProductBusinessLogic>();

            //Category
            container.RegisterType<IGetCategoryIndex, GetCategoryIndexRepo>();
            container.RegisterType<ICreateCategory, CreateCategoryRepo>();
            container.RegisterType<IUpdateCategory, UpdateCategoryRepo>();
            container.RegisterType<IDeleteCategory, DeleteCategoryRepo>();
            container.RegisterType<ICategoryDetails, CategoryDetailsRepo>();




            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}