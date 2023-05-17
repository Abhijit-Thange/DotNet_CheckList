using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CoreWebAPI.Repository.Repo
{
    public class ReportRepo :IReportRepo
    {
        private readonly DataManager _dataManager;

        public ReportRepo(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<List<Report>> GetReport(int? pageNo)
        {
            int PageNumber = pageNo ?? 1;
            int PageSize = 5;

            var report = await _dataManager.Database.SqlQueryRaw<Report>("EXEC sp_getProductReport @PageNo, @PageSize",
                         new SqlParameter("@PageNo", PageNumber), new SqlParameter("@PageSize", PageSize)).ToListAsync();
            return report;
        }
    }
}
