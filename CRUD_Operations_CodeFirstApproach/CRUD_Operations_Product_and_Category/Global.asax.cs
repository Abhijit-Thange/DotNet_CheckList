using CRUD_Operations_Product_and_Category.JWT_Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
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
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }

        public void Application_AuthenticateRequest()
        {
            // var ticket = Request.Cookies[FormsAuthentication.FormsCookieName]?.Value;
           // string CookieName = FormsAuthentication.FormsCookieName;
            var token = Request.Cookies["token"]?.Value;
            
            if (!string.IsNullOrEmpty(token))
            {
                TokenManager.ValidateToken(token);
            }
        }

        protected void Application_EndRequest() 
        {
            var context = new HttpContextWrapper(Context);
            if(context.Response.StatusCode==401)
            {
                context.Response.Redirect("~/Account/Login");
            }
        }
    }
}
 