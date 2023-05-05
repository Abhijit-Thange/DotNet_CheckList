using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.POCO;
using CRUD_Operations_Product_and_Category.ServiceLayer.ReportService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_Product_and_Category.BusinessLogicLayer.ReportBusinessLogic
{
    public class ReportRepo : IReport
    {
        DataManager db = new DataManager();
        public async Task<List<Report>> ProductReport(int? pageNo)
        {
            int PageNumber = pageNo ?? 1;
            int PageSize = 5;

            var report = await db.Database.SqlQuery<Report>("sp_getProductReport @PageNo, @PageSize",
                          new SqlParameter("@PageNo", PageNumber), new SqlParameter("@PageSize", PageSize)).ToListAsync();

            return report;
        }
    }
}