using CRUD_CoreWebAPI.Database;
using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Repository.IRepo;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.Data.SqlClient;

namespace CRUD_CoreWebAPI.Services.Service
{
    public class ReportService:IReportService
    {
        private readonly IReportRepo _reportRepo;

        public ReportService(IReportRepo reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public Task<List<Report>> GetReport(int? pageNo)
        {
            return _reportRepo.GetReport(pageNo);
        }
    }
}
