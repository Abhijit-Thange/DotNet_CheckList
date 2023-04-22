using CRUD_Operations_Product_and_Category.JWT_Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace CRUD_Operations_Product_and_Category
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); //Apply Globaly Authentication

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_AuthenticateRequest()
        {
            // var ticket = Request.Cookies[FormsAuthentication.FormsCookieName]?.Value;
            var token = Request.Cookies[FormsAuthentication.FormsCookieName]?.Value;
            
            TokenManager.ValidateToken(token);
        }

        protected void Application_get() 
        {
        }
    }
}
