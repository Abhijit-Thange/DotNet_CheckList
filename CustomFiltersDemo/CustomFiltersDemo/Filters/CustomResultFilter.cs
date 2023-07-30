using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFiltersDemo.Filters
{
    public class CustomResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "On Action Executed...";
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Before = "Action Method Executing..";
        }
    }
}