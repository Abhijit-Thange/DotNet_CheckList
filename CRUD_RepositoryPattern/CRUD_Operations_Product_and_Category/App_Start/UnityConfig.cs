
using BusinessLogicLayer.IRepository;
using BusinessLogicLayer.Repository;
using ServiceLayer.IService;
using ServiceLayer.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Utility;

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
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICategoryRepo, CategoryRepo>();

            //Product
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepo, ProductRepo>();

            //Report
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<IReportRepo, ReportRepo>();

            //Account

            //Utility
            container.RegisterType<IEmailService, EmailService>();
            container.RegisterType<ISendEmail, SendEmail>();




            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}