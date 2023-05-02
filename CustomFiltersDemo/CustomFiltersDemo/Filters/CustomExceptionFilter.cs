using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFiltersDemo.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.Exception is DivideByZeroException)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error"
                };
            }

            filterContext.ExceptionHandled = true;
        }
    }
}