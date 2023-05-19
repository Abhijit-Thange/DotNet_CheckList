using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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
         
            var reports = await _dataManager.Report.FromSqlInterpolated($"EXEC sp_getProductReport {PageNumber}, {PageSize}")
                            .ToListAsync();

            return reports;
        }
    }
}
