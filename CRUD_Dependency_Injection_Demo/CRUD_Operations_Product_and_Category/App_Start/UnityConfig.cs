using BusinessLogicLayer.BusinessLogicLayer;
using BusinessLogicLayer.ServiceLayer;
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
            
            container.RegisterType<ICategoryBusinessLogic, CategoryBusinessLogic>();

            container.RegisterType<IProductBusinessLogic, ProductBusinessLogic>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}