using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.Models;
using CRUD_Operations_Product_and_Category.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class ReportController : Controller
    {
        DataManager db=new DataManager();
        // GET: Report
        public async Task<ActionResult> ProductReport(int? pageNo)
        {
            int PageNumber = pageNo ?? 1;
            int PageSize = 5;

            var report = await db.Database.SqlQuery<Report>("sp_getProductReport @PageNo, @PageSize",
                          new SqlParameter("@PageNo", PageNumber), new SqlParameter("@PageSize", PageSize)).ToListAsync();

            var totalRecord=db.Products.Count();
            var findPages = (totalRecord / PageSize);
            var totalPages = 0;
            if ((totalRecord % PageSize) == 0)
                totalPages = findPages;
            else
                totalPages = findPages + 1;

            ViewBag.TotalPage = totalPages;
            ViewBag.Report= report;

            return View();
        }
    }
}