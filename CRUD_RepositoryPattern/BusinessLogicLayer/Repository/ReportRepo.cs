using BusinessLogicLayer.IRepository;
using CRUD_Operations_Product_and_Category.DAL;
using CRUD_Operations_Product_and_Category.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class ReportRepo : IReportRepo
    {
        DataManager db=new DataManager();
        public async Task<List<Report>> GetReport(int? pageNo)
        {
            int PageNumber = pageNo ?? 1;
            int PageSize = 5;

            var report = await db.Database.SqlQuery<Report>("sp_getProductReport @PageNo, @PageSize",
                          new SqlParameter("@PageNo", PageNumber), new SqlParameter("@PageSize", PageSize)).ToListAsync();

            return report;
        }
    }
}
