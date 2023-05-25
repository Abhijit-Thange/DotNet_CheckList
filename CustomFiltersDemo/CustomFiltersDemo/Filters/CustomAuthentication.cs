﻿ using CustomFiltersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace CustomFiltersDemo.Filters
{
    public class CustomAuthentication : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
             if(!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }


        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
             if(filterContext == null || filterContext.Result is  HttpUnauthorizedResult)
            {
               // filterContext.Result = new ViewResult();
               //Here Showing Error Page
            }
        }
    }
}