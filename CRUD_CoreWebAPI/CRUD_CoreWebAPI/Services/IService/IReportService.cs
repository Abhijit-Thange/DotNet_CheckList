using CRUD_CoreWebAPI.Models;

namespace CRUD_CoreWebAPI.Services.IService
{
    public interface IReportService
    {
        Task<List<Report>> GetReport(int? pageNo);
    }
}
